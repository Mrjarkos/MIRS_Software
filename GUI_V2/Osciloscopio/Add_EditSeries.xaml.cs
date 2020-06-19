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
using System.Runtime.InteropServices;
using MatlabLib;
using InteractiveDataDisplay.WPF;

namespace Osciloscopio
{
    public enum Atenuacion{
        x1,
        x2,
        x5,
        x10,
        x20,
        x50,
        x100,
        x500,
        x1000
    }

    /// <summary>
    /// Interaction logic for Add_EditSeries.xaml
    /// </summary>
    /// 
    public partial class Add_EditSeries : Window
    {
        LineGraph lg;
        Points points;

        public Add_EditSeries()
        {
            InitializeComponent();
            OscilloscopeSeries.Children.Clear();
            lg = new LineGraph();
            OscilloscopeSeries.Children.Add(lg);
            ColorPicker.SelectedColor = Color.FromRgb(255, 128, 128);
            lg.Stroke = new SolidColorBrush((Color)ColorPicker.SelectedColor);
            cmbBorderThickness.Value = 2;
            lg.StrokeThickness = cmbBorderThickness.Value;
            points = MatlabLib.BasicMathFunctions.Sin(1, 1, 0, false, 0);
            lg.Plot(points.X, points.Y);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbBorderThickness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lg.StrokeThickness = cmbBorderThickness.Value;
        }

        private void ColorPicker1_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            lg.Stroke = new SolidColorBrush((Color)ColorPicker.SelectedColor);
        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbxInvert_Click(object sender, RoutedEventArgs e)
        {
            points = MatlabLib.BasicMathFunctions.Sin(1, 1, 0, cbxInvert.IsChecked == true ? true : false, 0);
            lg.Plot(points.X, points.Y);
        }
    } 
}
