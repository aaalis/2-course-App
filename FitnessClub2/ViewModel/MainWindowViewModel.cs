using FitnessClub2.ViewModel;
using FitnessClub2.View;
using FitnessClub2.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitnessClub2.ViewModel
{
    class MainWindowViewModel : BaseViewModel<MainWindowViewModel>
    {
        public DependencyObject MainContentViewModel
        {
            get
            {
                return (DependencyObject)GetValue(MainContentViewModelProperty);
            }
            set
            {
                SetValue(MainContentViewModelProperty, value);
            }
        }

        public static readonly DependencyProperty MainContentViewModelProperty =
           DependencyProperty.Register("MainContentViewModel", typeof(DependencyObject), typeof(MainWindowViewModel), new PropertyMetadata());

        public MainWindowViewModel()
        {
            
            
            MainContentViewModel = null;
        }

        #region buttons
        private Command exitCommand;
        public Command ExitCommand => exitCommand ?? (exitCommand = new Command(obj =>
        {
            Environment.Exit(0);
        }));

        private Command clientsCommand;
        public Command ClientsCommand => clientsCommand ?? (clientsCommand = new Command(obj =>
        {
            MainContentViewModel = ClientViewModel.Instance;
        }));

        private Command branchesCommand;
        public Command BranchesCommand => branchesCommand ?? (branchesCommand = new Command(obj =>
        {
            MainContentViewModel = BranchViewModel.Instance;
        }));

        //private Command employeesCommand;
        //public Command EmployeesCommand => employeesCommand ?? (employeesCommand = new Command(obj =>
        //{
        //    MainContentViewModel = EmployeeViewModel.Instance;
        //}));

        //private Command contractsCommand;
        //public Command ContractsCommand => contractsCommand ?? (contractsCommand = new Command(obj =>
        //{
        //    MainContentViewModel = ContractViewModel.Instance;
        //}));

        private Command passCommand;
        public Command PassCommand => passCommand ?? (passCommand = new Command(obj =>
        {
            MainContentViewModel = PassViewModel.Instance;
        }));

        private Command servicesCommand;
        public Command ServicesCommand => servicesCommand ?? (servicesCommand = new Command(obj =>
        {
            MainContentViewModel = ServiceViewModel.Instance;
        }));

        //private Command tBWorkshiftsCommand;
        //public Command TBWorkshiftsCommand => tBWorkshiftsCommand ?? (tBWorkshiftsCommand = new Command(obj =>
        //{
        //    MainContentViewModel = TBWorkShiftViewModel.Instance;
        //}));

        //private Command tBWorkoutsCommand;
        //public Command TBWorkoutsCommand => tBWorkoutsCommand ?? (tBWorkoutsCommand = new Command(obj =>
        //{
        //    MainContentViewModel = TBWorkoutViewModel.Instance;
        //}));

        #endregion
    }
}

