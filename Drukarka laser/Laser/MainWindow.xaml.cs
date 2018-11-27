using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Drawing.Printing;



namespace Laser
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void buttonPrint_Click(object sender, RoutedEventArgs e)
        {
            Print();
        }

        public bool Print()
        {
            string path = @"C:\Users\lab\Documents\Visual Studio 2013\Projects\file";
            FileStream file = File.Create(path);
            StreamWriter writer = new StreamWriter(file);

            //************************************

            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA"); // newline
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");
            writer.WriteLine("\xA");

            //************************************


            if (textBoxPrint.Text.Equals("") || String.IsNullOrWhiteSpace(textBoxPrint.Text) || String.IsNullOrEmpty(textBoxPrint.Text))
                return false;

            string font = "218";

            // (string)((ComboBoxItem)comboBoxFont.SelectedItem).Content
            if (comboBoxFont.SelectedItem != null || comboBoxFont.SelectedItem == "")
            {
                if ((string)((ComboBoxItem)comboBoxFont.SelectedItem).Content == "Arial")
                    font = "218";
                else if ((string)((ComboBoxItem)comboBoxFont.SelectedItem).Content == "TimesNewRoman")
                    font = "517";
                else if ((string)((ComboBoxItem)comboBoxFont.SelectedItem).Content == "CG")
                    font = "4101";
            }

            if (comboBoxSize.SelectedItem != null || comboBoxSize.SelectedItem == "")
            {
                    writer.WriteLine("\x1B" + "(s1p" + (string)((ComboBoxItem)comboBoxSize.SelectedItem).Content + "v0s0b" + font +"T");
            }



            // FontWybieranyZComboBoxa

            //if (comboBoxSize.SelectedItem != null || comboBoxSize.SelectedItem == "")
            //{
            //    if (comboBoxSize.SelectedItem == "Big")
            //        writer.WriteLine("\x1B" + "(s30V");
            //    else if (comboBoxSize.SelectedItem == "Medium")
            //        writer.WriteLine("\x1B" + "(s6H ");
            //    else if (comboBoxSize.SelectedItem == "Small")
            //        writer.WriteLine("\x1B" + "(s9H ");
            //}

            if ((bool)checkBoxBold.IsChecked)
                writer.WriteLine("\x1B" + "(s3B"); // bold

            if ((bool)checkBoxUnderline.IsChecked)
                writer.WriteLine("\x1B" + "&d0D"); // underline

            if ((bool)checkBoxItalic.IsChecked)
                writer.WriteLine("\x1B" + "(s1S");

            //if((bool)checkBoxCGFont.IsChecked)
            //    writer.WriteLine("\x1B" + "(s1p12v0s0b4101T");


            writer.WriteLine(textBoxPrint.Text);
            writer.WriteLine("\x1B" + "E"); // reset
            writer.Close();

            File.Copy(path, "LPT3");
            return true;
        }
    }
}
