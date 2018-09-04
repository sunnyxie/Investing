using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvestingMVC.Models;
using System.Data.Entity;
using System.Threading.Tasks;

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
                mo.tradeDate = DateTime.Now;
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
                DateTime settleDate = taxObj.tradeDate.AddDays(Constants.Values.MaxWaitingDays);
                tmp.name = taxObj.name.ToUpper();
                if (settleDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    settleDate.AddDays(1);
                }
                else if (settleDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    settleDate.AddDays(2);
                }

                if (settleDate.Month == 7 & settleDate.Day == 1)   // Canada Day
                {
                    settleDate.AddDays(1);
                }

                tmp.settleDate = settleDate;
                _context.InsertNewRec(tmp);
                _context.SaveChanges();

                //Api.AlphaVantageApiWrapper.AlphaVantageRootObject resl = await quotes;
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Insert new InvestingTax: " + ex.Message);
                return Create();
            }


            // db Function TruncateTime created at database side.
            //var records = _context.records.Where(r => DbFunctions.TruncateTime(r.tradeDate)
            //                                                      == DateTime.Today)
            //                                              .Include(r => r._type)
            //                                              .OrderByDescending(r => r.tradeDate)
            //                                              .ToList();
            ViewBag.recList = null;

            ViewBag.DefBuyingCount = Constants.Values.DefBuyingCount;
            ViewBag.DefCommissionFee = Constants.Values.DefCommissionFee;

            //   var MyStates = new SelectList(new[]
            //{
            //    new { ID="1", Name="name1" },
            //    new { ID="2", Name="name2" },
            //    new { ID="3", Name="name3" },
            //}, "id", "name", -1);
            // ViewBag.MyStates = Newtonsoft.Json.JsonConvert.SerializeObject(MyStates);

            return View("CreateView2", null);
            //  return View("CreateView", null);
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

        protected async Task GetQuotesAsync(string name)
        {
            //Task<Api.AlphaVantageApiWrapper.AlphaVantageRootObject> quotes =
            //       Api.StockQuote.GetTheQuoteAsync(name, 1);

            //Api.AlphaVantageApiWrapper.AlphaVantageRootObject resl = await quotes;
        }
    }
}
