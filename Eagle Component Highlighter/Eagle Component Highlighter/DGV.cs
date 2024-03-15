using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Eagle_Component_Highlighter
{
    public partial class MainWindow : Window
    {
        enum ColumnName { Qty = 0, Value, Device, Package, Parts, Description };

        private void DGVRAWInit()
        {
            DGVRAW.CanUserAddRows = false;
            DGVRAW.CanUserResizeRows = false;
            DGVRAW.CanUserDeleteRows = false; ;
            DGVRAW.AutoGenerateColumns = false;
            DGVRAW.RowHeaderWidth = 0.0;
            DGVRAW.SelectionMode = DataGridSelectionMode.Single;
        }

        private void LoadDataToDGVRAW()
        {
            if(ComponentsRAW.Count > 0)
            {
                DGVRAW.ItemsSource = ComponentsRAW;
                DGVRAW.Items.Refresh();                
            }
        }

        private void ClearDGV(DataGrid dg)
        {
            dg.ItemsSource = null;
            dg.Items.Refresh();
        }

        private void LoadDataToDGVCommand()
        {
            DGVCommand.ItemsSource = ComponentsConverted;
            DGVCommand.Items.Refresh();
        }

        private void DGVCommandInit()
        {
            DGVCommand.CanUserAddRows = false;
            DGVCommand.CanUserResizeRows = false;
            DGVCommand.CanUserDeleteRows = false; ;
            DGVCommand.AutoGenerateColumns = false;
            
            DGVCommand.RowHeaderWidth = 0.0;
            DGVCommand.SelectionMode = DataGridSelectionMode.Single;
        }

        private void ConvertComponentListToCommand()
        {
            foreach(Item i in ComponentsRAW)
            {
                Item component = new Item();
                component.SetQty( i.GetQty() );
                component.SetValue(i.GetValue() );
                component.SetDevice(i.GetDevice());
                component.SetPackage(i.GetPackage());
                component.SetCommand("SHOW " + i.Parts.Replace(",", ""));
                component.SetDescription(i.GetDescription());

                ComponentsConverted.Add(component);
            }
        }

        private void DGVCommand_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (DGVCommand.SelectedItem != null)
            {
                var Value = DGVCommand.SelectedItem as Item;
                TxtCommand.Text = Value.GetCommand();
                if (CbxAutoCopy.IsChecked == true)
                {
                    string command = TxtCommand.Text;
                    CopyToClipboard(command);
                }
            }
        }

    }//eo partial class
}//eo namespace
