using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFMVVM
{
    internal class ApplicationViewModel : INotifyPropertyChanged
    {
        private Contact selectContact;

        public ObservableCollection<Contact> Contacts { get; set; }

        private RelayCommand addCommand;

        private RelayCommand removeCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                (addCommand = new RelayCommand(obj =>
                {
                    Contact contact = new Contact();
                    Contacts.Insert(0, contact);
                    SelectedContact = contact;
                }));
            }
        }

        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        Contact phone = obj as Contact;
                        if (phone != null)
                        {
                            Contacts.Remove(phone);
                        }
                    }, (obj) => Contacts.Count > 0));
            }
        }

        public Contact SelectedContact
        {
            get { return selectContact; }
            set
            {
                selectContact = value;
                OnPropertyChanged("SelectedContact");
            }                         
        }

        public ApplicationViewModel()
        {
            Contacts = new ObservableCollection<Contact>()
            {
                new Contact { Name = "Альберт", Surname = "Макаров", Phone = "8921841223", Group = "4" },
                new Contact { Name = "Илья", Surname = "Сухой", Phone = "8921812411", Group = "3" },
                new Contact { Name = "Иван", Surname = "Ильин", Phone = "8921812433", Group = "2" },
                new Contact { Name = "Роберт", Surname = "Дроздов", Phone = "8921412235", Group = "1" }
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
