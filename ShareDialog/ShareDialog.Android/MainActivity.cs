
using Android.App;
using Android.Content.PM;
using Android.OS;
using ShareDialog.Droid.Platform;
using System.IO;
using Xamarin.Forms;

namespace ShareDialog.Droid
{
	[Activity(Label = "ShareDialog", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			Forms.Init(this, bundle);

			// Copy image from Assets and place in DataDirectory on Android.

			using (var stream = Assets.OpenFd("image.upng"))
			using (var readStream = Assets.Open("image.upng"))
			using (var memoryStream = new MemoryStream())
			{
				byte[] buffer = new byte[stream.Length];
				int read;
				while ((read = readStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					memoryStream.Write(buffer, 0, read);
				}
				var data = memoryStream.ToArray();
				var path = Path.Combine(Environment.ExternalStorageDirectory.AbsolutePath, "image.png");
				System.IO.File.WriteAllBytes(path, data);

			}


			DependencyService.Register<FileStore>();
			DependencyService.Register<Share>();
			LoadApplication(new App());
		}
	}
}

