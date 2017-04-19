using System.Threading.Tasks;

namespace ShareDialog
{
	public interface IShare
	{
		Task Show(string title, string message, string filePath);
	}
}
