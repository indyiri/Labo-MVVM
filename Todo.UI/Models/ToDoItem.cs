using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.UI.Models
{
    //In plaats van de ': INotifyPropertyChanged', gaan we de ObservableObject implementeren (ook nuget package downloaden)
    public partial class ToDoItem : ObservableObject
    {
        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private string _description;

        [ObservableProperty]
        private bool _isCompleted;

        [ObservableProperty]
        private DateTime _dueDate;
    }
}
