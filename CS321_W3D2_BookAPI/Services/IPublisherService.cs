using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D2_BookAPI.Models;

namespace CS321_W3D2_BookAPI.Services
{
    public interface IPublisherService
    {
        // CRUDL - Create (add), Read (get), Update, Delete (remove)

        //create 
        Publisher Add(Publisher publisher);

        //read
        Publisher Get(int id);

        //update
        Publisher Update(Publisher publisher);

        //delete
        void Remove(Publisher publisher);

        IEnumerable<Publisher> GetPublishers();
    }
}
