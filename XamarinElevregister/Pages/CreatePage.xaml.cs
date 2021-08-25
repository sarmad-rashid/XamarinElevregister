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
    public partial class CreatePage : ContentPage
    {
        public CreatePage()
        {
            InitializeComponent();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            await SavePerson();
        }

        //sparar person i databasen
        private async Task SavePerson()
        {
            try
            {
                Person person = new Person();
                person.Fornamn = crtEditorFornamn.Text;
                person.Efternamn = crtEditorEfternamn.Text;
                person.Adress = "" + crtEditorAdress.Text;
                person.Personnummer = "" + crtEditorPersonnummer.Text;
                person.Telefonnummer = "" + crtEditorTelefonnummer.Text;
                person.Email = "" + crtEditorEmail.Text;
                person.Kommentarer = "" + crtEditorKommentarer.Text;
                
                await App.Database.InsertPersonAsync(person);               //skapa ny person
                
                var mainPage = new MainPage();
                mainPage.GetListAsync();                                    //refreshar listan i MainPage
                await this.Navigation.PushAsync(mainPage);                  //destination MainPage
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error, Save did not work", "(" + ex.Message + ")", "OK");
            }
        }
    }
}