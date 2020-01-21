using System.Windows.Controls;

namespace SquirrelyUtilities.API.Controls {
    /// <summary>
    /// Interaction logic for PageHolder.xaml
    /// </summary>
    public partial class PageHolder {
        /// <summary>
        /// 
        /// </summary>
        public PageHolder() => InitializeComponent();
        /// <summary>
        /// Initializes a new instance of the <see cref="PageHolder"/> class.
        /// </summary>
        /// <param name="pluginPage">The plugin page.</param>
        public PageHolder(Page pluginPage) {
            PageName = pluginPage.Title;
            Content = pluginPage;
        }
        /// <summary>
        /// The page name
        /// </summary>
        public string PageName;
    }
}
