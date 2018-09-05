using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using InvestingMVC.Models;
using System.Threading.Tasks;

namespace InvestingMVC.Controllers.Api
{
    public class InvestingTaxController : ApiController
    {
        private MySqlContext _context;

        public InvestingTaxController()
        {
            _context = new MySqlContext();
        }

        // GET /api/InvestingTax  [Route("api/InvestingTax")]
        // public HttpResponseMessage GetInvestingTaxs(string query = null)
        public IHttpActionResult GetInvestingTaxs(string query = null, string dtDate = null)
        {
            var recsQuery = _context.records
                .Include(c => c._type);

            if (!String.IsNullOrWhiteSpace(query))
                recsQuery = recsQuery.Where(c => c.name.Contains(query));

            if (!string.IsNullOrWhiteSpace(dtDate))
            {
                DateTime dTmp;
                if (DateTime.TryParseExact(dtDate,
                                           "yyyyMMdd",
                                           System.Globalization.CultureInfo.InvariantCulture,
                                           System.Globalization.DateTimeStyles.None,
                                           out dTmp))
                {
                    recsQuery = recsQuery.Where(c => DbFunctions.TruncateTime(c.tradeDate) == (dTmp.Date));
                }
            }

            IList<InvestingTax> recDtos = recsQuery
                .ToList();

            // return Request.CreateResponse(HttpStatusCode.OK, recDtos, Configuration.Formatters.JsonFormatter);
            return Ok(recDtos);
        }

        // GET /api/InvestingTax/1
        public IHttpActionResult GetInvestingTax(int id)
        {
            var customer = _context.records.SingleOrDefault(c => c.id == id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateInvestingTax(InvestingTax recDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.records.Add(recDto);
            _context.SaveChanges();

            // customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + recDto.id), recDto);
        }


    }
}
