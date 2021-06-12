using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BeHealth_eApp.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using BeHealth_eApp.Droid.CustomRenderer;

[assembly: ExportRenderer(typeof(SetDataEntry), typeof(SetDataEntry))]
namespace BeHealth_eApp.Droid.CustomRenderer
{
    public class SetDataRenderer : EntryRenderer
    {
        public SetDataRenderer(Context context) : base(context)
        {

        }


        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }

    }
}