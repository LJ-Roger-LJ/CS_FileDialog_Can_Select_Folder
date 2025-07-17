using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace FilesDialog
{
    /// <summary>
    /// OpenFilesDialog.xaml 的交互逻辑
    /// </summary>
    public partial class OpenFilesDialog : Window
    {

        public string[] Filter { get; set; }
        public OpenFilesDialog()
        {
            InitializeComponent();
        }

        public new bool? ShowDialog()
        {
            Filters.ItemsSource = Filter;
            return base.ShowDialog();
        }

        private void selectPath(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog()
            {
                Multiselect = false,
                IsFolderPicker = true,
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                selectpath.Text = dialog.FileName;
            }
            this.Activate();
        }

        private void Okbtn(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        public string[] GetFiles()
        {
            HashSet<string> files = new HashSet<string>();
            if (string.IsNullOrEmpty(selectpath.Text) || !Directory.Exists(selectpath.Text))
                return files.ToArray();
            var selectedFilter = (string)Filters.SelectedItem;
            GetFilesInDir(files, selectpath.Text, selectedFilter);
            return files.ToArray();
        }

        private void GetFilesInDir(HashSet<string> files, string dirOrfile,string filter)
        {
            
            foreach (var file in Directory.GetFiles(dirOrfile).Where(file => file.EndsWith(filter)))
            {
                files.Add(file);
            }
            foreach (var path in Directory.GetDirectories(dirOrfile))
            {
                GetFilesInDir(files, path, filter);
            }

        }

    }
}
