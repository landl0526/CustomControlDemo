using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomControlDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomControl : ContentView
	{
        public ParameterType Type
        {
            set { SetValue(TypeProperty, value); }
            get { return (ParameterType)GetValue(TypeProperty); }
        }
        public static readonly BindableProperty TypeProperty = BindableProperty.Create(nameof(Type), 
                                                                                       typeof(ParameterType), 
                                                                                       typeof(CustomControl),
                                                                                       defaultValue: ParameterType.SignedInt,
                                                                                       propertyChanged: (bindableObject, oldValue, newValue) =>
                                                                                       {
                                                                                           bool isSliderVisible = false;
                                                                                           bool isSwitchVisible = false;
                                                                                           bool isStepperVisible = false;
                                                                                           if ((ParameterType)newValue == ParameterType.SignedInt)
                                                                                           {
                                                                                               isSliderVisible = true;
                                                                                               isSwitchVisible = false;
                                                                                               isStepperVisible = false;
                                                                                           }
                                                                                           else if ((ParameterType)newValue == ParameterType.Boolean)
                                                                                           {
                                                                                               isSliderVisible = false;
                                                                                               isSwitchVisible = true;
                                                                                               isStepperVisible = false;
                                                                                           }
                                                                                           else
                                                                                           {
                                                                                               isSliderVisible = false;
                                                                                               isSwitchVisible = false;
                                                                                               isStepperVisible = true;
                                                                                           }
                                                                                           ((CustomControl)bindableObject).MySlider.IsVisible = isSliderVisible;
                                                                                           ((CustomControl)bindableObject).MySwitch.IsVisible = isSwitchVisible;
                                                                                           ((CustomControl)bindableObject).MyStepper.IsVisible = isStepperVisible;
                                                                                       });

        public CustomControl ()
		{
			InitializeComponent ();
		}
	}

    public enum ParameterType
    {
        SignedInt,
        Boolean,
        Stepped,
    }
}