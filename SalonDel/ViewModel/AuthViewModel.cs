using API;
using bd.View;
using SalonDel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace bd.ViewModel
{
    class AuthViewModel : BaseViewModel
    {
     
        public AuthViewModel(Window rootWindow) : base(rootWindow)
        {
            unitOfWork = new UnitOfWork();
        }

        private string login;
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private RelayCommand relayCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return relayCommand ?? (relayCommand = new RelayCommand(Auth));
            }

        }

        public void Auth(object obj) 
        {
            var user = unitOfWork.Repository<Users>().GetOneEntity(t => t.Login == Login && t.Password == Password);
            if (user != null)
            {
              

                    var catalog = new Catalog();
                    catalog.Show();
                    rootWindow.Close();
                
            }
            else
            {
                MessageBox.Show("Нет пользователя с таким логином и паролем");
            }
        }

    }
        }
    

            