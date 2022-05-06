using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingVS.Models;

namespace ShoppingVS.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ShoppingController : Controller
    {
        private readonly ShoppingVSContext _auc;

        public ShoppingController(ShoppingVSContext auc)
        {
            _auc = auc;
        }

        // [HttpPost]
        // //[ValidateAntiForgeryToken]  
        // public IActionResult Create(Users uc)
        // {
        //     _auc.Add(uc);
        //     _auc.SaveChanges();
        //     return Ok();
        // }
        [HttpPut]
        //[ValidateAntiForgeryToken]  
        public IActionResult Update(Users uc)
        {
            _auc.Update(uc);
            _auc.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public ActionResult GetViewResult()
        {
            var data = _auc.Users;
            return Ok(data);
        }
        [HttpPost]
        public ActionResult BulkData(List<Users> uc)
        {

            foreach (var i in uc)
            {
                _auc.Users.Add(i);
            }
            _auc.SaveChanges();
            return Ok();
        }
        //[HttpDelete("{id:int}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var User = await _auc.Users.FindAsync(id);
        //     if (User == null)
        //     {
        //         return NotFound();

        //     }
        //     _auc.Remove(User);
        //     await _auc.SaveChangesAsync();

        //     return Ok();
        // }
        [HttpDelete]
        public async Task<IActionResult> Delete(int[] id)
        {
            foreach (var i in id)
            {
                var User = await _auc.Users.FindAsync(i);
                _auc.Remove(User);
            }
            await _auc.SaveChangesAsync();
            return Ok();
        }

    }
}