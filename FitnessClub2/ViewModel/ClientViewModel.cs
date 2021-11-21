using FitnessClub2.Model.Classes;
using FitnessClub2.ViewModel.Cards;
using FitnessClub2.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace FitnessClub2.ViewModel
{
    class ClientViewModel : BaseViewModel<ClientViewModel>
    {
        private string filterName = null;
        public string FilterName
        {
            get { return filterName; }
            set 
            { 
                filterName = value;
                UpdateFilteredListClients(filterName);
            }
        }

        private string filterPhonenum = null;
        public string FilterPhonenum
        {
            get { return filterPhonenum; }
            set 
            { 
                filterPhonenum = value;
                UpdateFilteredListClients(filterPhonenum);
            }
        }

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

        private void UpdateFilteredListClients(string value)
        {
            FilteredListClients = AllClients.Where(x => x.Name.Contains(value) | x.Name == value | x.Phonenum.Contains(value) | x.Phonenum == value).ToList();
            OnPropertyChanged("FilteredListClients");
        }
        
        public ClientViewModel()
        {
            using (FCContext fc = new FCContext())
            {
                AllClients = fc.Clients.Where(x => x.IsDeleted != true).ToList();

                if (LISTLENGTH >= AllClients.Count)
                {
                    FilteredListClients = AllClients;
                }
                else
                {
                    FilteredListClients = AllClients.ToList().GetRange(AllClients.ToList().Count - LISTLENGTH, LISTLENGTH);
                }
            }
        }
    }
}
