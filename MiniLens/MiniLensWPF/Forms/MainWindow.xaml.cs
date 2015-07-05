using System;
using System.Diagnostics;
using System.Windows;
using MiniLens;
using MiniLens.Properties;

namespace MiniLensWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public MainWindow()
        {
            KeyboardHook.HookID = KeyboardHook.SetHook(KeyboardHook.Proc);
            Console.WriteLine("Main form has loaded!");
            InitializeComponent();
        }
        #endregion Constructors

        #region Events
        /// <summary>
        /// Full Screenshot button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Fullscreen_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Taking a full screen shot!");
            Screenshot.FullScreenshot();
        }

        /// <summary>
        /// Area Screenshot button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Area_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Taking an area Screenshot!");
            Screenshot.AreaScreenshot();
        }

        /// <summary>
        /// Window Screenshot button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Window_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Taking a window Screenshot!");
            Screenshot.WindowScreenshot();
        }

        /// <summary>
        /// Directory button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Directory_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Opening the default file location for screenshots!");
            Process.Start(Settings.Default.CaptureDirectory);
        }

        /// <summary>
        /// Options button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Options_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Opening the Setting page!");
            Options op = new Options();
            op.ShowDialog();
        }

        /// <summary>
        /// Window Loaded event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Screenshot.DirectoryIntegrityCheck();
        }

        /// <summary>
        /// Window Closing event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            KeyboardHook.Unhook();
        }
        #endregion Events
    }
}
