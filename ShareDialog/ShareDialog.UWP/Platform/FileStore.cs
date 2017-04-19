using ShareDialog;
using System.IO;
using Windows.ApplicationModel;
using Windows.Storage;

namespace ShareDialog.UWP.Platform
{
	public class FileStore: IFileStore
	{
		public string GetFilePath()
		{
			return Path.Combine(Package.Current.InstalledLocation.Path, "image.png");
		}
	}
}
