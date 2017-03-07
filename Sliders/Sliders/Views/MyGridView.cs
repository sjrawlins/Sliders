using System;
using System.Collections.Generic;
using System.Linq;

using iFactr.Core;
using iFactr.Core.Utilities;
using iFactr.UI;
using iFactr.UI.Controls;


namespace Sliders.Views
{
    class MyGridView : GridView<string>
    {
        Thickness spacer = new Thickness(5, 20, 20, 0);
 
        /// <summary>
        /// Called when the view is ready to be rendered.
        /// </summary>
        protected override void OnRender()
        {
            Title = "Data Binding Demo";
            VerticalScrollingEnabled = true;  // in case the view falls off the list

            iApp.Log.Debug("Steve's log message {0}", spacer);
            AddChild(new Label()
            {
                Margin = spacer,
                Text = "Slider [0...100] is the TARGET:",
            });
            var mySlider = new Slider(0, 100, 87)
            {
                MaximumTrackColor = Color.Red,
                MinimumTrackColor = Color.Gray,  
                Margin = spacer,
            };
            AddChild(mySlider);

            AddChild(new Label()
            {
                Margin = spacer,
                Text = "TextBox is the SOURCE:",
            });
            var txtBox = new TextBox()
            {
                Margin = spacer,
                Text = "99",
            };
            AddChild(txtBox);

            // start by Binding the Slider (Target) to TextBox (Source) using the default mode of 1-way to Target
            var sliderBinding = new Binding("Value", "Text")
            {
                Source = txtBox,
                ValueConverter = new SliderValueConverter(),
            };
            mySlider.SetBinding(sliderBinding);

            AddChild(new Label()
            {
                Margin = spacer,
                Text = "Binding Mode: Default is 1-way to Target (T<-S)",
                Font = Font.PreferredHeaderFont,
            });

            // Switches for toggling BindingMode.  It's a 3-way switch presented as 2 switches.
            // When both switches are OFF, it's the default mode (1-way to Target)
            AddChild(new Label() { Margin = spacer, Text = "1-way to Source (T->S)" });
            var switchOneWayToSource = new Switch(false) { Margin = spacer, };
            AddChild(switchOneWayToSource);

            AddChild(new Label() { Margin = spacer, Text = "2-way (both ways T<->S)" });
            var switchTwoWay = new Switch(false) { Margin = spacer, };
            AddChild(switchTwoWay);

            switchOneWayToSource.ValueChanged += (o, e) =>
            {
                if (switchOneWayToSource.Value)
                {
                    sliderBinding.Mode = BindingMode.OneWayToSource;
                    switchTwoWay.Value = false;
                }
                else
                {
                    if (!switchTwoWay.Value)
                    {
                        sliderBinding.Mode = BindingMode.OneWayToTarget;
                    }
                }
            };
            switchTwoWay.ValueChanged += (o, e) =>
            {
                if (switchTwoWay.Value)
                {
                    sliderBinding.Mode = BindingMode.TwoWay;
                    switchOneWayToSource.Value = false;
                }
                else
                {
                    if (!switchOneWayToSource.Value)
                    {
                        sliderBinding.Mode = BindingMode.OneWayToTarget;
                    }

                }
            };
        }

    }

    class SliderValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter)
        {
            double dblSliderValue = 0.0;
            var txtString = value.ToString();
            if (double.TryParse(txtString, out dblSliderValue))
            {
                dblSliderValue = Math.Round(dblSliderValue, 2);
            }
            return (object)dblSliderValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter)
        {
            if (value == null) return string.Empty;
            double dblSliderValue = (double)value;
            return Math.Round(dblSliderValue, 2).ToString();
        }
    }
}
