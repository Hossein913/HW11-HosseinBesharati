using DapperCRUD.Models;
using DapperCRUD.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperCRUD.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ActionResult> Index()
        {
            var result = await _customerRepository.GetAllAsync();
            return View(result);
        }

        public async Task<ActionResult> Details(int id)
        {
            var result = await _customerRepository.GetByIdAsync(id);
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _customerRepository.Create(customer);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return RedirectToAction("Create");
                }

            }
            return View("Create", customer);


        }

        public async Task<ActionResult> Edit(int id)
        {
            var _customer = await _customerRepository.GetByIdAsync(id);
            return View(_customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    customer.Id = id;
                    await _customerRepository.Update(customer);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpDelete, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool CusotmerAddresses = true;
            if (!CusotmerAddresses)
            { 
                try
                {
                await _customerRepository.Delete(id);
                return RedirectToAction(nameof(Index));

                }
                catch
                {
                RedirectToAction(nameof(Index));
            }
            }
            return BadRequest();
        }
    }
}
