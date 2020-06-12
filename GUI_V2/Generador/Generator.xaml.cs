using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Markup;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InteractiveDataDisplay.WPF;
using MatlabLib;


namespace Generador
{
    public enum Channel_Name
    {
        Ch_A, Ch_B, Ch_C, Ch_D
    }
    /// <summary>
    /// Interaction logic for Generator.xaml
    /// </summary>
    public partial class Generator : Page
    {
        List<Channel> channels;
        List<StackPanel> propiertiesStack;
        public Generator()
        {
            InitializeComponent();
            varinit();
           
        }

        private void varinit()
        {
            this.channels = new List<Channel>();
            this.propiertiesStack = new List<StackPanel>();
            List<Color> colors = new List<Color>();
            colors.Add(Color.FromArgb(255, 255, 0, 0));
            colors.Add(Color.FromArgb(255, 0, 255, 0));
            colors.Add(Color.FromArgb(226, 0, 0, 255));
            colors.Add(Color.FromArgb(255, 0, 255, 255));
            foreach (Channel_Name channel in (Channel_Name[])Enum.GetValues(typeof(Channel_Name)))
            {
                var i = (int)channel;
                var c = colors[i];
                channels.Add(new Channel(channel, c));
            }
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            //int channel = cmbChannels.SelectedIndex;
            //Function function = (Function)cmbFunctions.SelectedIndex;
            //Points wave = Default_Waveform((Default_Wave_Form)cmbDefaultWaveform.SelectedIndex, float.Parse(boxDefaultFrequency.Text), float.Parse(boxDefaultAmplitude.Text), float.Parse(boxDefaultOffset.Text), boxDefaultInvert.IsChecked == true);
            //this.channels[channel].setWaveform(wave);
        }

        private void BtnAppl_Click(object sender, RoutedEventArgs e)
        {
            int i = cmbChannels.SelectedIndex;
            Points points = channels[i].Gui.GetPoints();
            //Function function = (Function)cmbFunctions.SelectedIndex;
            //Points points = new Points(0);
            //switch (function) {
            //    case Function.Default:
            //        points = defaultFunction();
            //        break;
            //    case Function.AC_Sweep:
            //        points = defaultFunction();
            //        break;
            //    case Function.Burst:
            //        points = defaultFunction();
            //        break;
            //    case Function.User:
            //        points = defaultFunction();
            //        break;
            //}
            this.channels[i].SetWaveForm(points);
            grap();
        }

        private void cmbWave_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            ComboBox box = sender as ComboBox;
            TextBox duty = (TextBox)propiertiesStack[4].Children[1];
            switch ((Default_Wave_Form)box.SelectedIndex)
            {
                case Default_Wave_Form.Sinusoidal:
                    duty.IsEnabled = false;
                    break;
                case Default_Wave_Form.Square:
                    duty.IsEnabled = true;
                    break;
                case Default_Wave_Form.Triangular:
                    duty.IsEnabled = false;
                    break;
                case Default_Wave_Form.Sawtooth:
                    duty.IsEnabled = true;
                    break;
            }
        }

        private void grap()
        {
            GeneratorSeries.Children.Clear();
            foreach (var ch in channels)
            {
                var lg = new LineGraph();
                GeneratorSeries.Children.Add(lg);
                lg.Stroke = new SolidColorBrush(ch.colorBrush);
                lg.Description = String.Format("{0}", ch.name);
                lg.StrokeThickness = 2;
                Points points = Points.cpPoints(ch.GetWaveform(), 3);
                lg.Plot(points.X, points.Y);
            }
        }

        private void cmbChannels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = cmbChannels.SelectedIndex;
            foreach (var channel in channels)
            {
                if (channel.Gui == null) break;
                channel.Gui.Visibility = Visibility.Hidden;
            }
            if (channels[i].Gui == null)
            {
                channels[i].Gui = new FunctionControl();
                this.GridFunction.Children.Add(channels[i].Gui);
                Grid.SetRow(channels[i].Gui, 2);
                Grid.SetColumn(channels[i].Gui, 0);
                Grid.SetColumnSpan(channels[i].Gui, 4);
            }
            channels[i].Gui.Visibility = Visibility.Visible;
        }

        // private Points defaultFunction() {
        //Points wave = new Points(0);
        //float freq, amp, offset, phase, duty;
        //bool inv = false;
        //List<float> parameters = new List<float>();
        //foreach (var child in GridProperties.Children)
        //{
        //    var stackelement = (StackPanel)child;
        //    try
        //    {
        //        var textbox = (TextBox)stackelement.Children[1];
        //        float param = float.TryParse(textbox.Text, out param) ? param : 0;
        //        parameters.Add(param);
        //    }
        //    catch {
        //        try
        //        {
        //            var textbox = (CheckBox)stackelement.Children[1];
        //            inv = textbox.IsChecked == true;
        //        }
        //        catch { 
        //        }
        //    }
        //}

        //amp = parameters[0];
        //freq = parameters[1];
        //phase = parameters[2];
        //offset = parameters[3];
        //duty = parameters[4];

        //if (freq != 0)
        //{
        //    switch ((Default_Wave_Form)cmbWave.SelectedIndex)
        //    {
        //        case Default_Wave_Form.Sinusoidal:
        //            wave = MathFunctions.Sin(amp, freq, offset, inv, phase);
        //            break;
        //        case Default_Wave_Form.Square:
        //            wave = MathFunctions.Square(amp, freq, offset, inv, duty, phase);
        //            break;
        //        case Default_Wave_Form.Triangular:
        //            break;
        //    }
        //}
        //else {
        //    wave = MathFunctions.None();
        //}
        //return wave;

        //}
    }

    public class VisibilityToCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((Visibility)value) == Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }
    }

    static class ExtMethods
    {
        public static T GetCopy<T>(this T element) where T : UIElement
        {
            using (var ms = new MemoryStream())
            {
                XamlWriter.Save(element, ms);
                ms.Seek(0, SeekOrigin.Begin);
                return (T)XamlReader.Load(ms);
            }
        }
    }
}
