using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using System.Xml.Linq;
using System.Xml;


namespace DepartureTime.Helpers
{
	public static class EmbeddedResourcesHelper
    {
        public static string ReadEmbeddedFile(string resourceID)
        {
			var assembly = IntrospectionExtensions.GetTypeInfo(typeof(EmbeddedResourcesHelper)).Assembly;
            Stream stream = assembly.GetManifestResourceStream(resourceID);
           
            string text = "";
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            return text;         
        }
    }
}
