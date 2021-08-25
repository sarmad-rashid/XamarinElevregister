using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinElevregister.Models
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Fornamn { get; set; }
        public string Efternamn { get; set; }
        public string Personnummer { get; set; }
        public string Adress { get; set; }
        public string Telefonnummer { get; set; }
        public string Email { get; set; }
        public string Kommentarer { get; set; }
    }
}
