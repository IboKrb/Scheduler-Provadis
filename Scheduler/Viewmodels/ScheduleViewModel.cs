using Microsoft.Maui.Dispatching;
using Scheduler.Model;
using Scheduler.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Viewmodels
{
    public class ScheduleViewModels
    {
        public ObservableCollection<ScheduleItem> ScheduleItems { get; } = new();

        private readonly ApiService _apiService = new();
        public ObservableCollection<GroupedScheduleItems> GroupedSchedule { get; } = new();
        public ScheduleViewModels()
        {

            LoadScheduleAsync();
            StartTimer();
        }

        private async Task LoadScheduleAsync()
        {
            var scheduleItems = await _apiService.GetScheduleAsync();
            if (scheduleItems != null)
            {
                var groupedByDate = scheduleItems.GroupBy(s => s.StartDate.Date)
                                                 .Select(g => new GroupedScheduleItems
                                                 {
                                                     Date = g.Key,
                                                     Items = new ObservableCollection<ScheduleItem>(g)
                                                 });
                foreach (var group in groupedByDate)
                {
                    GroupedSchedule.Add(group);
                }
            }
        }
        private void StartTimer()
        {
            Device.StartTimer(TimeSpan.FromMinutes(1), () =>
            {
                foreach (var group in GroupedSchedule ?? new ObservableCollection<GroupedScheduleItems>())
                {
                    foreach (var item in group.Items ?? new ObservableCollection<ScheduleItem>())
                    {
                        item.UpdateBackgroundColor();
                    }
                }

                // To keep the timer running, return true
                return true;
            });
        }


        public class GroupedScheduleItems
        {
            public DateTime Date { get; set; }
            public ObservableCollection<ScheduleItem> Items { get; set; }
        }
    }
}
