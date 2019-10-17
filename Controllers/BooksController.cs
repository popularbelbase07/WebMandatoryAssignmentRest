using BookLibrary.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebMandatoryAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
       
        public static readonly List<Book> bookList=new List<Book>()
        {
            new Book("New Moon","Robert Lynistar",400,"12346geh63dg1"),
            new Book("Harry Potter","J:K Rolling",800,"162gSuw72gwV3"),
            new Book("You Can Win" ,"Shiva Khera",300,"7493GS832YHc2"),
            new Book("Capital" ,"Karl Marx",250,"2648gd837GBS4"),
            new Book("Muna Madan","Laxmi Prashad Devkota",900,"LA12xm19I45po")

        };

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bookList;
        }
        // GET: api/Books/5
        [HttpGet]
        [Route("{isbn}")]
       public Book Get(string isbn)
        {
            return bookList.Find(i => i.ISBN == isbn);
        }

        // POST: api/Books
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            bookList.Add(value);
        }

        // PUT: api/Books/523hjsdjj232
        [HttpPut("{isbn}")]
        public void Put(string isbn, [FromBody] Book value)
        {
            Book bok = Get(isbn);
            if (bok != null)
            {
                bok.Title = value.Title;
                bok.Author = value.Author;
                bok.PageNO = value.PageNO;
                bok.ISBN = value.ISBN;
            }


        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{isbn}")]
        public void Delete(string isbn)
        {
            Book bok = Get(isbn);
            bookList.Remove(bok);
        }



    }
}
