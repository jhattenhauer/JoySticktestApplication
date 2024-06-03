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
using System.IO;
using System.Windows.Threading;
using SharpDX.DirectInput;
//Possible gamecontroller input reading
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Xps;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace TESTapp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*int MaxValX = 0;
        int MaxValY = 0;
        int MinValX = 600000;
        int MinValY = 600000;*/

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
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Start();
        }
        
        private void timer_Tick(object sender, EventArgs e)
        {
            var _state = _joyStick.GetCurrentState();
            _joyStick.Poll();
            Trace.WriteLine(_state.ToString());

            var data = _joyStick.GetBufferedData();
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(docPath, "WriteLines.txt")))
            outputFile.WriteLine(_state);
            
            foreach (var line in data)
            {
                if (line.Offset == JoystickOffset.X && line.Value > 35000 && position.X > 1)
                {
                    position.X = position.X - 0.1;
                }
                if (line.Offset == JoystickOffset.X && line.Value < 30000 && position.X < 140)
                {
                    position.X = position.X + 0.1;
                }
                if (line.Offset == JoystickOffset.Y && line.Value > 35000 && position.Y > 1)
                {
                    position.Y = position.Y - 0.1;
                }
                if (line.Offset == JoystickOffset.Y && line.Value < 30000 && position.Y < 140)
                {
                    position.Y = position.Y + 0.1;
                }

                for (int i = 0; i < _state.Buttons.Length; i++)
                {
                    if (_state.Buttons[i] == true)
                    {
                        switch (i)
                        {
                            case 0:
                                Button1.Background = Brushes.Red;
                                break;
                            case 1:
                                Button2.Background = Brushes.Red;
                                break;
                            case 2:
                                Button3.Background = Brushes.Red;
                                break;
                            case 3:
                                Button4.Background = Brushes.Red;
                                break;
                            case 4:
                                Button5.Background = Brushes.Red;
                                break;
                            case 5:
                                Button6.Background = Brushes.Red;
                                break;
                            case 6:
                                Button7.Background = Brushes.Red;
                                break;
                            case 7:
                                Button8.Background = Brushes.Red;
                                break;
                            case 8:
                                position.Y = 70;
                                position.X = 70;
                                break;
                        }
                    }
                    if (_state.Buttons[i] == false)
                    {
                        switch (i)
                        {
                            case 0:
                                Button1.Background = Brushes.White;
                                break;
                            case 1:
                                Button2.Background = Brushes.White;
                                break;
                            case 2:
                                Button3.Background = Brushes.White;
                                break;
                            case 3:
                                Button4.Background = Brushes.White;
                                break;
                            case 4:
                                Button5.Background = Brushes.White;
                                break;
                            case 5:
                                Button6.Background = Brushes.White;
                                break;
                            case 6:
                                Button7.Background = Brushes.White;
                                break;
                            case 7:
                                Button8.Background = Brushes.White;
                                break;
                        }
                    }
                }
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            position.Y = 70;
            position.X = 70;
        }
    }
}