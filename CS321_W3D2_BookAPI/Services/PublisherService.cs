using System.Collections.Generic;
using System.Linq;
using CS321_W3D2_BookAPI.Data;
using CS321_W3D2_BookAPI.Services;
using CS321_W3D2_BookAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace CS321_W3D2_BookAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly BookContext _bookcontext;

        public PublisherService(BookContext bookcontext)
        {
            _bookcontext = bookcontext;
        }

        //create
        public Publisher Add(Publisher publisher)
        {
            _bookcontext.Publishers.Add(publisher);
            _bookcontext.SaveChanges();
            return publisher;
        }

        //read
        public Publisher Get(int id)
        {
            return _bookcontext.Publishers
                .Include(p => p.Books)
                .SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Publisher> GetPublishers()
        {
            return _bookcontext.Publishers
                .Include(p => p.Books)
                .ToList();
        }

        //update
        public Publisher Update(Publisher publisher)
        {
            var currentPublisher = _bookcontext.Publishers.Find(publisher.Id);

            if (currentPublisher == null) return null;

            _bookcontext.Entry(currentPublisher)
                .CurrentValues
                .SetValues(publisher);

            _bookcontext.Publishers.Update(currentPublisher);
            _bookcontext.SaveChanges();

            return currentPublisher;
        }

        //delete
        public void Remove(Publisher publisher)
        {
            _bookcontext.Publishers.Remove(publisher);
            _bookcontext.SaveChanges();
        }
    }
}
