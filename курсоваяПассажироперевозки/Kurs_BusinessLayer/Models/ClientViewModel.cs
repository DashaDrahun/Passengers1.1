using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Kurs_BusinessLayer.Models
{
    public class ClientViewModel:BaseVM
    {
        private int clientId;
        private string family;
        private string name;
        private string patronymic;
        private System.DateTime dateBirth;
        private string tel_Mobile;
        private string email;
        private string vKProfile;
        //public ObservableCollection<OrderViewModel> Orders { get; set; }

        public int ClientId
        {
            get
            {
                return clientId;
            }

            set
            {
                clientId = value;
                OnPropertyChanged(nameof(ClientId));
            }
        }

        public string Family
        {
            get
            {
                return family;
            }

            set
            {
                family = value;
                OnPropertyChanged(nameof(Family));
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Patronymic
        {
            get
            {
                return patronymic;
            }

            set
            {
                patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }

        public DateTime DateBirth
        {
            get
            {
                return dateBirth;
            }

            set
            {
                dateBirth = value;
                OnPropertyChanged(nameof(DateBirth));
            }
        }

        public string Tel_Mobile
        {
            get
            {
                return tel_Mobile;
            }

            set
            {
                tel_Mobile = value;
                OnPropertyChanged(nameof(Tel_Mobile));
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string VKProfile
        {
            get
            {
                return vKProfile;
            }

            set
            {
                vKProfile = value;
                OnPropertyChanged(nameof(VKProfile));
            }
        }
        public override string ToString()
        {
            return Family + " " + Name + " " + Patronymic;
        }
    }
}
