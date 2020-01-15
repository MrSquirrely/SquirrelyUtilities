using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HandyControl.Data;
using SquirrelyUtilities.API;
using SquirrelyUtilities.API.Controls;
using TabItem = HandyControl.Controls.TabItem;

namespace SquirrelyUtilities.Views {
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow {
        public SettingsWindow() {
            InitializeComponent();
            foreach(TabItem tab in Reference.SettingsPageList.Select(holder => new TabItem() { Content = new Frame() { Content = holder.Content }, Header = holder.PageName })) {
                SettingsTab.Items.Add(tab);
            }
        }

        //Bug: This isn't working like it is supposed to. I think Handy Controls don't have everything skinned for dark mode.
        private void ButtonSkins_OnClick(object sender, RoutedEventArgs e) {
            //if(!(e.OriginalSource is Button button) || !(button.Tag is SkinType tag)) return;
            //((App)Application.Current).UpdateSkin(tag);
        }
    }
}
