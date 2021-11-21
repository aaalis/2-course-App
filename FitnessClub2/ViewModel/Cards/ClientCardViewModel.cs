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

                ClientWorkouts = fc.ClientsWorkouts.Where(x => x.ClientId == Client.ClientId).Select(x => x.Workout).Include(x=>x.Service).ToList();
            }
        }

        public ClientCardViewModel() {}

    }
}
