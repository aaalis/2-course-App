using FitnessClub2.Model.Classes;
using System;
using System.Collections.Generic;
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

        public ClientCardViewModel() { }

    }
}
