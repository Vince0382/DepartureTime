using System.Collections.ObjectModel;

namespace DepartureTime.Interfaces
{
    public interface IFontProvider
    {
		ObservableCollection<string> GetFonts();
    }

}
