using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinElevregister.Models;

namespace XamarinElevregister
{
    public class DatabaseConnection
    {
        readonly SQLiteAsyncConnection db;
        public DatabaseConnection(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Person>().Wait();
        }

        //search function
        public async Task<List<Person>> LinqSearchAsync(string search)
        {
            try
            {
                if (search == null)
                {
                    return await db.Table<Person>().ToListAsync();
                }
                else
                {
                    return await db.Table<Person>().Where(p => p.Fornamn.ToLower().Contains(search.ToLower()) || p.Efternamn.ToLower().Contains(search.ToLower()) || p.Personnummer.Contains(search)).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "The function did not work. (" + ex.Message + ")", "OK");
                return null;
            }
        }

        //Get Person by Id
        public async Task<Person> GetPersonById(int id)
        {
            try
            {
                Person person = await db.Table<Person>().Where(i => i.Id == id).FirstOrDefaultAsync();
                return person;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "The function did not work. (" + ex.Message + ")", "OK");
                return null;
            }
        }

        //Create
        public async Task InsertPersonAsync(Person createPerson)
        {
            try
            {
                //Check if already exists
                Person person = await db.Table<Person>().Where(i => i.Id == createPerson.Id).FirstOrDefaultAsync();
                if (person == null)
                {
                    var id = await db.InsertAsync(createPerson);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "The function did not work. (" + ex.Message + ")", "OK");
            }
        }

        //Read
        public async Task<List<Person>> GetPersonListAsync()
        {
            try
            {
                return await db.Table<Person>().ToListAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "The function did not work. (" + ex.Message + ")", "OK");
                return null;
            }
        }

        //Update
        public async Task UpdatePersonAsync(Person updatePerson)
        {
            try
            {
                await db.UpdateAsync(updatePerson);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "The function did not work. (" + ex.Message + ")", "OK");
            }
        }

        //Delete
        public async Task DeletePersonAsync(int personId)
        {
            try
            {
                //Check if exists
                Person person = await db.Table<Person>().Where(i => i.Id == personId).FirstOrDefaultAsync();
                //Delete if exists
                if (person != null)
                    await db.DeleteAsync<Person>(personId);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "The function did not work. (" + ex.Message + ")", "OK");
            }
        }
    }
}
