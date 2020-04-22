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
using InteractiveDataDisplay.WPF;


namespace Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    

    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
        InitializeComponent();
            var_init();
            double[] x = new double[200];
            for (int i = 0; i < x.Length; i++)
                x[i] = 3.1415 * i / (x.Length - 1);

            for (int i = 0; i < 25; i++)
            {
                var lg = new LineGraph();
                GeneratorSeries.Children.Add(lg);
                lg.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, (byte)(i * 10), 0));
                lg.Description = String.Format("Data series {0}", i + 1);
                lg.StrokeThickness = 2;
                lg.Plot(x, x.Select(v => Math.Sin(v + i / 10.0)).ToArray());
            }
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            GridHome.Visibility = Visibility.Visible;
            GridDSPCOM.Visibility = Visibility.Hidden;
            GridSignalGen.Visibility = Visibility.Hidden;
            GridOscilloscope.Visibility = Visibility.Hidden;
            GridSignalProc.Visibility = Visibility.Hidden;
        }

        private void BtnDSPcon_Click(object sender, RoutedEventArgs e)
        {
            GridHome.Visibility = Visibility.Hidden;
            GridDSPCOM.Visibility = Visibility.Visible;
            GridSignalGen.Visibility = Visibility.Hidden;
            GridOscilloscope.Visibility = Visibility.Hidden;
            GridSignalProc.Visibility = Visibility.Hidden;
        }

        private void BtnSigGen_Click(object sender, RoutedEventArgs e)
        {
            GridHome.Visibility = Visibility.Hidden;
            GridDSPCOM.Visibility = Visibility.Hidden;
            GridSignalGen.Visibility = Visibility.Visible;
            GridOscilloscope.Visibility = Visibility.Hidden;
            GridSignalProc.Visibility = Visibility.Hidden;
        }

        private void BtnOsc_Click(object sender, RoutedEventArgs e)
        {
            GridHome.Visibility = Visibility.Hidden;
            GridDSPCOM.Visibility = Visibility.Hidden;
            GridSignalGen.Visibility = Visibility.Hidden;
            GridOscilloscope.Visibility = Visibility.Visible;
            GridSignalProc.Visibility = Visibility.Hidden;
        }

        private void BtnSigPro_Click(object sender, RoutedEventArgs e)
        {
            GridHome.Visibility = Visibility.Hidden;
            GridDSPCOM.Visibility = Visibility.Hidden;
            GridSignalGen.Visibility = Visibility.Hidden;
            GridOscilloscope.Visibility = Visibility.Hidden;
            GridSignalProc.Visibility = Visibility.Visible;
        }

        private void cmbFunctions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbFunctions.SelectedIndex)
            {
                case (int)Function.Default: 
                    GridDefault.Visibility = Visibility.Visible;
                    break;
                default:
                    GridDefault.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void var_init() {
            boxAmplitude.Text = "1E3";
            boxAmplitude.Text = "1E3";
        }
    }
}
