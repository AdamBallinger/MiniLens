using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MiniLens;
using MiniLens.Properties;

namespace MiniLensWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            KeyboardHook.HookID = KeyboardHook.SetHook(KeyboardHook.Proc);
            Console.WriteLine("Main form has loaded!");
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Taking a full screen shot!");
            Screenshot.FullScreenshot();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Taking an area Screenshot!");
            Screenshot.AreaScreenshot();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Taking a window Screenshot!");
            Screenshot.WindowScreenshot();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Opening the default file location for screenshots!");
            Process.Start(Settings.Default.CaptureDirectory);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Opening the Setting page!");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Screenshot.DirectoryIntegrityCheck();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            KeyboardHook.Unhook();
        }
    }
}
