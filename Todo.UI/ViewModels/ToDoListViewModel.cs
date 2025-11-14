using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.UI.Data;
using Todo.UI.Models;

namespace Todo.UI.ViewModels
{
    public partial class ToDoListViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddTodoCommand))]
        private string _newTodoTitle;

        [ObservableProperty] 
        private ObservableCollection<ToDoItem> _todoItems;


        public ToDoListViewModel()
        {
            this.TodoItems = new ObservableCollection<ToDoItem>();

            // Convert List<ToDoItem> to ObservableCollection<ToDoItem>
            TodoItems = new ObservableCollection<ToDoItem>(TodoDb.GetTodoItems(10));

            NewTodoTitle = "";
        }

        [RelayCommand(CanExecute =nameof(CanAddItem))]
        private void AddTodo()
        {
            //TODO: add item to TodoItems, use NewTodoTitle as Title for the new item
            //TODO: clear the NewTodoTitle

            if (NewTodoTitle is not null && NewTodoTitle.Length > 0)
            {
                ToDoItem newItem = new ToDoItem();
                newItem.Title = NewTodoTitle;

                TodoItems.Add(newItem);

                NewTodoTitle = "";
            }
        }

        private bool CanAddItem()
        {
            return NewTodoTitle.Length > 0;
        }

        [RelayCommand]
        private void LoadData()
        {
            TodoItems = new ObservableCollection<ToDoItem>(TodoDb.GetTodoItems(10));
        }

        [RelayCommand]
        private void DeleteTodo(ToDoItem item)
        {
            TodoItems.Remove(item);
        }
    }
}
