using FitnessClub2.Model.Classes;
using FitnessClub2.ViewModel.Cards;
using FitnessClub2.ViewModel.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessClub2.ViewModel
{
    class PassViewModel : BaseViewModel<PassViewModel>
    {
        private string filterName = null;
        public string FilterName
        {
            get { return filterName; }
            set
            {
                filterName = value;
                UpdateFilteredListPass(filterName);
            }
        }

        private string filterBranch = null;
        public string FilterBranch
        {
            get { return filterBranch; }
            set
            {
                filterBranch = value;
                UpdateFilteredListPass(filterBranch);
            }
        }

        private Pass selectedPass;
        public Pass SelectedPass
        {
            get { return selectedPass; }
            set { selectedPass = value; }
        }

        private List<Pass> AllPass { get; set; }
        public List<Pass> FilteredListPass { get; set; }

        private Command addPass;
        public Command AddPass
        {
            get
            {
                return addPass ?? (addPass = new Command(obj =>
                {
                    Pass pass = new Pass();

                    DateTime dateTime = DateTime.Now;

                    pass.Name = $"new + {dateTime}";

                    pass.BranchId = FilteredListPass.Select(x => x.BranchId).First();

                    FilteredListPass.RemoveAt(FilteredListPass.Count - 1);

                    FilteredListPass.Insert(0, pass);

                    MainWindowViewModel main = MainWindowViewModel.Instance;

                    PassCardViewModel passCardView= PassCardViewModel.Instance;

                    passCardView.MoveData(pass);

                    main.MainContentViewModel = passCardView;

                    Save(pass);
                }));
            }
        }

        private Command editPAss;
        public Command EditPass
        {
            get
            {
                return editPAss ?? (editPAss = new Command(obj =>
                {
                    MainWindowViewModel main = MainWindowViewModel.Instance;

                    PassCardViewModel passCard = PassCardViewModel.Instance;

                    passCard.MoveData(SelectedPass);

                    main.MainContentViewModel = passCard;
                }));
            }
        }

        private void Save(Pass pass)
        {
            using (FCContext context = new FCContext())
            {
                context.Passes.Add(pass);

                context.SaveChanges();
            }
        }

        private void UpdateFilteredListPass(string value)
        {
            FilteredListPass = AllPass.Where(x => x.Name.Contains(value) | x.Name == value | x.Branch.Name.Contains(value) | x.Branch.Name == value).ToList();
            OnPropertyChanged("FilteredListPass");
        }

        public PassViewModel()
        {
            using (FCContext fc = new FCContext())
            {
                AllPass = fc.Passes.Include(x=>x.Branch).Where(x => x.IsDeleted != true).ToList();

                if (LISTLENGTH >= AllPass.Count)
                {
                    FilteredListPass = AllPass;
                }
                else
                {
                    FilteredListPass = AllPass.ToList().GetRange(AllPass.ToList().Count - LISTLENGTH, LISTLENGTH);
                }
            }
        }
    }
}
