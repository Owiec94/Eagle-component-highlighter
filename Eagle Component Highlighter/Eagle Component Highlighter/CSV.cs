using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using Microsoft.Win32;
using System.IO;

namespace Eagle_Component_Highlighter
{
    public partial class MainWindow : Window
    {
        private void LoadCSV()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "csv files(*.csv)|*.csv",
                FileName = ""
            };

            if (ofd.ShowDialog() == true)
            {
                ClearDGV(DGVRAW);
                ClearDGV(DGVCommand);

                ClearList(ComponentsRAW);
                ClearList(ComponentsConverted);

                string fileName = ofd.FileName;     //C:\Users\Desktop\BOM.csv
                var reader = new StreamReader(File.OpenRead(fileName));

                reader.ReadLine(); //avoid header
                while(!reader.EndOfStream)
                {
                    try
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        for(int i = (int)ColumnName.Qty; i < (int)ColumnName.Description; i++) //remove quotation marks from all values ("20")
                        {
                            values[i] = values[i].Replace("\"", "");
                        }

                        Item Element = new Item();
                        Element.SetQty( int.Parse   ( values[(int)ColumnName.Qty]) );
                        Element.SetValue            ( values[(int)ColumnName.Value] );
                        Element.SetDevice           ( values[(int)ColumnName.Device] );
                        Element.SetPackage          ( values[(int)ColumnName.Package] );
                        Element.SetParts            ( values[(int)ColumnName.Parts] );
                        Element.SetDescription      ( values[(int)ColumnName.Description] );

                        ComponentsRAW.Add(Element);
                        
                    }//try

                    catch(Exception exc)
                    {
                        Console.WriteLine(exc);
                    }

                }//while EOF
            }//showdialog true
        }//load csv
    }
}
