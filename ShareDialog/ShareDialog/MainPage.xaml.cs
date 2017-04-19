using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareDialog
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			ShareButton.Clicked += ShareButton_Clicked;
		}

		private void ShareButton_Clicked(object sender, EventArgs e)
		{
			var filePath = DependencyService.Get<IFileStore>().GetFilePath();

			var share = DependencyService.Get<IShare>();

			share.Show("Title", "Message", filePath);
		}
	}
}
