using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace HW09.Controls
{
    public class ContactTemplate : UserControl
    {
        public ContactTemplate()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
