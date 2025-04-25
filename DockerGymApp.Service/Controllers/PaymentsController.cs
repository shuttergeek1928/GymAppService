using DockerGymApp.Service.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DockerGymApp.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly GymAppPaymentServiceDbContext _context;

        public PaymentsController(GymAppPaymentServiceDbContext context)
        {
            _context = context;
        }

        // GET: api/<PaymentsController>
        [HttpGet]
        public ActionResult<IEnumerable<Payments>> Get()
        {
            return _context.Payments.ToList();
        }

        // GET api/<PaymentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Payments> Get(int id)
        {
            var payment = _context.Payments.Find(id);

            if (payment == null)
                return NotFound();
            
            return payment;
        }

        // POST api/<PaymentsController>
        [HttpPost]
        public ActionResult<Payments> Post(CreatePayment payment)
        {
            if (payment == null)
                return BadRequest("Payment data is null");

            var createPayment  = new Payments
            {
                UserId = payment.UserId,
                Amount = payment.Amount,
                PaymentStatus = payment.PaymentStatus switch
                {
                    "Pending" => PaymentStatus.Pending,
                    "Completed" => PaymentStatus.Completed,
                    "Failed" => PaymentStatus.Failed,
                    _ => PaymentStatus.NotStarted
                },
                PaymentDate = DateTime.Now
            };

            _context.Payments.Add(createPayment);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = payment.Id }, payment);
        }

        // PUT api/<PaymentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            var payment = _context.Payments.Find(id);

            if (payment == null)
                return NotFound();

            payment.PaymentStatus = value switch
            {
                "Pending" => PaymentStatus.Pending,
                "Completed" => PaymentStatus.Completed,
                "Failed" => PaymentStatus.Failed,
                _ => PaymentStatus.NotStarted
            };

            _context.Payments.Update(payment);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/<PaymentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var payment = _context.Payments.Find(id);
            
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
