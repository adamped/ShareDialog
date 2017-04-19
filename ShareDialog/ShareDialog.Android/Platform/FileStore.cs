using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
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