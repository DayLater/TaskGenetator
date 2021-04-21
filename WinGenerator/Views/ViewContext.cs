﻿using System.Runtime.Remoting.Messaging;
using TaskEngine.Contexts;
using TaskEngine.Views;
using WinGenerator.Views.GeneratorsViews;

namespace WinGenerator.Views
{
    public class ViewContext: IViewContext
    {
        public IVariantsCharacteristicPropertyGeneratorView VariantsCharacteristicPropertyGeneratorView { get; }
        public IView Default { get; }

        public ViewContext()
        {
            VariantsCharacteristicPropertyGeneratorView = new TestableCharacteristicPropertyGeneratorView(4);
            Default = new EmptyView();
        }
    }
}