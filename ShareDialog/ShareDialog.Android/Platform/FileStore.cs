using System.IO;

namespace ShareDialog.Droid.Platform
{
	public class FileStore: IFileStore
	{
		public string GetFilePath()
		{
			return Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "image.png");
		}
	}
}