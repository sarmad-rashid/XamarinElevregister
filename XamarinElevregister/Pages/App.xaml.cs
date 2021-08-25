using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinElevregister
{
    public partial class App : Application
    {
        private static DatabaseConnection database;
        public static DatabaseConnection Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Person.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            NavigationPage page = new NavigationPage(new MainPage());
            page.BarBackgroundColor = (Color)Application.Current.Resources["Purple700"];
            page.BarTextColor = Color.White;
            MainPage = page;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
