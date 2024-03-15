using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;

namespace Eagle_Component_Highlighter
{
  
    public class Item
    {
        public int Qty { get; set; }        //need public for DataSource in DGV, (private: not found binding)
        public String Value { get; set; }
        public String Device { get; set; }
        public String Package { get; set; }
        public String Parts { get; set; }
        public String Description { get; set; }
        public String Command { get; set; } //field for prepared command ie. SHOW C1 C3 C5

        public Item()
        {
            Qty = 0;
            Value = Device = Package = Parts = Description = "";
        }

        #region setters

        public void SetQty(int _Qty)
        {
            this.Qty = _Qty;
        }

        public void SetValue(String _Value)
        {
            this.Value = _Value;
        }

        public void SetDevice(String _Device)
        {
            this.Device = _Device;
        }

        public void SetPackage(String _Package)
        {
            this.Package = _Package;
        }

        public void SetParts(String _Parts)
        {
            this.Parts = _Parts;
        }

        public void SetDescription(String _Description)
        {
            this.Description = _Description;
        }

        public void SetCommand(String _Command)
        {
            this.Command = _Command;
        }
        #endregion

        #region getters
        public int GetQty()
        {
            return this.Qty;
        }

        public String GetValue()
        {
            return this.Value;
        }

        public String GetDevice()
        {
            return this.Device;
        }

        public String GetPackage()
        {
            return this.Package;
        }

        public String GetParts()
        {
            return this.Parts;
        }

        public String GetDescription()
        {
            return this.Description;
        }

        public String GetCommand()
        {
            return this.Command;
        }
        #endregion
    }

    public partial class MainWindow : Window
    {
        private void ClearList(List<Item> list)
        {
            list.Clear();
        }
    }
}
