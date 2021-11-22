using FitnessClub2.ViewModel.Cards;
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

namespace FitnessClub2.View.Cards
{
    /// <summary>
    /// Логика взаимодействия для PassCardControl.xaml
    /// </summary>
    public partial class PassCardControl : UserControl
    {
        public PassCardControl()
        {
            InitializeComponent();

            DataContext = PassCardViewModel.Instance;
        }
    }
}
