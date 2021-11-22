using FitnessClub2.Model.Classes;
using FitnessClub2.ViewModel.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessClub2.ViewModel.Cards
{
    class BranchCardViewModel : BaseViewModel<BranchCardViewModel>
    {
        #region Properties

        private Branch branch;
        public Branch Branch
        {
            get { return branch; }
            set
            {
                branch = value;
                OnPropertyChanged();
            }
        }

        private string nameTextBox;
        public string NameTextBox
        {
            get { return nameTextBox; }
            set
            {
                nameTextBox = value;
                OnPropertyChanged();
            }
        }

        private string addressTextBox;
        public string AddressTextBox
        {
            get { return addressTextBox; }
            set
            {
                addressTextBox = value;
                OnPropertyChanged();
            }
        }

        private List<Employee> branchEmployees;
        public List<Employee> BranchEmployees
        {
            get { return branchEmployees; }
            set
            {
                branchEmployees = value;
                OnPropertyChanged();
            }
        }

        private List<Hall> branchHalls;
        public List<Hall> BranchHalls
        {
            get { return branchHalls; }
            set
            {
                branchHalls = value;
                OnPropertyChanged();
            }
        }

        private List<Pass> branchPass;
        public List<Pass> BranchPass
        {
            get { return branchPass; }
            set
            {
                branchPass = value;
                OnPropertyChanged();
            }
        }

        private List<Service> branchServices;
        public List<Service> BranchServices
        {
            get { return branchServices; }
            set
            {
                branchServices = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        private Command changeCommand;
        public Command ChangeCommand => changeCommand ?? (changeCommand = new Command(obj =>
        {
            Branch.Name = NameTextBox;

            Branch.Address = AddressTextBox;

            Save(Branch);
        }));

        private Command deleteCommand;

        public Command DeleteCommand => deleteCommand ?? (deleteCommand = new Command(obj =>
        {
            Delete(Branch);

            MainWindowViewModel main = MainWindowViewModel.Instance;

            BranchViewModel branchViewModel = BranchViewModel.Instance;

            int indexBranch = branchViewModel.FilteredListBranches.FindIndex(x => x.BranchId == Branch.BranchId);

            branchViewModel.FilteredListBranches.RemoveAt(indexBranch);

            main.MainContentViewModel = branchViewModel;
        }));



        #endregion

        public void MoveData(Branch branch)
        {
            using (FCContext fc = new FCContext())
            {
                Branch = branch;

                NameTextBox = Branch.Name;

                AddressTextBox = Branch.Address;

                BranchEmployees = fc.Employees.Include(x=>x.Post).Where(x => x.BranchId == Branch.BranchId).ToList();

                BranchHalls = fc.Halls.Where(x => x.BranchId == Branch.BranchId).ToList();

                BranchPass = fc.Passes.Where(x => x.BranchId == Branch.BranchId).ToList();

                BranchServices = new List<Service>();
                
                foreach (var item in BranchPass.Select(x=>x.PassId))
                {
                    BranchServices.Add(fc.PassServices.Include(x => x.Service).Where(x => x.PassId == item).Distinct().Select(x => x.Service).FirstOrDefault());

                }
            }
        }

        private void Save(Branch branch)
        {
            using (FCContext context = new FCContext())
            {
                Branch branchDb = context.Branches.FirstOrDefault(x => x.BranchId == branch.BranchId);

                branchDb.Name = branch.Name;
                branchDb.Address = branch.Address;

                context.SaveChanges();
            }
        }

        private void Delete(Branch branch)
        {
            using (FCContext context = new FCContext())
            {
                Branch branchDb = context.Branches.FirstOrDefault(x => x.BranchId == branch.BranchId);

                branchDb.IsDeleted = true;

                context.SaveChanges();
            }
        }

        public BranchCardViewModel() { }
    }
}
