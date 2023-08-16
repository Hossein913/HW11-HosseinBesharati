using DapperCRUD.Models;
using DapperCRUD.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace DapperCRUD.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ICustomerRepository _customerRepository;
        public AddressController(IAddressRepository addressRepository, ICustomerRepository customerRepository)
        {
            _addressRepository = addressRepository;
            this._customerRepository = customerRepository;
        }


        public async Task<ActionResult> Index(int id)
        {
            var result = await _addressRepository.GetByCustomer(id);
            return View(result);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Address _address)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _addressRepository.Create(_address);
                    return RedirectToAction("Index","Customer");
                }
                catch
                {
                    return RedirectToAction("Create");
                }

            }
            return View(_address);


        }

        //public async Task<ActionResult> Edit(int id)
        //{
        //    var _address = await _addressRepository.GetByIdAsync(id);
        //    return View(_address);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit(int id, Address address)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            address.Id = id;
        //            await _addressRepository.Update(address);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(address);
        //}

        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //[HttpDelete, ActionName("DeleteConfirmed")]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    bool CusotmerAddresses = true;
        //    if (!CusotmerAddresses)
        //    {
        //        try
        //        {
        //            await _addressRepository.Delete(id);
        //            return RedirectToAction(nameof(Index));

        //        }
        //        catch
        //        {
        //            RedirectToAction(nameof(Index));
        //        }
        //    }
        //    return BadRequest();
        //}
    }
}
