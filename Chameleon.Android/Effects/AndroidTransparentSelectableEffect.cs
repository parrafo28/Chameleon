﻿using System;
using System.Linq;
using Android.Util;
using Chameleon.Android.Effects;
using Chameleon.Core.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Chameleon")]
[assembly: ExportEffect(typeof(AndroidTransparentSelectableEffect), nameof(TransparentSelectableEffect))]
namespace Chameleon.Android.Effects
{
    public class AndroidTransparentSelectableEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var effect = (TransparentSelectableEffect)Element.Effects.FirstOrDefault(e => e is TransparentSelectableEffect);
                int resid = 0;
                if (effect != null && effect.Borderless)
                    resid = global::Android.Resource.Attribute.SelectableItemBackgroundBorderless;
                else
                    resid = global::Android.Resource.Attribute.SelectableItemBackground;

                var value = new TypedValue();
                global::Android.App.Application.Context.Theme.ResolveAttribute(resid, value, true);
                if (Control != null)
                    Control.SetBackgroundResource(value.ResourceId);
                //else if (Container != null)
                //    Container.Foreground = ContextCompat.GetDrawable(Container.Context, value.ResourceId); // SetBackgroundResource(value.ResourceId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
