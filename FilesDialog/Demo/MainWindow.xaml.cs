using FilesDialog;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFileDialog(object sender, RoutedEventArgs e)
        {
            var filediolog = new OpenFileDialog()
            {
                Title = "Select Files",
                Filter = "JSON (*.json)|*.json|"+"CS (*.cs)|*.cs|" + "TXT (*.txt)|*.txt|" + "All files (*.*)|*.*",
                Multiselect = true,
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (filediolog.ShowDialog() == false)
                return;

            var selectedFiles = filediolog.FileNames;

            ShowFilesStr.ItemsSource = selectedFiles;
        }

        private void OpenFilesDialog(object sender, RoutedEventArgs e)
        {
            var filesdialog = new OpenFilesDialog()
            {
                Title = "Select Files",
                Filter = new string[] { ".json", ".cs", ".txt"},
            };

            if(filesdialog.ShowDialog() == false)
                return;
            ShowFilesStr.ItemsSource = filesdialog.GetFiles();
        }
    }
}
