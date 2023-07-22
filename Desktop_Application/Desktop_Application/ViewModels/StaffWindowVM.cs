using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop_Application.Data;
using Desktop_Application.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Desktop_Application.ViewModels
{
    public partial class StaffWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string firstName;

        [ObservableProperty]
        public string lastName;

        [ObservableProperty]
        public string nicNo;

       

        [ObservableProperty]
        ObservableCollection<Student> schoolStudents;

        [RelayCommand]
        public void InserPerson()
        {
            Student p = new Student()
            {
                FirstName = FirstName,
                LastName = LastName,
                NicNo = NicNo,
            };
            using (var db = new DataBaseContext())
            {
                db.Students.Add(p);
                db.SaveChanges();
                LoadPerson();
            }
        }


        [RelayCommand]
        public async void EditPerson(Student student)
        {
            using var db = new DataBaseContext();

            if (student == null)
            {
                return;
            }

            var originalPerson = db.Students.FirstOrDefault(p => p.Id == student.Id);

            if (originalPerson != null)
            {
                originalPerson.FirstName = student.FirstName;
                originalPerson.LastName = student.LastName;
                originalPerson.NicNo = student.NicNo;
              
                db.SaveChanges();

                LoadPerson(); // Update the UI
            }
        }

        [RelayCommand]
        public void DeletePerson(Student student)
        {
            if (student == null)
            {
                return;
            }
            else
            {
                using (var db = new DataBaseContext())
                {
                    var originalPerson = db.Students.FirstOrDefault(p => p.Id == student.Id);
                    if (originalPerson != null)
                    {
                        db.Students.Remove(originalPerson);
                        db.SaveChanges();
                    }
                }
                SchoolStudents.Remove(student);
            }
        }


        public void LoadPerson()
        {
            using (var db = new DataBaseContext())
            {
                var list = db.Students.OrderBy(p => p.NicNo).ToList();
                SchoolStudents = new ObservableCollection<Student>(list);
            }
        }

        public StaffWindowVM()
        {
            LoadPerson();
        }
    }
}
