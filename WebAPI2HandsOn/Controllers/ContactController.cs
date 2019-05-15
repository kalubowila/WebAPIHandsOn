using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI2HandsOn.Models;

namespace WebAPI2HandsOn.Controllers
{
    [RoutePrefix("api/Contact")]
    public class ContactController : ApiController
    {
        Contact[] contacts = new Contact[]
        {
            new Contact{ ID = 1, FirstName = "Tharindu", LastName = "Kalubowila"},
            new Contact{ ID = 2, FirstName = "Rajitha", LastName = "Perera"},
            new Contact{ ID = 3, FirstName = "Dilan", LastName = "Gankanda"},
        };

        // GET: api/Contact
        [Route("")]
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }

        // GET: api/Contact/5
        [Route("{id:int:min(1)}")]  //Route Constraints
        public IHttpActionResult Get(int id)
        {
            Contact contact = contacts.Where(x => x.ID == id).FirstOrDefault();

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        //[ActionName("ContactName")]
        [HttpGet]
        [Route("{name}")]
        public IEnumerable<Contact> GetContactByName(string name)
        {
            return contacts.Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name));
        }

        // POST: api/Contact
        [Route("")]
        public IEnumerable<Contact> Post([FromBody]Contact newContact)
        {
            List<Contact> contactList = contacts.ToList();
            newContact.ID = contactList.Count + 1;
            contactList.Add(newContact);
            contacts = contactList.ToArray();

            return contacts;
        }

        // PUT: api/Contact/5
        [Route("{id:int}")]
        public IEnumerable<Contact> Put(int id, [FromBody]Contact updatedContact)
        {
            Contact contact = contacts.Where(x => x.ID == id).FirstOrDefault();
            if (contact != null)
            {
                contact.FirstName = updatedContact.FirstName;
                contact.LastName = updatedContact.LastName;
            }
            return contacts;
        }

        // DELETE: api/Contact/5
        [Route("{id:int}")]
        public IEnumerable<Contact> Delete(int id)
        {
            contacts = contacts.Where(x => x.ID != id).ToArray();
            return contacts;
        }
    }
}
