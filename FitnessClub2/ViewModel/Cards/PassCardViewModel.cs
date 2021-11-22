using FitnessClub2.Model.Classes;
using FitnessClub2.ViewModel.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessClub2.ViewModel.Cards
{
    class PassCardViewModel : BaseViewModel<PassCardViewModel>
    {
        #region Properties

        private Pass pass;
        public Pass Pass
        {
            get { return pass; }
            set
            {
                pass = value;
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

        private decimal priceTextBox;
        public decimal PriceTextBox
        {
            get { return priceTextBox; }
            set
            {
                priceTextBox = value;
                OnPropertyChanged();
            }
        }

        private int freezingdaysTextBox;
        public int FreezingdaysTextBox
        {
            get { return freezingdaysTextBox; }
            set
            {
                freezingdaysTextBox = value;
                OnPropertyChanged();
            }
        }

        private int amountdaysTextBox;
        public int AmountdaysTextBox
        {
            get { return amountdaysTextBox; }
            set
            {
                amountdaysTextBox = value;
                OnPropertyChanged();
            }
        }

        //private string branchNameTextBox;
        //public string BranchNameTextBox
        //{
        //    get { return branchNameTextBox; }
        //    set
        //    {
        //        branchNameTextBox = value;
        //        OnPropertyChanged();
        //    }
        //}

        private List<Service> passServices;
        public List<Service> PassServices
        {
            get { return passServices; }
            set
            {
                passServices = value;
                OnPropertyChanged();
            }
        }

        private List<Contract> passContracts;
        public List<Contract> PassContracts
        {
            get { return passContracts; }
            set
            {
                passContracts = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands
        private Command changeCommand;
        public Command ChangeCommand => changeCommand ?? (changeCommand = new Command(obj =>
        {
            Pass.Name = NameTextBox;

            Pass.Price = PriceTextBox;

            Pass.Freezingdays = FreezingdaysTextBox;

            Pass.Amountdays = AmountdaysTextBox;

            Save(Pass);
        }));

        private Command deleteCommand;

        public Command DeleteCommand => deleteCommand ?? (deleteCommand = new Command(obj =>
        {
            Delete(Pass);

            MainWindowViewModel main = MainWindowViewModel.Instance;

            PassViewModel passViewModel = PassViewModel.Instance;

            int indexPass = passViewModel.FilteredListPass.FindIndex(x => x.PassId == Pass.PassId);

            passViewModel.FilteredListPass.RemoveAt(indexPass);

            main.MainContentViewModel = passViewModel;
        }));



        #endregion

        public void MoveData(Pass pass)
        {
            using (FCContext fc = new FCContext())
            {
                Pass = pass;

                NameTextBox = Pass.Name;

                PriceTextBox = Pass.Price;

                FreezingdaysTextBox = Pass.Freezingdays;

                AmountdaysTextBox = Pass.Amountdays;

                

                PassServices = fc.PassServices.Include(x => x.Service).Where(x => x.PassId == Pass.PassId).Select(x=>x.Service).ToList();

                PassContracts = fc.Contracts.Include(x=>x.Client).Where(x => x.PassId == Pass.PassId).ToList();
            }
        }

        private void Save(Pass pass)
        {
            using (FCContext context = new FCContext())
            {
                Pass passDb = context.Passes.FirstOrDefault(x => x.PassId == pass.PassId);

                passDb.Name = pass.Name;
                passDb.Price = pass.Price;
                passDb.Freezingdays = pass.Freezingdays;
                passDb.Amountdays = pass.Amountdays;

                context.SaveChanges();
            }
        }

        private void Delete(Pass pass)
        {
            using (FCContext context = new FCContext())
            {
                Pass passDb = context.Passes.FirstOrDefault(x => x.PassId == pass.PassId);

                passDb.IsDeleted = true;

                context.SaveChanges();
            }
        }

        public PassCardViewModel() { }

    }
}
