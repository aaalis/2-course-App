using FitnessClub2.Model.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessClub2.ViewModel.Cards
{
    class ClientCardViewModel : BaseViewModel<ClientCardViewModel>
    {
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

        public void MoveData(Client client)
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
        }

        public ClientCardViewModel() {}

    }
}
