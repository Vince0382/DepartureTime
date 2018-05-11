using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using DepartureTime.iOS;
using DepartureTime.CustomControls;
using UIKit;
using CoreGraphics;

[assembly: ExportRenderer(typeof(CustomTableView), typeof(CustomTableViewRenderer))]
namespace DepartureTime.iOS
{
    public class CustomTableViewRenderer : TableViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            var tableView = Control as UITableView;
            tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
        }
    }
}
