using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DepartureTime.CustomControls;
using DepartureTime.Droid;

[assembly:ExportRenderer(typeof(CustomTableView), typeof(CustomTableViewRenderer))]
namespace DepartureTime.Droid
{
    public class CustomTableViewRenderer : TableViewRenderer
    {

        public CustomTableViewRenderer(Android.Content.Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            var listView = Control as global::Android.Widget.ListView;
            listView.DividerHeight = 0;
        }
    }
}
