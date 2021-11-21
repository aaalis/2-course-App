using FitnessClub2.Model.Classes;
using FitnessClub2.ViewModel.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace FitnessClub2.ViewModel.Cards
{
    class ClientCardViewModel : BaseViewModel<ClientCardViewModel>
    {
        #region Properties

        private Client client;
        public Client Client
        {
            get { return client; }
            set
            {
                client = value;
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

        private string phonenumTextBox;
        public string PhonenumTextBox
        {
            get { return phonenumTextBox; }
            set
            {
                phonenumTextBox = value;
                OnPropertyChanged();
            }
        }

        private DateTime? birthdayTextBox;
        public DateTime? BirthdayTextBox
        {
            get 
            {
                if (birthdayTextBox.HasValue)
                {
                    return birthdayTextBox.Value;
                }
                else
                {
                    return null;
                }
            }
            set 
            {
                birthdayTextBox = value;
                OnPropertyChanged();
            }
        }

        private List<Workout> clientWorkouts;
        public List<Workout> ClientWorkouts
        {
            get { return clientWorkouts; }
            set 
            {
                clientWorkouts = value;
                OnPropertyChanged();
            }
        }

        private List<Clientcard> cards;
        public List<Clientcard> Cards
        {
            get { return cards; }
            set
            { 
                cards = value;
                OnPropertyChanged();
            }
        }
        
        private List<Contract> contracts;
        public List<Contract> Contracts
        {
            get { return contracts; }
            set
            {
                contracts = value;
                OnPropertyChanged();
            }
        }

        private List<Payment> payments;
        public List<Payment> Payments
        {
            get { return payments; }
            set
            {
                payments = value;
                OnPropertyChanged();
            }
        }

        private List<Visit> visits;

        public List<Visit> Visits
        {
            get { return visits; }
            set 
            { 
                visits = value;
                OnPropertyChanged("visits");
            }
        }
        #endregion

        #region Commands
        private Command changeCommand;
        public Command ChangeCommand => changeCommand ?? (changeCommand = new Command(obj =>
        {
            Client.Birthday = BirthdayTextBox;

            Client.Name = NameTextBox;
            
            Client.Phonenum = PhonenumTextBox;
            
            Save(Client);
        }));

        private Command deleteCommand;

        public Command DeleteCommand => deleteCommand ?? (deleteCommand = new Command(obj =>
        {
            Delete(Client);
            
            MainWindowViewModel main = MainWindowViewModel.Instance;
            
            ClientViewModel clientViewModel = ClientViewModel.Instance;
            
            int indexClient = clientViewModel.FilteredListClients.FindIndex(x => x.ClientId == Client.ClientId);
            
            clientViewModel.FilteredListClients.RemoveAt(indexClient);
            
            main.MainContentViewModel = clientViewModel;
        }));
        


        #endregion

        public void MoveData(Client client)
        {
            using (FCContext fc = new FCContext())
            {
                Client = client;

                NameTextBox = Client.Name;

                BirthdayTextBox = Client.Birthday;

                PhonenumTextBox = Client.Phonenum;

                ClientWorkouts = fc.ClientsWorkouts.Include(x => x.Workout)
                                                        .ThenInclude(x => x.Hall)
                                                   .Include(x => x.Workout)
                                                        .ThenInclude(x => x.Employee)
                                                   .Include(x => x.Workout)
                                                        .ThenInclude(x => x.Service)
                                                   .Where(x=>x.ClientId == Client.ClientId)
                                                   .Select(x=>x.Workout)
                                                   .ToList();

                Cards = fc.Clientcards.Include(x=>x.Visits)
                                      .ThenInclude(x=>x.Branch)
                                      .Where(x => x.ClientId == Client.ClientId)
                                      .ToList();

                Contracts = fc.Contracts.Include(x=>x.Pass)
                                        .Where(x => x.ClientId == Client.ClientId)
                                        .ToList();

                Payments = fc.Payments.Where(x => x.ClientId == Client.ClientId)
                                      .ToList();

                Visits = Cards.SelectMany(x => x.Visits).ToList();
            }
        }

        private void Save(Client client)
        {
            using (FCContext context = new FCContext())
            {
                Client clientDb = context.Clients.FirstOrDefault(x => x.ClientId == client.ClientId);

                clientDb.Name = client.Name;
                clientDb.Phonenum = client.Phonenum;
                clientDb.Birthday = client.Birthday;

                context.SaveChanges();
            }
        }

        private void Delete(Client client)
        {
            using (FCContext context = new FCContext())
            {
                Client clientDb = context.Clients.FirstOrDefault(x=>x.ClientId == client.ClientId);

                clientDb.IsDeleted = true;

                context.SaveChanges();
            }
        }

        public ClientCardViewModel() {}

    }
}
