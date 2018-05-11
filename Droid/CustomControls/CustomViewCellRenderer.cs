using System;
using System.ComponentModel;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.App;
using Android.Runtime;
using Android.Views;
using Android.Content;
using DepartureTime.Droid;
using DepartureTime.CustomControls;

[assembly: ExportRenderer(typeof(CustomViewCell), typeof(CustomViewCellRenderer))]
namespace DepartureTime.Droid
                       
{
    public class CustomViewCellRenderer : ViewCellRenderer
    {

        private Android.Views.View _cellCore;

        protected new Android.Views.View GetCellCore(Cell item,
                                                          Android.Views.View convertView,
                                                          ViewGroup parent,
                                                          Context context)
        {
            _cellCore = base.GetCellCore(item, convertView, parent, context);
            return _cellCore;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnCellPropertyChanged(sender, args);
            var extendedViewCell = sender as CustomViewCell;
            _cellCore.SetBackgroundColor(extendedViewCell.BackgroundColor.ToAndroid());
        

        }
    }

}