using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using DepartureTime.Helpers;

namespace DepartureTime.Classes
{
    public class Languages
    {

        private IEnumerable<XElement> labelLanguages;

        public void LoadLanguagesXML(string resourceID)
        {
            if (!string.IsNullOrEmpty(resourceID))
            {
                string xmlLanguageFile = EmbeddedResourcesHelper.ReadEmbeddedFile(resourceID);
                XDocument xMLStream = XDocument.Parse(xmlLanguageFile);
                _availableLanguage = new List<string>();
                labelLanguages = xMLStream.Descendants("Label");

                foreach (XElement language in labelLanguages.Descendants())
                {
                    if (!_availableLanguage.Contains(language.Name.ToString()))
                        _availableLanguage.Add(language.Name.ToString());
                }
            }
        }           

        private List<string> _availableLanguage = null;
        public List<string> AvailableLanguage
        {
            get {return _availableLanguage;}
        }

        public Dictionary<string, string> GetLanguageDic(string Language)
        {
            Dictionary<string, string> createdDic = new Dictionary<string, string>();

            foreach (XElement element in labelLanguages)
            {
                createdDic.Add(element.Attribute("Name").Value,element.Element(Language).Value);
            }

            return createdDic;
        }

        public Languages(string resourceID)
        {
            LoadLanguagesXML(resourceID);
        }

    }
}
