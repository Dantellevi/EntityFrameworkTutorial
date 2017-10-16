using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parallelizm.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Parallelizm.Controllers
{
    /*
     * При работе с Entity Framework, когда у нас
     *  одновременно множесво пользователей имеют
     *   доступ к одинаковому набору данных и могут
     *    эти данные изменять, мы можем столкнуться с проблемой параллелизма.
     *     Например, два пользователя независимо друг от друга начнут редактировать один
     *      и тот же объект. И после сохранения объекта первым пользователем второй пользователь
     *       уже будет работать с неактуальными данными.
     * 
     * */

    public class HomeController : Controller
    {
        Context db = new Context();

        public ActionResult Edit(int id)
        {
            Person p = db.Persons.Find(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(Person p)
        {
            try
            {
                
                //db.Entry(p).State = EntityState.Modified;
                //db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ViewBag.Error = "Объект ранее уже был изменен";
                return View(p);
            }
            return RedirectToAction("Index");
        }
    }
}