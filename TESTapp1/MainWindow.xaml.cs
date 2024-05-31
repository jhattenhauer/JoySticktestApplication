using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Threading;
using SharpDX.DirectInput;
//Possible gamecontroller input reading
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Xps;
using System.Security.Cryptography.X509Certificates;

namespace TESTapp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Joystick _joyStick;
        DirectInput directInput {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
            directInput = new DirectInput();
            GetDevices();
            
        }
        private void GetDevices()
        {
            var devices = directInput.GetDevices(DeviceType.Gamepad,
                DeviceEnumerationFlags.AllDevices);
            if (devices.Count == 0)
                devices = directInput.GetDevices(DeviceType.Joystick,
                    DeviceEnumerationFlags.AllDevices);
            UseDevices(devices);
            
        }

        private void UseDevices(IList<DeviceInstance> devices)
        {
            var guid = devices[0].InstanceGuid; // use first one
            _joyStick = new Joystick(directInput, guid);

            _joyStick.Properties.BufferSize = 128; // enable buffer
            _joyStick.Acquire();

            var timer = new DispatcherTimer(); // Timer(onTimer, null, 100);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _joyStick.Poll();
            var data = _joyStick.GetBufferedData();
            foreach (var line in data)
            {
                Title.Text = ($"Offset: {line.Offset} Value: {line.Value}\n");
            }
        }


        //Moving Pointer, mapped to direction keys rn
        private void GoUp(object sender, RoutedEventArgs e)
        {
            if (position.Y > 1)
            {
                position.Y = position.Y - 1;
            }
        }
        private void GoLeft(object sender, RoutedEventArgs e)
        {
            if (position.X > 1)
            {
                position.X = position.X - 1;
            }
        }
        private void GoDown(object sender, RoutedEventArgs e)
        {
            if (position.Y < 140)
            {
                position.Y = position.Y + 1;
            }
        }
        private void GoRight(object sender, RoutedEventArgs e)
        {
            if (position.X < 140)
            {
                position.X = position.X + 1;
            }
        }
        private void GoReset(object sender, RoutedEventArgs e)
        {
            position.X = 70;
            position.Y = 70;
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            if (testing.Background == Brushes.White)
            {
                testing.Background = Brushes.Red;
            }
            else
            {
                testing.Background = Brushes.White;
            }
        }
    }
}