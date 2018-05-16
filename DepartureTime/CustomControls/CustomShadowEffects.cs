using System;
using Xamarin.Forms;

namespace DepartureTime.CustomControls
{
	public class CustomShadowEffects : Frame
    {
        
		public static readonly BindableProperty RadiusProperty =
                       BindableProperty.Create(propertyName: nameof(Radius),
                                               returnType: typeof(float),
                                               declaringType: typeof(float),
			                                   defaultValue: 2.0f);

		public static readonly BindableProperty ShadowColorProperty =
                       BindableProperty.Create(propertyName: nameof(ShadowColor),
                                               returnType: typeof(Color),
			                                   declaringType: typeof(Color),
                                               defaultValue: Color.White);

		public static readonly BindableProperty DistanceXProperty =
                       BindableProperty.Create(propertyName: nameof(DistanceX),
                                               returnType: typeof(float),
                                               declaringType: typeof(float),
                                               defaultValue: 0f);

		public static readonly BindableProperty DistanceYProperty =
                       BindableProperty.Create(propertyName: nameof(DistanceY),
                                               returnType: typeof(float),
                                               declaringType: typeof(float),
                                               defaultValue: 0f);
		
		public static readonly BindableProperty BorderWidthProperty =
               BindableProperty.Create(propertyName: nameof(BorderWidth),
                                       returnType: typeof(float),
                                       declaringType: typeof(float),
			                           defaultValue: 0f);
		
		public static readonly BindableProperty ShadowOpacityProperty =
               BindableProperty.Create(propertyName: nameof(ShadowOpacity),
                                       returnType: typeof(float),
                                       declaringType: typeof(float),
			                           defaultValue: 0.6f);

		public float Radius 
		{
            get => (float)GetValue(RadiusProperty);
			set => SetValue(RadiusProperty, value);
        }

		public Color ShadowColor
		{
			get => (Color)GetValue(ShadowColorProperty);
			set => SetValue(ShadowColorProperty, value);
		}
        
        public float DistanceX 
		{
			get => (float)GetValue(DistanceXProperty);
			set => SetValue(DistanceXProperty, value);
        }

        public float DistanceY 
		{
			get => (float)GetValue(DistanceYProperty);
			set => SetValue(DistanceYProperty, value);
        }

		public float BorderWidth
        {
			get => (float)GetValue(BorderWidthProperty);
			set => SetValue(BorderWidthProperty, value);
        }

        public float ShadowOpacity
        {
			get => (float)GetValue(ShadowOpacityProperty);
			set => SetValue(ShadowOpacityProperty, value);
        }

		public CustomShadowEffects()
        {
        }
    }
}
