using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.UI.Models;

namespace Todo.UI.Data
{
    public static class TodoDb
    {
        //// Create fake data using Bogus data generator:
        //// https://github.com/bchavez/Bogus
        public static Faker<ToDoItem> fake = new Faker<ToDoItem>()
            .RuleFor(todo => todo.Title, (f, todo) => f.Lorem.Word())
            .RuleFor(todo => todo.Description, (f, todo) => f.Lorem.Sentence())
            .RuleFor(todo => todo.IsCompleted, (f, todo) => f.Random.Bool())
            .RuleFor(todo => todo.DueDate, (f, todo) => f.Date.Soon(7));

        public static List<ToDoItem> GetTodoItems(int numberOfItems)
        {
            List<ToDoItem> items = new List<ToDoItem>();

            for (int i = 0; i < numberOfItems; i++)
            {
                items.Add(fake.Generate());
            }

            return items;
        }
    }
}

// https://github.com/bchavez/Bogus
