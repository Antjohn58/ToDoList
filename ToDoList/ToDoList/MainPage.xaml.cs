using ToDoList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using System.IO;

namespace ToDoList
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            toDoList.ItemsSource = await App.Database.GetListsAsync();
        }
        async void OnSubmitClicked(Object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(input.Text))
            {
                await App.Database.SaveListAsync(new List
                {
                    Item = input.Text,
                });
                input.Text = string.Empty;
                toDoList.ItemsSource = await App.Database.GetListsAsync();
            }
        }

        private async void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var checkbox = (CheckBox)sender;
            if (checkbox.BindingContext is List list)
            {
                list.IsComplete = e.Value;
                await App.Database.SaveListAsync(list);
            }
        }
    }
}