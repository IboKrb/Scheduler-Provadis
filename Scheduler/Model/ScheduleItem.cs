using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Graphics;

namespace Scheduler.Model
{

    public class ScheduleItem : INotifyPropertyChanged
    {
        private string _subjectName;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _date;
        private string _instructor;
        private string _building;
        private string _room;
        private string _group;
        private Color _backgroundColor;

        public string SubjectName

        {
            get => _subjectName;
            set => SetProperty(ref _subjectName, value);
        }

        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        public string Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        public string Instructor
        {
            get => _instructor;
            set => SetProperty(ref _instructor, value);
        }

        public string Building
        {
            get => _building;
            set => SetProperty(ref _building, value);
        }

        public string Room
        {
            get => _room;
            set => SetProperty(ref _room, value);
        }

        public string Group
        {
            get => _group;
            set => SetProperty(ref _group, value);
        }

        public Color BackgroundColor
        {
            get => _backgroundColor;
            private set => SetProperty(ref _backgroundColor, value);
        }

        public ScheduleItem()
        {
            UpdateBackgroundColor();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            if (propertyName == nameof(StartDate) || propertyName == nameof(EndDate) || propertyName == nameof(SubjectName))
            {
                UpdateBackgroundColor();
            }
            return true;
        }
        public void UpdateBackgroundColor()
        {
            // Get the current time. Adjust this if you need to account for different time zones.
            var currentTime = DateTime.Now;

            // Check if the lesson has finished by comparing the current time with the EndDate.
            if (currentTime > EndDate)
            {
                // If the current time is past the EndDate, set the background color to light green.
                BackgroundColor = Colors.LightGreen;
            }
            else if (SubjectName.Contains("Klausur"))
            {
                BackgroundColor = Colors.LightSalmon; // Klausur
            }
            else if (SubjectName.Contains("Präsentation"))
            {
                BackgroundColor = Colors.LightPink; // Präsentation
            }
            else if (SubjectName.Contains("Mathematik"))
            {
                BackgroundColor = Colors.LightBlue; // Mathematik
            }
            else if (SubjectName.Contains("Informatik"))
            {
                BackgroundColor = Colors.Turquoise; // Informatik
            }            
            else if (SubjectName.Contains("Algorithmen"))
            {
                BackgroundColor = Colors.IndianRed; // Algorithmen
            }

            else
            {
                // Default color for upcoming or ongoing lessons
                BackgroundColor = Colors.MediumPurple;
            }
        }



    }
}
