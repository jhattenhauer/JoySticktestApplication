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

/* Possible gamecontroller input reading
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using SharpDX.XInput;
*/

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
        }


        //Moving Pointer, mapped to number keys rn
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
    }
}