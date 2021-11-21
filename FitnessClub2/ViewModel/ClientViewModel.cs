using FitnessClub2.Model.Classes;
using FitnessClub2.ViewModel.Cards;
using FitnessClub2.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FitnessClub2.ViewModel
{
    class ClientViewModel : BaseViewModel<ClientViewModel>
    {
        private Client selectedClient;
        public Client SelectedClient
        {
            get { return selectedClient; }
            set { selectedClient = value; }
        }

        private List<Client> AllClients { get; set; }
        public List<Client> FilteredListClients { get; set; }

        private Command addClient;
        public Command AddClient
        {
            get
            {
                return addClient ?? (addClient = new Command(obj =>
                {
                    Client client = new Client();
                    DateTime dateTime = DateTime.Now;
                    client.Name = $"new + {dateTime}";
                    FilteredListClients.RemoveAt(FilteredListClients.Count-1);
                    FilteredListClients.Insert(0, client);
                    MainWindowViewModel main = MainWindowViewModel.Instance;
                    ClientCardViewModel clientCard = ClientCardViewModel.Instance;
                    clientCard.MoveData(client);
                    main.MainContentViewModel = clientCard;
                    Save(client);
                }));
            }
        }

        private Command editClient;
        public Command EditClient
        {
            get
            {
                return editClient ?? (editClient = new Command(obj =>
                {
                    MainWindowViewModel main = MainWindowViewModel.Instance;
                    ClientCardViewModel clientCard = ClientCardViewModel.Instance;
                    clientCard.MoveData(SelectedClient);
                    main.MainContentViewModel = clientCard;
                }));
            }
        }

        private void Save(Client client)
        {
            using (FCContext context = new FCContext())
            {
                context.Clients.Add(client);
                context.SaveChanges();
            }
        }
        
        public ClientViewModel()
        {
            using (FCContext fc = new FCContext())
            {
                AllClients = fc.Clients.ToList();
                if (LISTLENGTH >= AllClients.Count)
                {
                    FilteredListClients = AllClients;
                }
                else
                {
                    FilteredListClients = AllClients.GetRange(AllClients.Count - LISTLENGTH, LISTLENGTH);
                }
                
                
            }
        }
    }
}
