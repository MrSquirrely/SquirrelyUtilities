using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;

namespace SquirrelyUtilities.lang {
    internal class ChangeLang {
        internal static Window MainWindow;
        internal static void ChangeToEnglish() => ChangeLanguage(new CultureInfo("en"));
        internal static void ChangeToGerman() => ChangeLanguage(new CultureInfo("de"));
        private static void ChangeLanguage(CultureInfo cultureInfo) {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
            Debug.WriteLine($"Changing culture to {cultureInfo.Name}");
            //Utilities.ImageListView.Dispatcher.Invoke(() => { Utilities.ImageListView.Items.Refresh(); }, DispatcherPriority.Background);
        }
    }
}
