using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class BooksRepository  
    {

        private List<Book> books = new List<Book>()
        
        {
           new Book (1,"batman", 200),
           new Book (2, "narnia", 400),
           new Book (3, "superman", 150),
           new Book (4, "kagemanden", 100),
           new Book (5, "kastanjemanden", 800)

        };

       
        public List <Book> GetBooks() 
        {
                    
            return new List < Book > (books);
        }

        public IEnumerable< Book > Get(string? titleIncludes = null, string? orderBy = null )
        {
            IEnumerable<Book> result = new List<Book> ();

            if(titleIncludes != null) 
            {
                result = result.Where(m => m.Title  > titleIncludes);
            }
            
            if(orderBy!= null) 
            {
                result = result.Where(m => m.Title.Contains (titleIncludes));            
            }

            if (priceLow != null)
            {
                priceLow = priceLow.ToLower();
                switch (priceLow)
                {
                    case "title": 
                    case "title_asc":
                        result = result.OrderBy(m => m.Title);
                        break;
                    case "title_desc":
                        result = result.OrderByDescending(m => m.Title);
                        break;
                    case "price":
                    case "price_asc":
                        result = result.OrderBy(m => m.price);
                        break;
                    case "price_desc":
                        result = result.OrderByDescending(m => m.price);
                        break;
                    default:
                        break; 
                }
            }
            return result;
        }

        public Book GetById(int id )
        {
            return books.Find(book => book.Id == id);
        }


        public Book Add(Book book)
        {
            Book.Validate();
            Book.Id = book.Id;
            books.Add(book);
            return book;

        }



    }

        

    
}
