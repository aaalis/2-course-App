using FitnessClub2.Model.Classes;
using FitnessClub2.Model.Data;
using FitnessClub2.View;
using FitnessClub2.ViewModel.Cards;
using FitnessClub2.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Controls;

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

        public List<Client> Clients { get; set; }

        private Command addClient;
        public Command AddClient
        {
            get
            {
                return addClient ?? (addClient = new Command(obj =>
                {
                    Client client = new Client();
                    client.Name = "new";
                    Clients.Insert(0, client);
                    MainWindowViewModel main = MainWindowViewModel.Instance;
                    ClientCardViewModel clientCard = ClientCardViewModel.Instance;
                    clientCard.Client = client;
                    main.MainContentViewModel = clientCard;
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
                    clientCard.Client = SelectedClient;
                    main.MainContentViewModel = clientCard;
                }));
            }
        }
        
        public ClientViewModel()
        {
            Clients = FcDAO.Get<Client>(LISTLENGTH);
        }
    }
}
