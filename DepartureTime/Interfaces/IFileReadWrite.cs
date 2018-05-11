using System;
using Xamarin.Forms;
namespace DepartureTime.Interfaces
{

    public interface IFileReadWrite 
	{  
        void WriteData(string fileName, string data);  
        string ReadData(string filename);
		bool FileExist(string filename);
    }

}
