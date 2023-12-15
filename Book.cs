using System;
using System.Collections.Generic;
namespace Lab1Loginov
{
    internal class Book
    {
        public Book(string title, string author, string genre, DateTime publicationDate, string isbn, string annotation)
        {
            this.Title = title;
            this.Author = author;
            this.Genre = genre;
            this.PublicationDate = publicationDate;
            this.ISBN = isbn;
            this.Annotation = annotation;
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ISBN { get; set; }
        public string Annotation { get; set; }

        public override string ToString()
        {
            return "Title: " + this.Title
                + ", Author: " + this.Author
                + ", Genre: " + this.Genre
                + ", PublicationDate: " + this.PublicationDate
                + ", ISBN: " + this.ISBN
                + ", Annotation: " + this.Annotation;
        }
    }
}