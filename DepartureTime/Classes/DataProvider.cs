using System;
using System.Collections.Generic;
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
		private const string _BaliseFT = "SelectedFont";
        
        //Get all languages available

		public Languages GetLanguages()
        {
            return new Languages(_resourceLanguageID);
        }


        //Get application data from config file

        public DepartureTimeData GetData()
        {
            DepartureTimeData data = new DepartureTimeData();
			FontTypeConverter fontType = new FontTypeConverter();

			VerifyDocuments();

			data.WorkingHours = TimeSpan.Parse((string)GetDataFromXML(_BaliseWH));
			data.BgColor = ColorsHelper.StringToColor((string)GetDataFromXML(_BaliseBGC));
			data.TxtColor = ColorsHelper.StringToColor((string)GetDataFromXML(_BaliseTC));
			string selectedFont = (string)GetDataFromXML(_BaliseFT);
			if (selectedFont == "Default")
				data.SelectedFont = "";
			else
				data.SelectedFont = selectedFont;
            
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
			document.Root.Element(_BaliseFT).Value = data.SelectedFont;
            

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
			string xmlConfigFile;
            
			xmlConfigFile = DependencyService.Get<IFileReadWrite>().ReadData(_fileConfigID);

            return XDocument.Parse(xmlConfigFile);           
        }
        

        private void VerifyDocuments()
		{
			string embeddedXML;

			embeddedXML = EmbeddedResourcesHelper.ReadEmbeddedFile(_resourceConfigID);

			if (!DependencyService.Get<IFileReadWrite>().FileExist(_fileConfigID))
            {				
				DependencyService.Get<IFileReadWrite>().WriteData(_fileConfigID, embeddedXML);
            }
            else
			{
				string platformXML;
				platformXML = DependencyService.Get<IFileReadWrite>().ReadData(_fileConfigID);

				XDocument embeddedDoc = XDocument.Parse(embeddedXML);
				XDocument platformDoc = XDocument.Parse(platformXML);
				bool updateRequired = false;

                foreach (XElement embeddedElement in embeddedDoc.Root.Elements())
                {
					bool elementFound = false;

					foreach (XElement platformElement in platformDoc.Root.Elements())
					{
						if (platformElement.Name == embeddedElement.Name)
						{
							elementFound = true;
							break;
						}
					}

					if (!elementFound) 
					{
						updateRequired = true;
						platformDoc.Root.Add(new XElement(embeddedElement));
					}
				}

				if (updateRequired)
					DependencyService.Get<IFileReadWrite>().WriteData(_fileConfigID, platformDoc.ToString());
			}
	
		}
        

        public DataProvider()
        {
        }
    }
}
