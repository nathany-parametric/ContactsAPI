using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DemoContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private int _contactId = 3;
        List<Contact> contacts = new List<Contact>
        {
            new Contact
            {
                Id = 1,
                Name = "Bob",
                Email = "bob@bob.com"
            },
            new Contact
            {
                Id = 2,
                Name = "Bill",
                Email = "bill@bill.com"
            }
        };


        // GET: api/Contacts
        [HttpGet]
        [ProducesResponseType(200), ProducesResponseType(404)]
        public ActionResult<IEnumerable<Contact>> Get()
        {
            return contacts;

        }

        // GET: api/Contacts/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(200), ProducesResponseType(404)]
        public ActionResult<Contact> GetById(int id)
        {
            return contacts.SingleOrDefault(c => c.Id == id);
        }

        // POST: api/Contacts
        [HttpPost]
        [ProducesResponseType(200), ProducesResponseType(404)]
        public ActionResult<Contact> Post([FromBody] Contact contact)
        {
            contact.Id = _contactId++;
            contacts.Add(contact);

            return contact;
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        [ProducesResponseType(200), ProducesResponseType(404)]
        public ActionResult<Contact> Put(int id, [FromBody] Contact contact)
        {
            var existingContact = contacts.SingleOrDefault(c => c.Id == id);

            if (existingContact != null)
            {
                existingContact.Email = contact.Email;
                existingContact.Name = contact.Name;
            }

            return existingContact;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200), ProducesResponseType(404)]
        public bool Delete(int id)
        {
            var deleted = contacts.Remove(contacts.SingleOrDefault(c => c.Id == id));
            return deleted;
        }
    }
}
//dotnet publish --configuration Release