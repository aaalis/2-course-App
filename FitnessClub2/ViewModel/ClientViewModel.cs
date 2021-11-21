using FitnessClub2.Model.Classes;
using FitnessClub2.ViewModel.Cards;
using FitnessClub2.ViewModel.Commands;
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
                    Clients.RemoveAt(Clients.Count-1);
                    Clients.Insert(0, client);
                    MainWindowViewModel main = MainWindowViewModel.Instance;
                    ClientCardViewModel clientCard = ClientCardViewModel.Instance;
                    clientCard.MoveData(client);
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
                    clientCard.MoveData(SelectedClient);
                    main.MainContentViewModel = clientCard;
                }));
            }
        }
        
        public ClientViewModel()
        {
            using (FCContext fc = new FCContext())
            {
                Clients = fc.Clients.Take(LISTLENGTH).ToList();
            }
        }
    }
}
