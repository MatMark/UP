using InTheHand.Net.Bluetooth;
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


namespace Bluetooth
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private BTManager bt = new BTManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            bt.UpdateAdapters();
            ListBoxAdapters.Items.Clear();

            if (bt._btAdapters.Length != 0)
                foreach (var device in bt._btAdapters)
                    ListBoxAdapters.Items.Add(device.Name);
        }

        private void ButtonChoose_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxAdapters.SelectedIndex != -1)
                bt.choosenRadio = bt._btAdapters[ListBoxAdapters.SelectedIndex];
        }

        private void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxAdapters.SelectedIndex != -1)
            {
                int index = ListBoxAdapters.SelectedIndex;
                Console.WriteLine(bt._btAdapters[index].Name);
                BluetoothRadio temp = bt._btAdapters[index];
                MessageBox.Show(
                    "Device Name " + temp.Name + "\n" +
                    "MAC ADRESS: " + temp.LocalAddress + "\n");
            }
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            ListBoxDevices.Items.Clear();
            if (bt.choosenRadio != null)
            {
                bt.FindDevices();
                foreach (var device in bt._bluetoothDevice)
                {
                    ListBoxDevices.Items.Add(device.DeviceName.ToString());
                }
            }
        }

        private void ButtonConnect_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxDevices.SelectedIndex != -1)
            {
                bt.choosenDevice = bt._bluetoothDevice[ListBoxDevices.SelectedIndex];
                bt.ConnectToDevice();
            }
        }

        private void ButtonDeviceInfo_Click(object sender, RoutedEventArgs e)
        {
            int index = ListBoxDevices.SelectedIndex;
            if (bt._bluetoothDevice != null)
                if (bt._bluetoothDevice.Length != 0 && ListBoxDevices.SelectedIndex != -1)
                    MessageBox.Show("Device name: " + bt._bluetoothDevice[index].DeviceName.ToString() + "\n" +
                                    "Device Address: " + bt._bluetoothDevice[index].DeviceAddress.ToString());
        }

        private void ButtonSend_Click(object sender, RoutedEventArgs e)
        {
           // if (bt.choosenDevice != null)
               // bt.SendTempFile();
        }

        private void ButtonChooseFile_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            string fileName;
            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                fileName = openFileDlg.FileName;

                if (bt.choosenDevice != null)
                    bt.SendTempFile(fileName);
            }

            
        }
    }
    
}
