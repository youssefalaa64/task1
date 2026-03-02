using System.Reflection;

namespace task4_library
{
    class Book
    {
        public string Title;
        public string Author;
        public string ISNB;
        public bool Availability;

        public Book(string Title, string Author, string ISNB, bool Availability)
        {
            this.Title = Title;
            this.Author = Author;
            this.ISNB = ISNB;
            this.Availability = true;
        }
    }

    class Library
    {
        public List<Book> Book_Collection = new ();

        public void Add_Book(Book Book_name)
        {
            Book_Collection.Add(Book_name);
            Console.WriteLine($"book {Book_name.Title} added");
        }
        
        public void Search_book(string search)
        {
            for(int i = 0; i< Book_Collection.Count ;i++)
            {
                if (Book_Collection[i].Title ==search || Book_Collection[i].Author == search)
                {
                    Console.WriteLine("book found");
                    Console.WriteLine($"book title is {Book_Collection[i].Title}");
                    break;
                }
                
            }
        }
        
        public bool borrow_book(string book)
        {
            
                bool borrowed = true;
            for (int i = 0; i < Book_Collection.Count; i++)
            {
                if (Book_Collection[i].Title == book && Book_Collection[i].Availability)
                {
                    Book_Collection[i].Availability = false;
                    Console.WriteLine($"the book {Book_Collection[i].Title} is borrowed");
                    borrowed = true;
                    return true;
                    
                }



            }
            Console.WriteLine("book not found");
            return false;

        }
        public bool return_book(string book)
        {
            for(int i =0; i<Book_Collection.Count; i++)
            {
                if (Book_Collection[i].Title == book && !Book_Collection[i].Availability)
                {
                    Book_Collection[i].Availability = true;
                    Console.WriteLine("book is returned");
                    return true;
                }
                

            }
            
            
            Console.WriteLine("invalid book");
            return false;


        }
        
        
    
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("the way of the superior man", "david dida", "bbbb", true);
            Book book2 = new Book("outliers", "Malcolm Gladwell", "aaaa", true);

            Library library1 = new Library();
            library1.Add_Book(book1);
            library1.Add_Book(book2);

            library1.Search_book("david dida");
            library1.Search_book("Malcolm Gladwell");

          
            library1.borrow_book("outliers");
            library1.borrow_book("the way of the superior man");
            
            
            library1.return_book("outliers");
            library1.return_book("the way of the superior man");
            library1.return_book("the way of the superior man");




            //search task  
            //https://docs.google.com/document/d/1YlcqXEowM-6V1urd4CR5Z2cJmqnPg1SuP2PNmP4O5Uk/edit?usp=sharing





        }
    }
}
