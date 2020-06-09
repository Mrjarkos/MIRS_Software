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

namespace Generador
{
    public struct DefaultFunctionParameters {
        public DefaultFunctionParameters(Default_Wave_Form wave_Form,
                                         float frequency, float amplitude,
                                         float phase, float offset,
                                         float duty, bool invert)
        {
            this.wave_form = wave_Form;
            this.freq = frequency;
            this.Amp = amplitude;
            this.Ph = phase;
            this.Offset = offset;
            this.duty = duty;
            this.Inv = invert;
        }

        public Default_Wave_Form wave_form { get; }
        public float freq { get; }
        public float Amp { get; }
        public float Ph { get; }
        public float Offset { get; }
        public float duty { get; }
        public bool Inv { get; }
    }
    /// <summary>
    /// Interaction logic for DefaultFunction.xaml
    /// </summary>
    public partial class DefaultFunction : UserControl
    {
        public DefaultFunction()
        {
            InitializeComponent();
        }

        public DefaultFunctionParameters GetParameters() {
            float frequency, amplitude, phase, offset, duty;
            bool invert;
            Default_Wave_Form wave_form = (Default_Wave_Form)cmb_WaveForm.SelectedItem;
            frequency = Convert.ToSingle(tbox_Frequency.Text);
            amplitude = Convert.ToSingle(tbox_Amplitude.Text);
            phase = Convert.ToSingle(tbox_Phase.Text);
            offset = Convert.ToSingle(tbox_Offset.Text);
            if (tbox_Duty.IsEnabled)
            {
                duty = Convert.ToSingle(tbox_Duty.Text);
            }
            else {
                duty = 0;
            }

            invert = boxInvert.IsChecked==true ? true : false;
            return new DefaultFunctionParameters(wave_form, frequency, amplitude, phase, offset, duty, invert);
        }

        private void cmb_WaveForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((Default_Wave_Form)cmb_WaveForm.SelectedItem)
            {
                case Default_Wave_Form.Sinusoidal:
                case Default_Wave_Form.Sinus_Rectified:
                case Default_Wave_Form.Triangular:
                    tbox_Duty.IsEnabled = false;
                    break;
                default:
                    tbox_Duty.IsEnabled = true;
                    break;
            }
        }
    }
}
