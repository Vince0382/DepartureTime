using System;
using System.Linq;
using CoreGraphics;
using DepartureTime.iOS;
using DepartureTime.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Drawing;
using UIKit;

[assembly:ExportRenderer (typeof(CustomShadowEffects),typeof(CustomShadowEffectsRenderer))]
namespace DepartureTime.iOS
{
	public class CustomShadowEffectsRenderer : FrameRenderer
    {
        //protected override void OnAttached()
		protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            try
            {
				base.OnElementChanged(e);

				if (e.NewElement != e.OldElement)
                {
                    if (e.OldElement != null)
                    {
                        e.OldElement.PropertyChanged -= OnElementPropertyChanged;
                    }
                    if (e.NewElement != null)
                    {
                        e.NewElement.PropertyChanged += OnElementPropertyChanged;
                    }
                }
    
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
			base.OnElementPropertyChanged(sender,e);
            
            var elem = (CustomShadowEffects)Element;
            if (elem != null)
            {
				Layer.BorderWidth = elem.BorderWidth;
				Layer.ShadowColor = elem.ShadowColor.ToCGColor();
				Layer.ShadowOpacity = elem.ShadowOpacity;
				Layer.ShadowRadius = elem.Radius;
				Layer.ShadowOffset = new SizeF(elem.DistanceX, elem.DistanceY);            
            }
        }

    }
}