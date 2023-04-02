using Lab28_Aksana.Patrubeika_WebAPI.Data;
using Lab28_Aksana.Patrubeika_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab28_Aksana.Patrubeika_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : Controller
    {
        //private readonly ApiTestContext _context;
        private readonly ApiTestContext _context;

        public ContactsController(ApiTestContext context)
        {
            _context = context;
        }

        #region Lesson


        //[HttpGet]
        //public IEnumerable<Contact> Get()
        //{
        //    return _context.Contacts.ToList();
        //}

        //[HttpPost]
        //public IEnumerable<Contact> Post(AddContactsViewModel viewModel)

        //{
        //    var contact = new Contact()
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = viewModel.Name,
        //        Email = viewModel.Email,
        //        Phone = viewModel.Phone,
        //        Addres = viewModel.Addres
        //    };

        //    _context.Contacts.Add(contact);
        //    _context.SaveChanges();
        //    return _context.Contacts.ToList();
        //}

        //[HttpPut]   //update
        //[Route("{id:guid}")]
        //public IActionResult Put([FromRoute] Guid id, AddContactsViewModel viewModel) //посмотреть разницу IactionResult IEnumerable
        //{
        //    //класс AddContactsViewModel является перебивочным, данные с формы записываются в AddContactsViewModel, затем ищется id в Contact и заменяются там данные
        //    var contact = _context.Contacts.Find(id);
        //    if (contact != null)
        //    {
        //        contact.Name = viewModel.Name;
        //        contact.Email = viewModel.Email;
        //        contact.Phone = viewModel.Phone;
        //        contact.Addres = viewModel.Addres;

        //        _context.SaveChanges();

        //        return Ok(_context.Contacts.ToList());  //хз что за Ok
        //    }

        //    return NotFound();
        //}

        //[HttpDelete]
        //[Route("{id:guid}")]
        //public IActionResult Delete([FromRoute] Guid id)
        //{
        //    var contact = _context.Contacts.Find(id);
        //    if (contact != null)
        //    {
        //        _context.Contacts.Remove(contact);
        //        _context.SaveChanges();

        //        return Ok(_context.Contacts.ToList());  //хз что за Ok
        //    }
        //    return NotFound();
        //}
        #endregion

        

    }
}
