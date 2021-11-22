using FitnessClub2.ViewModel;
using System;
using System.Collections.Generic;
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

namespace FitnessClub2.View
{
    /// <summary>
    /// Логика взаимодействия для ServiceControl.xaml
    /// </summary>
    public partial class ServiceControl : UserControl
    {
        public ServiceControl()
        {
            InitializeComponent();

            DataContext = ServiceViewModel.Instance;
        }
    }
}
