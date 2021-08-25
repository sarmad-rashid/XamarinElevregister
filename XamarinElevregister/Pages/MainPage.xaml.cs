using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinElevregister.Models;
using XamarinElevregister.Pages;

namespace XamarinElevregister
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            GetListAsync();
        }

        //connect listview with personList
        public async void GetListAsync()
        {
            lstPerson.ItemsSource = await App.Database.GetPersonListAsync();
        }

        //navigate to CreatePage
        private async void btnCreate_Clicked(object sender, EventArgs e)
        {
            var createPage = new CreatePage();               //Next destination: Create Page
            await this.Navigation.PushAsync(createPage);     //
        }

        //searchbar button
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var search = await App.Database.LinqSearchAsync(sbar.Text);
            lstPerson.ItemsSource = search;
            sbar.Text = null;
        }

        //searchbar
        private async void sbar_Completed(object sender, EventArgs e)
        {
            var search = await App.Database.LinqSearchAsync(sbar.Text);
            lstPerson.ItemsSource = search;
            sbar.Text = null;
        }

        //navigate to DetailPage
        private async void lstPerson_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;                                                         //when item is being deselected, return is set to null
            }

            Person person = (Person)e.Item;                                     //storing clicked object
            var detailsPage = new DetailsPage();                                //create instans of DetailsPage
            detailsPage.BindingContext = person;                                //bindingContext to "Person" object
            await this.Navigation.PushAsync(detailsPage);                       //navigate to DetailsPage
        }
    }
}
