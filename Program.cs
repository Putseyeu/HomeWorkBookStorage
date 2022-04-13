using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkBookStorage2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            Storage storage = new Storage();

            while (userInput != "7")
            {
                Console.WriteLine("Информация о хранилище книг. Выберите действие.");
                Console.WriteLine(" 1 - Добавить книгу.\n 2 - Убрать книгу.\n 3 - Показать все книги.\n" +
                    " 4 - Показать книгу по названию.\n 5 - Показать книгу по автору.\n 6 - Показать книгу по году публикации.\n" +
                    " 7 - Выйти из базы данных.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        storage.AddBook();
                        break;

                    case "2":
                        storage.DeleteBook();
                        break;

                    case "3":
                        storage.ShowInfo();
                        break;

                    case "4":
                        storage.ShowSearchName();
                        break;

                    case "5":
                        storage.ShowSearchSinger();
                        break;

                    case "6":
                        storage.ShowSearchYear();
                        break;
                }

                Console.WriteLine();
            }
        }

        class Book
        {
            public string Name { get; private set; }
            public string Singer { get; private set; }
            public int YearPublishing { get; private set; }

            public Book()
            {
                InputName();
                InputSinger();
                InputYearPublishing();
            }

            private void InputName()
            {
                Console.WriteLine("Введите название книги");
                Name = Console.ReadLine();
            }

            private void InputSinger()
            {
                Console.WriteLine("Введите автора книги");
                Singer = Console.ReadLine();
            }

            private void InputYearPublishing()
            {
                Console.WriteLine("Введите год публикации книги");
                bool completed = false;
                int intValue = 0;
                while (completed == false)
                {
                    string userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out intValue))
                    {
                        completed = true;
                    }
                    else
                    {
                        Console.WriteLine($"Не коректный ввод данных.");
                    }
                }

                YearPublishing = intValue;
            }
        }

        class Storage
        {
            private List<Book> _books = new List<Book>();

            public void AddBook()
            {
                _books.Add(new Book());
            }

            public void DeleteBook()
            {
                if (_books.Count > 0)
                {
                    if (TryGetPlayer(out Book book))
                    {
                        Console.WriteLine($"Книга удалена");
                        _books.Remove(book);
                    }
                }
                else
                {
                    Console.WriteLine("База данных не заполнена.");
                }
            }

            public void ShowInfo()
            {
                if (_books.Count > 0)
                {
                    for (int i = 0; i < _books.Count; i++)
                    {
                        Console.WriteLine($" Порядковый номер {i + 1} | Название книги - {_books[i].Name}" +
                            $" | Автора книги - {_books[i].Singer}| Год публикации - {_books[i].YearPublishing}.");
                    }
                }
                else
                {
                    Console.WriteLine("Информация о книгах не заполнена.");
                }
            }

            public void ShowSearchName()
            {
                string userInput;
                bool bookFound = false;
                Console.WriteLine("Введите название книги.");
                userInput = Console.ReadLine();

                for (int i = 0; i < _books.Count; i++)
                {
                    if (userInput == _books[i].Name)
                    {
                        bookFound = true;
                        Console.WriteLine($"Название книги - {_books[i].Name}" +
                            $" | Автора книги - {_books[i].Singer}| Год публикации - {_books[i].YearPublishing}.");
                    }
                }

                if (bookFound == false)
                {
                    Console.WriteLine("Книга по названию не найдена.");
                }
            }

            public void ShowSearchSinger()
            {
                string userInput;
                bool bookFound = false;
                Console.WriteLine("Введите автора книги.");
                userInput = Console.ReadLine();
                for (int i = 0; i < _books.Count; i++)
                {
                    if (userInput == _books[i].Singer)
                    {
                        bookFound = true;
                        Console.WriteLine($"Название книги - {_books[i].Name}" +
                            $" | Автора книги - {_books[i].Singer}| Год публикации - {_books[i].YearPublishing}.");
                    }
                }

                if (bookFound == false)
                {
                    Console.WriteLine($"Книг автора {userInput} в хранилище не найдено.");
                }
            }

            public void ShowSearchYear()
            {
                string userInput;
                bool bookFound = false;
                Console.WriteLine("Введите год публикации книги.");
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int intValue))
                {
                    for (int i = 0; i < _books.Count; i++)
                    {
                        if (intValue == _books[i].YearPublishing)
                        {
                            bookFound = true;
                            Console.WriteLine($"Название книги - {_books[i].Name}" +
                                $" | Автора книги - {_books[i].Singer}| Год публикации - {_books[i].YearPublishing}.");
                        }
                    }

                    if (bookFound == false)
                    {
                        Console.WriteLine($"Книг издания {userInput} года в хранилище не найдено.");
                    }
                }
                else
                {
                    Console.WriteLine("Не коректный ввод года публикации");
                }    
            }

            private bool TryGetPlayer(out Book book)
            {
                book = null;
                Console.WriteLine("Введите порядковый номер книги");
                string indexBook = Console.ReadLine();
                if (int.TryParse(indexBook, out int intValue))
                {
                    intValue--;
                    if (intValue < _books.Count && intValue >= 0)
                    {
                        book = _books[intValue];
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Книга с порядковым номером {intValue + 1} отсутствует.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Не верный порядковый номер книги");
                }

                return false;
            }
        }
    }
}