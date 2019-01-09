using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.Windows;

namespace Bluetooth
{
    class BTManager
    {
        public BluetoothRadio[] _btAdapters;
        public BluetoothClient _client;
        public BluetoothDeviceInfo[] _bluetoothDevice;
        public BluetoothDeviceInfo choosenDevice;
        private BluetoothEndPoint localEndPoint;
        public BluetoothRadio choosenRadio;

        public BTManager()
        {
            choosenRadio = null;
        }

        public void UpdateAdapters()
        {
            _btAdapters = BluetoothRadio.AllRadios;
        }

        public void FindDevices()
        {
            localEndPoint = new BluetoothEndPoint(choosenRadio.LocalAddress, BluetoothService.SerialPort);
            _client = new BluetoothClient(localEndPoint);
            _bluetoothDevice = _client.DiscoverDevices();
        }

        public void ConnectToDevice()
        {
            try
            {
                BluetoothSecurity.PairRequest(choosenDevice.DeviceAddress, "123456");
            }
            catch
            {
                MessageBox.Show("Couldn't pair with" + choosenDevice.DeviceName.ToString());
            }
        }

        public void SendTempFile(string fileName)
        {
            string filePath = fileName;
            var uri = new Uri("obex://" + choosenDevice.DeviceAddress + "/" + filePath);
            ObexWebRequest request = new ObexWebRequest(uri);
            request.ReadFile(filePath);
            ObexWebResponse response = (ObexWebResponse)request.GetResponse();
            response.Close();
        }
    }
}
