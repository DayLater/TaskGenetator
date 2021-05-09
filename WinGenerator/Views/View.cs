﻿using TaskEngine.Views;
using WinGenerator.CustomControls;

namespace WinGenerator.Views
{
    public abstract class View: PercentTableLayoutPanel, IView
    {
        public abstract string Id { get; }
    }
}