using Avalonia;
using Avalonia.Markup.Xaml;

namespace HW09
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
