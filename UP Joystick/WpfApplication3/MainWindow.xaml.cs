using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SharpDX.DirectInput;
using System.Runtime.InteropServices;

namespace WpfApplication3
{
    public partial class MainWindow : Window
    {
        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        public Thread joyThread;
        public delegate void UpdateTextCallback(JoystickState mes);

   

        public bool Initial { get; set; }
        [DllImport("User32.dll", CharSet=CharSet.Auto, CallingConvention=CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        private const int MOUSEEVENTF_LEFT_DOWN = 0x02;
        private const int MOUSEEVENTF_LEFT_UP = 0x04;
        private const int MOUSEEVENTF_RIGHT_DOWN = 0x08;
        private const int MOUSEEVENTF_RIGHT_UP = 0x10;

        public MainWindow()
        {
            InitializeComponent();
            // Loaded += ConnectButton_Click;
            // inkCanvas1.Focus();
 
        }

        void MainForJoystick()
        {

            // Initialize DirectInput
            var directInput = new DirectInput();

            var joystickGuid = Guid.Empty;

            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                joystickGuid = deviceInstance.InstanceGuid;

            // Instantiate the joystick
            var joystick = new Joystick(directInput, joystickGuid);

            // Set BufferSize in order to use buffered data.
            joystick.Properties.BufferSize = 128;

            // Acquire the joystick
            joystick.Acquire();

            while (true)
            {
                var state = joystick.GetCurrentState();

                MyTextBox.Dispatcher.Invoke(new UpdateTextCallback(Update), state);
                
            }

        }

        private void Update(JoystickState mes)
        {
            
            if (Initial == false)
            {
                SetCursorPos(0, 0);
                Initial = true;
            }
            MyTextBox.Text = mes.X.ToString() + " " + mes.Y.ToString();
            MyTextBox.Text = $"x: {mes.X}\r\n";
            MyTextBox.Text += $"x: {mes.Y}\r\n";

            if (mes.Buttons[0])
            {
                DoMouseClick(mes);

                if (Background == Brushes.Blue) Background = Brushes.Red;
                else Background = Brushes.Blue;

                inkCanvas1.CaptureMouse();
            }

            //SetCursorPos((int)(mes.X * 0.01171875), (int)(mes.Y * 0.020843505859375));
            SetCursorPos((int)(mes.X * 0.020843505859375), (int)(mes.Y * 0.01171875));

            //ButtonJoystickClick.Focusable = true;
            //ButtonJoystickClick.Focus();
        }


        private void inkCanvas1_Gesture(object sender, InkCanvasGestureEventArgs e)
        {

        }
        private void Buttonn_Click(object sender, RoutedEventArgs e)
        {
            this.inkCanvas1.Strokes.Clear();


        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            joyThread = new Thread(new ThreadStart(MainForJoystick));
            joyThread.Start();

            //inkCanvas1.Focusable = true;
            //System.Windows.Input.Keyboard.Focus(inkCanvas1);

        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            joyThread.Join();
        }



        public void DoMouseClick(JoystickState mes)
        {

            mouse_event(MOUSEEVENTF_LEFT_DOWN | MOUSEEVENTF_LEFT_UP, (uint)(mes.X * 0.01171875), (uint)(mes.Y * 0.020843505859375), 0, 0);
            //mouse_event(MOUSEEVENTF_LEFT_DOWN, (uint)(mes.X * 0.01171875), (uint)(mes.Y * 0.020843505859375), 0, 0);
        }

        private void ButtonJoystickClick_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonJoystickClick.Content == "notKlik") ButtonJoystickClick.Content = "klik";
            else ButtonJoystickClick.Content = "notKlik";
        }
    }


}
