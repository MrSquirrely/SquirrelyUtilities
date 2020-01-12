using System.Windows.Controls;

namespace SquirrelyUtilities.API.Controls {
    /// <summary>
    /// Interaction logic for PageHolder.xaml
    /// </summary>
    public partial class PageHolder {
        public PageHolder() => InitializeComponent();

        public PageHolder(Page pluginMainPage, string pluginName) {
            PageName = pluginName;
            Content = pluginMainPage;
        }

        public string PageName;
    }
}
