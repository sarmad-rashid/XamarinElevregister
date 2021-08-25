using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinElevregister.Models;

namespace XamarinElevregister.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            InitializeComponent();
        }

        //uppdatera
        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            Person person = BindingContext as Person;
            var updatePage = new UpdatePage();
            updatePage.BindingContext = person;
            await this.Navigation.PushAsync(updatePage);        //destination: UpdatePage
        }

        //radera
        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            Person person = BindingContext as Person;           
            await App.Database.DeletePersonAsync(person.Id);    //delete person
            var mainPage = new MainPage();                      
            mainPage.GetListAsync();                            //uppdaterar listan i MainPage
            await this.Navigation.PushAsync(mainPage);          //destination: MainPage
        }
    }
}