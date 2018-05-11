using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using DepartureTime.iOS;
using Foundation;
using DepartureTime.CustomControls;
                       
[assembly: ExportRenderer(typeof(CustomViewCell), typeof(CustomViewCellRenderer))]
namespace DepartureTime.iOS
{
    public class CustomViewCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            var view = item as CustomViewCell;
            cell.BackgroundView = new UIView
            {
                BackgroundColor = view.BackgroundColor.ToUIColor(),
            };

            return cell;
        }

    }
}
