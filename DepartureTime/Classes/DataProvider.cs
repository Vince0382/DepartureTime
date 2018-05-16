using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using DepartureTime.Interfaces;
using DepartureTime.Models;
using DepartureTime.Helpers;
using Xamarin.Forms;

namespace DepartureTime.Classes
{
    public class DataProvider : IDataProvider
    {
		private const string _fileConfigID = "Config.xml";
        private const string _resourceLanguageID = "DepartureTime.Resources.Languages.xml";
        private const string _resourceConfigID = "DepartureTime.Resources." + _fileConfigID;
		private const string _BaliseWH = "WorkingHours";
		private const string _BaliseBGC = "BackgroundColor";
		private const string _BaliseTC = "TextColor";
		private const string _BaliseLN = "Language";
        
        //Get all languages available

		public Languages GetLanguages()
        {
            return new Languages(_resourceLanguageID);
        }


        //Get application data from config file

        public DepartureTimeData GetData()
        {
            DepartureTimeData data = new DepartureTimeData();

			data.WorkingHours = TimeSpan.Parse((string)GetDataFromXML(_BaliseWH));
			data.BgColor = ColorsHelper.StringToColor((string)GetDataFromXML(_BaliseBGC));
			data.TxtColor = ColorsHelper.StringToColor((string)GetDataFromXML(_BaliseTC));

            return data;
        }


        public DepartureTimeLanguage GetCurrentLanguage()
        {
            DepartureTimeLanguage data = new DepartureTimeLanguage();

			data.CurrentLanguage = (string)GetDataFromXML(_BaliseLN);

            return data;
        }
        

        public void SaveData(DepartureTimeData data, DepartureTimeLanguage language)
        {
			XDocument document = GetElements();
			document.Root.Element(_BaliseWH).Value = data.WorkingHours.ToString("hh\\:mm");
			document.Root.Element(_BaliseBGC).Value = ColorsHelper.ColorToString(data.BgColor);
			document.Root.Element(_BaliseTC).Value = ColorsHelper.ColorToString(data.TxtColor);
			document.Root.Element(_BaliseLN).Value = language.CurrentLanguage;
			DependencyService.Get<IFileReadWrite>().WriteData(_fileConfigID, document.ToString());
        }
        
        private object GetDataFromXML(string balise)
        {
            IEnumerable<XElement> elements = GetElements().Descendants(balise);
            foreach (XElement element in elements)
                return element.Value;

            return string.Empty;
        }

        private XDocument GetElements()
        {
			string xmlLanguageFile;
			if (!DependencyService.Get<IFileReadWrite>().FileExist(_fileConfigID))
			{
				xmlLanguageFile = EmbeddedResourcesHelper.ReadEmbeddedFile(_resourceConfigID);
				DependencyService.Get<IFileReadWrite>().WriteData(_fileConfigID, xmlLanguageFile);
			}
            
			xmlLanguageFile = DependencyService.Get<IFileReadWrite>().ReadData(_fileConfigID);
            return XDocument.Parse(xmlLanguageFile);           
        }

        public DataProvider()
        {
        }
    }
}
