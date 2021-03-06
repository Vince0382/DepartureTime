﻿using System;  
using System.IO;  
using Xamarin.Forms;
using DepartureTime.Interfaces;
using DepartureTime.Droid.Helpers;
[assembly: Dependency(typeof(FileHelper))] 

namespace DepartureTime.Droid.Helpers
{
	public class FileHelper : IFileReadWrite
    {
		public void WriteData(string filename, string data)
        {
			File.WriteAllText(GetFilePath(filename), data);
        }
        public string ReadData(string filename)
        {
			return File.ReadAllText(GetFilePath(filename));
        }
        public bool FileExist(string filename)
		{
			return File.Exists(GetFilePath(filename));
		}
        
        private string GetFilePath(string filename)
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(documentsPath, filename);
		}

		public FileHelper()
        {
        }
    }
}
