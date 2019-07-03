﻿using System.ComponentModel;
using Plugin.SharedTransitions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName(Transition.ResolutionGroupName)]
[assembly: ExportEffect(typeof(Plugin.SharedTransitions.Platforms.iOS.TransitionEffect), Transition.EffectName)]

namespace Plugin.SharedTransitions.Platforms.iOS
{
    public class TransitionEffect : PlatformEffect
    {

        protected override void OnAttached()
        {
            UpdateTag();
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args.PropertyName == Transition.TagProperty.PropertyName ||
                args.PropertyName == Transition.TagGroupProperty.PropertyName)
                UpdateTag();

            base.OnElementPropertyChanged(args);
        }

        void UpdateTag()
        {
            if (Element is View element)
            {
                if (Control != null)
                {
                    Control.Tag = Transition.RegisterTagInStack(element);
                } 
                else if (Container != null)
                {
                    Container.Tag = Transition.RegisterTagInStack(element);
                }
            }

        }
    }
}
