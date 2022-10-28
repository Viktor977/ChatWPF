using ChatWPF.Core;
using ChatWPF.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWPF.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }
        private ContactModel _selectedContact;
        public ContactModel SelectedContact
        {

            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SendCommand { get; set; }
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();
            SendCommand = new RelayCommand(x =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    IsFirstMessage = false,
                });
                Message = "";
            });
            Messages.Add(new MessageModel()
            {
                UserName = "Allison",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                IsFirstMessage = true,
                Message = "TEST",
                ImageSource = "http://i.imgur.com/yMWvLXd.png",
                UserColor = "#409aff"

            });
            for (int i = 0; i < 3; ++i)
            {
                Messages.Add(new MessageModel()
                {
                    UserName = "Allison",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    IsFirstMessage = true,
                    Message = "TEST",
                    ImageSource = "http://i.imgur.com/yMWvLXd.png",
                    UserColor = "#409aff"

                });
            }
            for (int i = 0; i < 4; ++i)
            {
                Messages.Add(new MessageModel()
                {
                    UserName = "Bunny",
                    Time = DateTime.Now,
                    IsNativeOrigin = true,
                    IsFirstMessage = true,
                    Message = "TEST",
                    ImageSource = "http://i.imgur.com/yMWvLXd.png",
                    UserColor = "#409aff"

                });
            }
            Messages.Add(new MessageModel()
            {
                UserName = "Bunny",
                Time = DateTime.Now,
                IsNativeOrigin = true,
                IsFirstMessage = true,
                Message = " Last TEST",
                ImageSource = "http://i.imgur.com/yMWvLXd.png",
                UserColor = "#409aff"

            });

            for (int i = 0; i < 5; ++i)
            {
                Contacts.Add(new ContactModel()
                {
                    UserName = $" Allison :{i}",
                    ImageSource = "http://i.imgur.com/i2szTsp.png",
                    Messages = Messages

                });
            }
        }

    }
}
