using FitnessClub2.Model.Classes;
using FitnessClub2.ViewModel.Cards;
using FitnessClub2.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessClub2.ViewModel
{
    class ServiceViewModel : BaseViewModel<ServiceViewModel>
    {
        private string filterName = null;
        public string FilterName
        {
            get { return filterName; }
            set
            {
                filterName = value;
                UpdateFilteredListServices(filterName);
            }
        }

        private string filterAvtime = null;
        public string FilterAvtime
        {
            get { return filterAvtime; }
            set
            {
                filterAvtime = value;
                UpdateFilteredListServices(filterAvtime);
            }
        }

        private Service selectedService;
        public Service SelectedService
        {
            get { return selectedService; }
            set { selectedService = value; }
        }

        private List<Service> AllServices { get; set; }
        public List<Service> FilteredListServices{ get; set; }

        private Command addService;
        public Command AddService
        {
            get
            {
                return addService ?? (addService = new Command(obj =>
                {
                    Service service = new Service();

                    DateTime dateTime = DateTime.Now;

                    service.Name = $"new + {dateTime}";

                    service.Avtime = "0 минут";

                    FilteredListServices.RemoveAt(FilteredListServices.Count - 1);

                    FilteredListServices.Insert(0, service);

                    MainWindowViewModel main = MainWindowViewModel.Instance;

                    ServiceCardViewModel serviceCard = ServiceCardViewModel.Instance;

                    serviceCard.MoveData(service);

                    main.MainContentViewModel = serviceCard;

                    Save(service);
                }));
            }
        }

        private Command editService;
        public Command EditService
        {
            get
            {
                return editService ?? (editService = new Command(obj =>
                {
                    MainWindowViewModel main = MainWindowViewModel.Instance;

                    ServiceCardViewModel serviceCard = ServiceCardViewModel.Instance;

                    serviceCard.MoveData(SelectedService);

                    main.MainContentViewModel = serviceCard;
                }));
            }
        }

        private void Save(Service service)
        {
            using (FCContext context = new FCContext())
            {
                context.Services.Add(service);

                context.SaveChanges();
            }
        }

        private void UpdateFilteredListServices(string value)
        {
            FilteredListServices = AllServices.Where(x => x.Name.Contains(value) | x.Name == value | x.Avtime.Contains(value) | x.Avtime == value ).ToList();
            OnPropertyChanged("FilteredListServices");
        }

        public ServiceViewModel()
        {
            using (FCContext fc = new FCContext())
            {
                AllServices = fc.Services.Where(x => x.IsDeleted != true).ToList();

                if (LISTLENGTH >= AllServices.Count)
                {
                    FilteredListServices = AllServices;
                }
                else
                {
                    FilteredListServices = AllServices.ToList().GetRange(AllServices.ToList().Count - LISTLENGTH, LISTLENGTH);
                }
            }
        }
    }
}
