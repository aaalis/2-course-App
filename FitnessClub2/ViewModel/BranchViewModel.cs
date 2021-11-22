using FitnessClub2.Model.Classes;
using FitnessClub2.ViewModel.Cards;
using FitnessClub2.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessClub2.ViewModel
{
    class BranchViewModel : BaseViewModel<BranchViewModel>
    {
        private string filterName = null;
        public string FilterName
        {
            get { return filterName; }
            set
            {
                filterName = value;
                UpdateFilteredListBranches(filterName);
            }
        }

        private string filterAddress = null;
        public string FilterAddress
        {
            get { return filterAddress; }
            set
            {
                filterAddress = value;
                UpdateFilteredListBranches(filterAddress);
            }
        }

        private Branch selectedBranch;
        public Branch SelectedBranch
        {
            get { return selectedBranch; }
            set { selectedBranch = value; }
        }

        private List<Branch> AllBranches { get; set; }
        public List<Branch> FilteredListBranches { get; set; }

        private Command addBranch;
        public Command AddBranch
        {
            get
            {
                return addBranch ?? (addBranch = new Command(obj =>
                {
                    Branch branch = new Branch();

                    DateTime dateTime = DateTime.Now;

                    branch.Name = $"new + {dateTime}";

                    FilteredListBranches.RemoveAt(FilteredListBranches.Count - 1);

                    FilteredListBranches.Insert(0, branch);

                    MainWindowViewModel main = MainWindowViewModel.Instance;

                    BranchCardViewModel branchCard = BranchCardViewModel.Instance;

                    branchCard.MoveData(branch);

                    main.MainContentViewModel = branchCard;

                    Save(branch);
                }));
            }
        }

        private Command editBranch;
        public Command EditBranch
        {
            get
            {
                return editBranch ?? (editBranch = new Command(obj =>
                {
                    MainWindowViewModel main = MainWindowViewModel.Instance;

                    BranchCardViewModel branchCard = BranchCardViewModel.Instance;

                    branchCard.MoveData(SelectedBranch);

                    main.MainContentViewModel = branchCard;
                }));
            }
        }

        private void Save(Branch branch)
        {
            using (FCContext context = new FCContext())
            {
                context.Branches.Add(branch);

                context.SaveChanges();
            }
        }

        private void UpdateFilteredListBranches(string value)
        {
            FilteredListBranches = AllBranches.Where(x => x.Name.Contains(value) | x.Name == value | x.Address.Contains(value) | x.Address == value).ToList();
            OnPropertyChanged("FilteredListBranches");
        }

        public BranchViewModel()
        {
            using (FCContext fc = new FCContext())
            {
                AllBranches = fc.Branches.Where(x => x.IsDeleted != true).ToList();

                if (LISTLENGTH >= AllBranches.Count)
                {
                    FilteredListBranches = AllBranches;
                }
                else
                {
                    FilteredListBranches = AllBranches.ToList().GetRange(AllBranches.ToList().Count - LISTLENGTH, LISTLENGTH);
                }
            }
        }
    }
}
