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
using Osciloscopio;
using Generador;
using MatlabLib;


namespace Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        Page inicio;
        //Page conexion;
        Page generador;
        Page osciloscopio;
        //Page procesamiento;
        //Page Ayuda;

        public MainWindow()
        {
            InitializeComponent();
            BasicMathFunctions.Inicializar();
            PageContaint.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            inicio = new Main.Home();
            PageContaint.Content = inicio;
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            if (inicio == null)
            {
                inicio = new Main.Home();
            }
            PageContaint.Content = inicio;
        }

        private void BtnDSPcon_Click(object sender, RoutedEventArgs e)
        {
            //this.graphic.Changepage(GridDSPCOM);
        }

        private void BtnSigGen_Click(object sender, RoutedEventArgs e)
        {
            if (generador == null)
            {
                generador = new Generador.Generator();
            }
            PageContaint.Content = generador;
        }

        private void BtnOsc_Click(object sender, RoutedEventArgs e)
        {
            if (osciloscopio == null) {
                osciloscopio = new Osciloscopio.Oscilloscope();
            }
            PageContaint.Content = osciloscopio;
        }

        private void BtnSigPro_Click(object sender, RoutedEventArgs e)
        {
            //this.graphic.Changepage(GridSignalProc);
        }

        
    }

    
}
