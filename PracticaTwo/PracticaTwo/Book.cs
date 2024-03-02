using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaTwo
{
    public class Book
    {
        public int id { get; set; }
        public string ISBN { get; set; }
        public string title { get; set; }
        public int editionNumber { get; set; }
        public int yearOfPublication { get; set; }
        public string authors { get; set; }
        public string countryOfPublication { get; set; }
        public string synopsis { get; set; }
        public string career { get; set; }
        public string subject { get; set; }

        public Book(int id, string isbn, string title, int editionNumber, int year, string authors, 
            string country, string synopsis, string career, string subject) {
            this.id = id;
            ISBN= isbn;
            this.title = title;
            this.editionNumber = editionNumber;
            this.yearOfPublication = year;
            this.authors = authors;
            countryOfPublication = country;
            this.synopsis= synopsis;
            this.career= career;
            this.subject= subject;
        }
        public Book() { }
    }
}