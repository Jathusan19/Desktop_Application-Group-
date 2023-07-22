using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_Application.Data;
using Desktop_Application.Models;
using Desktop_Application.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Desktop_Application.ViewModels
{
    public partial class LoginWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string userName;

        [ObservableProperty]
        public string password;

        [ObservableProperty]
        ObservableCollection<User> people;

        [RelayCommand]
        public void LogInUser()
        {
            User u = new User()
            {
                Username = UserName,
                Password = Password,
            };

            using (var db = new DataBaseContext())
            {
                bool successlogin = false;
                var staff = db.Users;
                foreach (var Item in staff)
                {
                    if (Item.Username == UserName && Item.Password == Password && Item.IsAdmin == true)
                    {

                        successlogin = true;
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        //MessageBox.Show("You successfully login as Admin");
                        return;
                    }
                    else if (Item.Username == UserName && Item.Password == Password && Item.IsAdmin == false)
                    {
                        StaffWindow staffWindow = new StaffWindow();
                        staffWindow.Show();
                        //MessageBox.Show("You successfully login as Staff");
                        successlogin = true;
                        return;
                    }
                }
                if (!successlogin)
                {
                    MessageBox.Show("Invalid username and Password");
                }
            }
        }


        [RelayCommand]
        public void InsertUser()
        {
            User u = new User()
            {
                Username = UserName,
                Password = Password,
                IsAdmin = false
            };

            using (var db = new DataBaseContext())
            {
                bool insertperson = false;

                var staff = db.Users;
                foreach (var item in staff)
                {
                    if (item.Username == u.Username)
                    {
                        insertperson = false;
                        MessageBox.Show("Username already exist");
                        break;
                    }
                    else
                    {
                        insertperson = true;
                    }
                }

                if (insertperson)
                {
                    db.Users.Add(u);
                    db.SaveChanges();
                    MessageBox.Show("Account successfully created");
                }

            }

        }
    }
}
