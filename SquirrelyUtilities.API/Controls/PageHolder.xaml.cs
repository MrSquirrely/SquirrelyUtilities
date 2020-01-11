using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SquirrelyUtilities.API.Controls {
    /// <summary>
    /// Interaction logic for PageHolder.xaml
    /// </summary>
    public partial class PageHolder : UserControl {
        public PageHolder() {
            InitializeComponent();
        }

        public PageHolder(Page pluginMainPage, string pluginName) {
            PageName = pluginName;
            Content = pluginMainPage;
        }

        public string PageName;
    }
}
