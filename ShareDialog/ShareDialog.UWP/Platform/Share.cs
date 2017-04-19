using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareDialog;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Storage;

namespace ShareDialog.UWP.Platform
{
	public class Share : IShare
	{
		private string _filePath;
		private string _title;
		private string _message;
		private readonly DataTransferManager _dataTransferManager;

		public Share()
		{
			_dataTransferManager = DataTransferManager.GetForCurrentView();
			_dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(ShareTextHandler);
		}

		/// <summary>
		/// MUST BE CALLED FROM THE UI THREAD
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="title"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public Task Show(string title, string message, string filePath)
		{
			_title = title ?? string.Empty;
			_filePath = filePath;
			_message = message ?? string.Empty;
			
			DataTransferManager.ShowShareUI();
			
			return Task.FromResult(true);
		}

		private async void ShareTextHandler(DataTransferManager sender, DataRequestedEventArgs e)
		{
			DataRequest request = e.Request;

			// Title is mandatory
			request.Data.Properties.Title = string.IsNullOrEmpty(_title) ? Windows.ApplicationModel.Package.Current.DisplayName : _title;

			DataRequestDeferral deferral = request.GetDeferral();

			try
			{
				if (!string.IsNullOrWhiteSpace(_filePath))
				{
					StorageFile attachment = await StorageFile.GetFileFromPathAsync(_filePath);
					List<IStorageItem> storageItems = new List<IStorageItem>();
					storageItems.Add(attachment);
					request.Data.SetStorageItems(storageItems);
				}
				request.Data.SetText(_message ?? string.Empty);
			}
			finally
			{
				deferral.Complete();
			}
		}
	}
}
