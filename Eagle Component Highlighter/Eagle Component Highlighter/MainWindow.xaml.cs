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

namespace Eagle_Component_Highlighter
{
    public partial class MainWindow : Window
    {
        public List<Item> ComponentsRAW = new List<Item>();
        public List<Item> ComponentsConverted = new List<Item>();

        public MainWindow()
        {
            InitializeComponent();
            DGVRAWInit();
            DGVCommandInit();
        }

        private void BtnLoadBOM_Click(object sender, RoutedEventArgs e)
        {    
            LoadCSV();
            LoadDataToDGVRAW();
            ConvertComponentListToCommand();
            LoadDataToDGVCommand();
        }

        private void BtnCopy_Click(object sender, RoutedEventArgs e)
        {
            string command = TxtCommand.Text;

            CopyToClipboard(command);
        }

        private void CopyToClipboard(string _textToCopy)
        {
            Clipboard.SetText(_textToCopy);
        }
    }
}
