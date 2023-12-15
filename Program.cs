using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Lab1Loginov
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Library library = new Library();
            while (true)
            {
                Console.WriteLine("Выберете операцию:");
                Console.WriteLine("1 - добавление книги в каталог");
                Console.WriteLine("2 - выбрать книгу");
                Console.WriteLine("3 - выход");
                string operation = Console.ReadLine();
                switch (operation)
                {
                    case "1":
                        Console.WriteLine("Введите название книги:");
                        string title = Console.ReadLine();
                        Console.WriteLine("Введите автора книги:");
                        string author = Console.ReadLine();
                        Console.WriteLine("Введите жанр книги:");
                        string genre = Console.ReadLine();
                        Console.WriteLine("Введите ISBN книги:");
                        string isbn = Console.ReadLine();
                        Console.WriteLine("Введите аннотацию");
                        string annotation = Console.ReadLine();
                        Console.WriteLine("Введите дату публикации книги (в формате ГГГГ-ММ-ДД):");
                        bool isValidDate = false;
                        DateTime publicationDate;
                        string inputDate = Console.ReadLine();
                        isValidDate = DateTime.TryParse(inputDate, out publicationDate);
                        while (!isValidDate)
                        {
                            Console.WriteLine("Неверный формат даты. Пожалуйста, введите дату в правильном формате.");
                            inputDate = Console.ReadLine();
                            isValidDate = DateTime.TryParse(inputDate, out publicationDate);
                        }
                        Book newBook = new Book(title, author, genre, publicationDate, isbn, annotation);
                        library.Add(newBook);
                        Console.WriteLine("Книга успешно добавлена в каталог.");
                        break;
                    case "2":
                        Console.WriteLine("Выберете по чему производить поиск:");
                        Console.WriteLine("1 - Названию или его фрагменту");
                        Console.WriteLine("2 - имени автора");
                        Console.WriteLine("3 - ключевым словам");
                        string choose = Console.ReadLine();
                        switch (choose)
                        {
                            case "1":
                                Console.WriteLine("Введите название книги или его часть:");
                                string searchTitle = Console.ReadLine();
                                Predicate<Book> titlePredicate = book => book.Title.Contains(searchTitle);
                                IEnumerable<Book> foundBooks = library.Search(titlePredicate);
                                if (foundBooks.Any())
                                {
                                    Console.WriteLine("Книги найдены!");
                                    foreach (var book in foundBooks)
                                    {
                                        Console.WriteLine(book.ToString());
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Книга не найдена.");
                                }
                                break;
                            case "2":
                                Console.WriteLine("Введите имя автора:");
                                string searchAuthor = Console.ReadLine();
                                Predicate<Book> authorPredicate = book => book.Author.Contains(searchAuthor);
                                IEnumerable<Book> foundBooks2 = library.Search(authorPredicate);
                                if (foundBooks2.Any())
                                {
                                    Console.WriteLine("Книги найдены!");
                                    foreach (var book in foundBooks2)
                                    {
                                        Console.WriteLine(book.ToString());
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Книга не найдена.");
                                }
                                break;
                            case "3":
                                Console.WriteLine("Введите ключевые слова:");
                                string[] searchKeyWords = Console.ReadLine().Split();
                                IEnumerable<Library.BookSearchResult> foundBooks3 = library.Search(searchKeyWords);
                                if (foundBooks3.Any())
                                {
                                    Console.WriteLine("Книги найдены!");
                                    foreach (var book in foundBooks3)
                                    {
                                        Console.WriteLine(book.ToString());
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Книга не найдена.");
                                }
                                break;
                            default:
                                Console.WriteLine("Неверная операция. Пожалуйста, выберите 1, 2 или 3.");
                                break;
                        }
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неверная операция. Пожалуйста, выберите 1, 2 или 3.");
                        break;
                }
            }
        }
    }
}