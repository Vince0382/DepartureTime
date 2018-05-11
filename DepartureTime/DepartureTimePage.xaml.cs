using Xamarin.Forms;
using DepartureTime.ViewModels;
using System.Diagnostics;

namespace DepartureTime
{
    public partial class DepartureTimePage : ContentPage
    {
        DepartureTimeVM _vm;

        public void Handle_PositionSelected(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
        {
            Debug.WriteLine("Position " + e.NewValue + " selected.");
        }

        public void Handle_Scrolled(object sender, CarouselView.FormsPlugin.Abstractions.ScrolledEventArgs e)
        {
            Debug.WriteLine("Scrolled to " + e.NewValue + " percent.");
            Debug.WriteLine("Direction = " + e.Direction);
        }

        int _angleToRotate = 0;

        async void InitiateRotation(object sender, System.EventArgs e)
        {
            _angleToRotate += 90;
            await HomeLayout.RotateYTo(_angleToRotate, 250);
            _vm.InvertColor.Execute(null);
            _angleToRotate -= 90;
            await HomeLayout.RotateYTo(_angleToRotate, 250);
        }

        public DepartureTimePage(DepartureTimeVM vm)
        {
            InitializeComponent();
            _vm = vm;
            BindingContext = _vm;
        }
    }


}
