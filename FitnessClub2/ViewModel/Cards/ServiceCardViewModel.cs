using FitnessClub2.Model.Classes;
using FitnessClub2.ViewModel.Commands;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace FitnessClub2.ViewModel.Cards
{
    class ServiceCardViewModel : BaseViewModel<ServiceCardViewModel>
    {
        #region Properties

        private Service service;
        public Service Service
        {
            get { return service; }
            set
            {
                service = value;
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

        private string avtimeTextBox;
        public string AvtimeTextBox
        {
            get { return avtimeTextBox; }
            set
            {
                avtimeTextBox = value;
                OnPropertyChanged();
            }
        }

        private string descTextBox;
        public string DescTextBox
        {
            get { return descTextBox; }
            set
            {
                descTextBox = value;
                OnPropertyChanged();
            }
        }

        private List<Hall> serviceHalls;
        public List<Hall> ServiceHalls
        {
            get { return serviceHalls; }
            set
            {
                serviceHalls = value;
                OnPropertyChanged();
            }
        }

        private List<Employee> serviceEmployees;
        public List<Employee> ServiceEmployees
        {
            get { return serviceEmployees; }
            set
            {
                serviceEmployees = value;
                OnPropertyChanged();
            }
        }

        //private List<Contract> serviceContracts;
        //public List<Contract> ServiceContracts
        //{
        //    get { return serviceContracts; }
        //    set
        //    {
        //        serviceContracts = value;
        //        OnPropertyChanged();
        //    }
        //}

        private List<Pass> servicePass;
        public List<Pass> ServicePass
        {
            get { return servicePass; }
            set
            {
                servicePass = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        private Command changeCommand;
        public Command ChangeCommand => changeCommand ?? (changeCommand = new Command(obj =>
        {
            Service.Name = NameTextBox;

            Service.Avtime = AvtimeTextBox;

            Service.Description = DescTextBox;

            Save(Service);
        }));

        private Command deleteCommand;

        public Command DeleteCommand => deleteCommand ?? (deleteCommand = new Command(obj =>
        {
            Delete(Service);

            MainWindowViewModel main = MainWindowViewModel.Instance;

            ServiceViewModel serviceViewModel = ServiceViewModel.Instance;

            int indexService = serviceViewModel.FilteredListServices.FindIndex(x => x.ServiceId == Service.ServiceId);

            serviceViewModel.FilteredListServices.RemoveAt(indexService);

            main.MainContentViewModel = serviceViewModel;
        }));



        #endregion

        public void MoveData(Service service)
        {
            using (FCContext fc = new FCContext())
            {
                Service = service;

                NameTextBox = Service.Name;

                AvtimeTextBox = Service.Avtime;

                DescTextBox = Service.Description;

                ServiceHalls = fc.ServicesHalls.Include(x => x.Hall).Where(x => x.ServiceId == Service.ServiceId).Select(x => x.Hall).ToList();

                ServiceEmployees = fc.Workouts.Include(x => x.Employee)
                                                    .ThenInclude(x=>x.Branch)
                                              .Include(x => x.Service)
                                              .Where(x => x.ServiceId == Service.ServiceId)
                                              .Select(x => x.Employee)
                                              .ToList();

                List<int> listPassIds = fc.PassServices.Include(x => x.Service).Where(x => x.ServiceId == Service.ServiceId).Select(x => x.PassId).ToList();

                ServicePass = new List<Pass>();
                
                foreach (var item in listPassIds)
                {
                    ServicePass.Add(fc.Passes.Where(x => x.PassId == item).Single());
                }

                //ClientWorkouts = fc.ClientsWorkouts.Include(x => x.Workout)
                //                                        .ThenInclude(x => x.Hall)
                //                                   .Include(x => x.Workout)
                //                                        .ThenInclude(x => x.Employee)
                //                                   .Include(x => x.Workout)
                //                                        .ThenInclude(x => x.Service)
                //                                   .Where(x => x.ClientId == Client.ClientId)
                //                                   .Select(x => x.Workout)
                //                                   .ToList();

                //ServiceEmployees = fc.Clientcards.Include(x => x.Visits)
                //                      .ThenInclude(x => x.Branch)
                //                      .Where(x => x.ClientId == Client.ClientId)
                //                      .ToList();

                //ServiceContracts = fc.Contracts.Include(x => x.Pass)
                //                        .Where(x => x.ClientId == Client.ClientId)
                //                        .ToList();

                //ServicePass = fc.Payments.Where(x => x.ClientId == Client.ClientId)
                //                      .ToList();

                //Visits = ServiceEmployees.SelectMany(x => x.Visits).ToList();
            }
        }

        private void Save(Service service)
        {
            using (FCContext context = new FCContext())
            {
                Service serviceDb = context.Services.FirstOrDefault(x => x.ServiceId == service.ServiceId);

                serviceDb.Name = service.Name;
                serviceDb.Avtime = service.Avtime;
                serviceDb.Description = service.Description;

                context.SaveChanges();
            }
        }

        private void Delete(Service service)
        {
            using (FCContext context = new FCContext())
            {
                Service serviceDb = context.Services.FirstOrDefault(x => x.ServiceId == service.ServiceId);

                serviceDb.IsDeleted = true;

                context.SaveChanges();
            }
        }

        public ServiceCardViewModel() { }

    }
}
