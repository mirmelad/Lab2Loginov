using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab1Loginov
{
    internal class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public void Add(Book book)
        {
            books.Add(book);
        }

        public IEnumerable<Book> Books
        {
            get { return books; }
        }

        public void Remove(Book book)
        {
            books.Remove(book);
        }

        public void Remove(string isbn)
        {
            books.RemoveAll(b => b.ISBN == isbn);
        }

        public IEnumerable<Book> Search(Predicate<Book> predicate)
        {
            return books.FindAll(predicate);
        }

        public IEnumerable<BookSearchResult> Search(params string[] keywords)
        {
            var searchResults = books.Select(book => new BookSearchResult
            {
                Book = book,
                MatchCount = CountKeywordMatches(book, keywords),
                KeywordMatchesInAnnotation = CheckKeywordMatchesInAnnotation(book, keywords)
            })
            .OrderByDescending(item => item.MatchCount)
            .Select(item => item);

            return searchResults;
        }

        private int CountKeywordMatches(Book book, string[] keywords)
        {
            int count = 0;
            foreach (string keyword in keywords)
            {
                if (book.Title.Contains(keyword))
                {
                    count++;
                }
                if (book.Author.Contains(keyword))
                {

                    count++;
                }
                if (book.Genre.Contains(keyword))
                {
                    count++;
                }
                if (book.ISBN.Contains(keyword))
                {
                    count++;
                }
                if (book.Annotation.Contains(keyword))
                {
                    count++;
                }
            }
            return count;
        }

        private bool CheckKeywordMatchesInAnnotation(Book book, string[] keywords)
        {
            foreach (string keyword in keywords)
            {
                if (book.Annotation.Contains(keyword))
                {
                    return true;
                }
            }
            return false;
        }

        public class BookSearchResult
        {
            public Book Book { get; set; }
            public int MatchCount { get; set; }
            public bool KeywordMatchesInAnnotation { get; set; }

            public override string ToString()
            {
                string temp;
                if (this.KeywordMatchesInAnnotation)
                {
                    temp = "Ключевые слова найдены в аннотации! ";
                }
                else
                {
                    temp = "";
                }
                return temp + "Title: " + Book.Title
                + ", Author: " + Book.Author
                + ", Genre: " + Book.Genre
                + ", PublicationDate: " + Book.PublicationDate
                + ", ISBN: " + Book.ISBN;
            }
        }

    }
}