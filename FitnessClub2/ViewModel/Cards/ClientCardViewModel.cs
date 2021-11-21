using FitnessClub2.Model.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessClub2.ViewModel.Cards
{
    class ClientCardViewModel : BaseViewModel<ClientCardViewModel>
    {
        private Client client;
        public Client Client
        {
            get { return client; }
            set
            {
                client = value;
                OnPropertyChanged("client");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("name");
            }
        }

        private string phonenum;
        public string Phonenum
        {
            get { return phonenum; }
            set
            {
                phonenum = value;
                OnPropertyChanged("phonenum");
            }
        }

        private string birthday;
        public string Birthday
        {
            get { return birthday; }
            set 
            {
                birthday = value;
                OnPropertyChanged("birthday");
            }
        }

        private List<Workout> clientWorkouts;
        public List<Workout> ClientWorkouts
        {
            get { return clientWorkouts; }
            set 
            {
                clientWorkouts = value;
                OnPropertyChanged("ClientWorkouts");
            }
        }

        private List<Clientcard> cards;
        public List<Clientcard> Cards
        {
            get { return cards; }
            set
            { 
                cards = value;
                OnPropertyChanged("cards");
            }
        }
        
        private List<Contract> contracts;
        public List<Contract> Contracts
        {
            get { return contracts; }
            set
            {
                contracts = value;
                OnPropertyChanged("contracts");
            }
        }

        private List<Payment> payments;
        public List<Payment> Payments
        {
            get { return payments; }
            set
            {
                payments = value;
                OnPropertyChanged("payments");
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


        public void MoveData(Client client)
        {
            using (FCContext fc = new FCContext())
            {
                Client = client;

                Name = Client.Name;

                if (Client.Birthday.HasValue)
                {
                    Birthday = Client.Birthday.Value.ToShortDateString();
                }
                else
                {
                    Birthday = "";
                }

                Phonenum = Client.Phonenum;

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

        public ClientCardViewModel() {}

    }
}
