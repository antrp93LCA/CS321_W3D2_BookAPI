using System;
using System.ComponentModel.DataAnnotations;

namespace CS321_W3D2_BookAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        //Properties relating to Author model 
        public int AuthorId { get; set; }
        //Navigational property for EF to map in db
        public Author Author { get; set; }

        //properties relating to Publisher model
        public int PublisherId { get; set; }
        //navigational property for EF to map in db
        public Publisher Publisher { get; set; }
    }
}
