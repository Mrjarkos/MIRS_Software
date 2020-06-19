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

namespace Osciloscopio
{
    /// <summary>
    /// Interaction logic for Vertical.xaml
    /// </summary>
    public partial class Vertical : UserControl
    {
        public double VScale;
        public double VPos;

        public Vertical()
        {
            InitializeComponent();
            DataContext = new Project.Theme.ViewModel();
            lblVpos.Text = "Ypos:" + sldVerticalPos.Value.ToString() + "V";
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            btnCreate.Width = this.ActualWidth / 5;
            btnEdite.Width = this.ActualWidth / 5;
            btnDelete.Width = this.ActualWidth / 5;
            sldVerticalPos.Height = (2.5 * this.ActualHeight) / 5;
            sldVerticalPos.Width = (0.8 * this.ActualWidth) / 5;
            cmbChannelSelector.Width = (2.0 * this.ActualWidth) / 5;
            cmbChannelSelector.Height = (0.8 *this.ActualHeight) / 5;
            double radious = Math.Min((0.32 * this.ActualWidth) / 175, (0.32 * this.ActualHeight) / 125);
            dialVScale.LayoutTransform = new ScaleTransform(radious, radious);

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            VScale = Convert.ToDouble(VScaleText.Text);
            lblVScale.Text = "Y Scale:" + VScaleText.Text + "V";
        }

        private void sldVerticalPos_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VPos = Convert.ToDouble(sldVerticalPos.Value);
            lblVpos.Text = "Ypos:" + sldVerticalPos.Value.ToString() + "V";
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Add_EditSeries series = new Add_EditSeries();
            series.ShowDialog();
        }
    }
}
