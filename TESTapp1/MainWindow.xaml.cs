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



//Possible gamecontroller input reading
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using System.Windows.Xps;
using System.Security.Cryptography.X509Certificates;
using SharpDX.XInput;

namespace TESTapp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Xinput logif
            var controller = new Controller(UserIndex.One);
            if (controller.IsConnected)
            {
                Gamepad gamepad = controller.GetState().Gamepad;
                Console.WriteLine(gamepad.ToString());
            }
        }
        

        //Moving Pointer, mapped to direction keys rn
        private void GoUp(object sender, RoutedEventArgs e)
        {
            if (position.Y > 1)
            {
                position.Y = position.Y--;
            }
        }
        private void GoLeft(object sender, RoutedEventArgs e)
        {
            if (position.X > 1)
            {
                position.X = position.X--;
            }
        }
        private void GoDown(object sender, RoutedEventArgs e)
        {
            if (position.Y < 140)
            {
                position.Y = position.Y++;
            }
        }
        private void GoRight(object sender, RoutedEventArgs e)
        {
            if (position.X < 140)
            {
                position.X = position.X++;
            }
        }
        private void GoReset(object sender, RoutedEventArgs e)
        {
            position.X = 70;
            position.Y = 70;
        }
    }
}