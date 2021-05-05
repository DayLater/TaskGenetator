using System.Collections.Generic;
using TaskEngine.Views;

namespace WinGenerator.Views
{
    public class GeneratorViews
    {
        private readonly Dictionary<string, View> _generatorViews = new Dictionary<string, View>();
        public void Add(string id, IView generatorView) => _generatorViews[id] = (View) generatorView;
        public View Get(string id) => _generatorViews[id];
    }
}