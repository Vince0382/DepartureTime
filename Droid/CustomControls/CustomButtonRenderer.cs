using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DepartureTime.Droid;
using Android.Content;
using Android.Graphics;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRenderer))]
namespace DepartureTime.Droid
{
	public class CustomButtonRenderer : ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context)
        {
        }

		public static void Init() { }
        
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			Control.SetTypeface(TTFToFontHelper.GetTypeFaceFromFile(Element.FontFamily), TypefaceStyle.Normal);
                
		}
	}
}
