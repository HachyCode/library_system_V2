using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;

namespace library_system
{
    class App : FileType
    {
        private ILibraryHelper libraryHelper = Factory.CreatLibraryHelper();

        public void Run()
        {
            CurrentTime time = new CurrentTime();//Creats time object
            while (true)
            {
                Console.Clear();
                time.Update();//Update and displays time
                time.Display();

                FileTypeSeting();

                Select();

                FileTypeSaving();

                Console.ReadKey(true);
            }
        }
        private static string Input(string prompt)
        {
            Console.Write(prompt + ": ");
            return Console.ReadLine();
        }

        private void Select()
        {
            bool done = false;

            string another = Input("Add a book y/n"); //Asks; calls intup method
            if (another == "n")
            {
                done = true;
            }

            while (!done) //if used selected yes
            {
                Console.Clear();
                Console.WriteLine("Select a category:");
                for (int i = 0; i < libraryHelper.Categories.Count; i++)
                {
                    Console.WriteLine(i + ": " + libraryHelper.Categories[i]); //displays list of book types, a manu
                }

                int selectedCategoryID = 0;
                bool validID = false;

                do //cheak if input is valid
                {
                    try
                    {
                        selectedCategoryID = Convert.ToInt32(Console.ReadLine());
                        if (selectedCategoryID >= 0 && selectedCategoryID < libraryHelper.Categories.Count)
                        {
                            validID = true;
                        }
                        else
                        {
                            Console.WriteLine("Option not available. Please try again");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.WriteLine("Please try again");
                    }
                } while (!validID);

                string selectedCategory = libraryHelper.Categories[selectedCategoryID];//displays selection
                Console.WriteLine("You have sected {0}", selectedCategory);

                string title = Input("Title");//asks for book info
                string author = Input("Author");
                string publisher = Input("Publisher");
                string dateOfPublication = Input("Date of publication");

                books.Add(new Book(title, author, publisher, dateOfPublication, selectedCategory));//Add the book to the list

                another = Input("Add another? y/n");
                if (another == "n")
                {
                    done = true;
                }
            }

            Console.Clear();
            Console.WriteLine("All books in library\n");
            foreach (var book in books)
            {
                book.Display();//displays all the books
            }
        }
    }
}

