using System;
using System.Linq;
using Android.Widget;
using Android.Content;
using DepartureTime.CustomControls;
using DepartureTime.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;

[assembly:ExportRenderer (typeof(CustomShadowEffects), typeof(CustomShadowEffectsRenderer))]
namespace DepartureTime.Droid
{

	public class CustomShadowEffectsRenderer : VisualElementRenderer<CustomShadowEffects>
    {
        
		public CustomShadowEffectsRenderer(Context context) : base(context)
        {
        }
        
		protected override void OnElementChanged(ElementChangedEventArgs<CustomShadowEffects> e)
        {
			base.OnElementChanged(e);
            Invalidate();         
        }
                   
		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == CustomShadowEffects.RadiusProperty.PropertyName)
            {
                Invalidate();
            }
        }
                      
				

        public override void Draw(Canvas canvas)
        {
			base.Draw(canvas);

            Paint myPaint = new Paint();
			var effect = Element as CustomShadowEffects;
			var path = new Path();
			Path.Direction direction = Path.Direction.Cw;
				
            float radius = effect.Radius;
            float distanceX = effect.DistanceX;
            float distanceY = effect.DistanceY;

            Android.Graphics.Color color = effect.ShadowColor.ToAndroid();

            myPaint.SetStyle(Paint.Style.Stroke);

            myPaint.SetShadowLayer(radius, distanceX, distanceY, color);

			RectF rectF = new RectF(0, 0, Width, Height);
                             
			path.AddRoundRect(rectF, 10, 10, direction);
            
            myPaint.Color = color;
            canvas.DrawPath(path, myPaint);
        }
       
 
	}

}