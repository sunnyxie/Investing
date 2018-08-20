using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvestingMVC.Models;
using System.Data.Entity;

namespace InvestingMVC.Controllers
{
    public class InvestingTaxController : Controller
    {
        private static MySqlContext _context; 

        static InvestingTaxController()
        {
            _context = Startup.gSqlContext;
        }
        // GET: InvestingTax
        public ActionResult Index()
        {
            // Startup.gSqlContext.records.Load();

            return View(_context.records.Include(r => r._type).ToList());
        }


        // Create view with day history recs.
        public ActionResult Create(int nShowDayHistory = 0)
        {
            try
            {
                InvestingMVC.Models.InvestingTax mo = new InvestingMVC.Models.InvestingTax();
                ViewBag.DefBuyingCount = Constants.Values.DefBuyingCount;
                ViewBag.DefCommissionFee = Constants.Values.DefCommissionFee;

                return View("CreateView", mo);

                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in retrieve records: " + ex.Message);
                return Create();
            }
        }
        // GET: InvestingTax/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: InvestingTax/Create
        [HttpPost]
        public ActionResult Create(InvestingTax taxObj)
        {
            try
            {
                InvestingTax tmp = taxObj.ShallowCopy();
                //tmp.Comments = taxObj.Comments;
                tmp.name = taxObj.name.ToUpper();
                tmp.settleDate = taxObj.tradeDate.AddDays(Constants.Values.MaxWaitingDays);
                _context.InsertNewRec(tmp);
                _context.SaveChanges();

                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Insert new InvestingTax: " + ex.Message);
                return Create();
            }


            // db Function TruncateTime created at database side.
            ViewBag.recList = _context.records.Where(r => DbFunctions.TruncateTime(r.tradeDate)
                                                                  == DateTime.Today)
                                                          .Include(r => r._type)
                                                          .OrderByDescending(r => r.tradeDate)
                                                          .ToList();
            ViewBag.DefBuyingCount = Constants.Values.DefBuyingCount;
            ViewBag.DefCommissionFee = Constants.Values.DefCommissionFee;
            return View("CreateView", null);
        }

        // GET: InvestingTax/Edit/5
        //[HttpPost]
        public ActionResult Create3(string name)
        {
            InvestingMVC.Models.InvestingTax mo = new InvestingMVC.Models.InvestingTax();
            mo.comments = name;
            return View("CreateView", mo);
        }

        // POST: InvestingTax/Edit/5
        //[HttpPost]
        public ActionResult Edit(int id)
        {
            var tran = _context.records.SingleOrDefault(c => c.id == id);

            if (tran == null)
                return HttpNotFound();

            //var viewModel = new CustomerFormViewModel
            //    MembershipTypes = _context.MembershipTypes.ToList()
            //};
            ViewBag.DefBuyingCount = Constants.Values.DefBuyingCount;
            ViewBag.DefCommissionFee = Constants.Values.DefCommissionFee;

            return View("CreateView", tran);
        }

        // GET: InvestingTax/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvestingTax/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
