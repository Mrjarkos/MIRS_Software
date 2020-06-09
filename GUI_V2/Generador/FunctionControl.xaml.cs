﻿using System;
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

    public enum FunctionEnu
    {
        Default, Burst, AC_Sweep, User//, Modulation
    }

    /// <summary>
    /// Interaction logic for Function.xaml
    /// </summary>
    public partial class FunctionControl : UserControl
    {
        DefaultFunction defaultFunction;
        public FunctionControl()
        {
            InitializeComponent();
        }

        private void cmbFunctions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((FunctionEnu)cmbFunctions.SelectedItem)
            {
                case FunctionEnu.Default:
                    if (defaultFunction == null)
                    {
                        defaultFunction = new DefaultFunction();
                        this.MainGrid.Children.Add(defaultFunction);
                        Grid.SetRow(defaultFunction, 1);
                        Grid.SetColumn(defaultFunction, 1);
                        Grid.SetColumnSpan(defaultFunction, 3);
                    }
                    defaultFunction.Visibility = Visibility.Visible;
                    break;
                default:
                    if (defaultFunction != null)
                        defaultFunction.Visibility = Visibility.Hidden;
                    break;
            }
        }
    }
}