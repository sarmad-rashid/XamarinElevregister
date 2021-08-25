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
    public partial class UpdatePage : ContentPage
    {
        public UpdatePage()
        {
            InitializeComponent();
        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            await UpdatePerson();
        }

        //uppdaterar person
        private async Task UpdatePerson()
        {
            try
            {
                Person person = BindingContext as Person;                   //
                person.Fornamn = updEditorFornamn.Text;                     //
                person.Efternamn = updEditorEfternamn.Text;                 //
                person.Adress = updEditorAdress.Text;                       //
                person.Personnummer = updEditorPersonnummer.Text;           //
                person.Telefonnummer = updEditorTelefonnummer.Text;         //
                person.Email = updEditorEmail.Text;                         //
                await App.Database.UpdatePersonAsync(person);               //update person
                var mainPage = new MainPage();
                mainPage.GetListAsync();                                    //uppdaterar listan i MainPage
                await this.Navigation.PushAsync(mainPage);                  //destination: Main Page
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Update did not work. (" + ex.Message + ")", "OK");
            }
        }
    }
}