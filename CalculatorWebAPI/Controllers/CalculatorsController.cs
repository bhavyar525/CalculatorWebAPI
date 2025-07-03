using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CalculatorWebAPI;

namespace CalculatorWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorsController : ControllerBase
    {
        private readonly CalculatorContext _context;

        public CalculatorsController(CalculatorContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public async Task<ActionResult<Calculator>> Add(double a, double b)
        {
            var calc = new Calculator { Operand1 = a, Operand2 = b, Operation = "+", Result = a + b };
            _context.Calculators.Add(calc);
            await _context.SaveChangesAsync();
            return Ok(calc);
        }

        [HttpPost("subtract")]
        public async Task<ActionResult<Calculator>> Subtract(double a, double b)
        {
            var calc = new Calculator { Operand1 = a, Operand2 = b, Operation = "-", Result = a - b };
            _context.Calculators.Add(calc);
            await _context.SaveChangesAsync();
            return Ok(calc);
        }

        [HttpPost("multiply")]
        public async Task<ActionResult<Calculator>> Multiply(double a, double b)
        {
            var calc = new Calculator { Operand1 = a, Operand2 = b, Operation = "*", Result = a * b };
            _context.Calculators.Add(calc);
            await _context.SaveChangesAsync();
            return Ok(calc);
        }

        [HttpPost("divide")]
        public async Task<ActionResult<Calculator>> Divide(double a, double b)
        {
            if (b == 0) return BadRequest("Cannot divide by zero.");
            var calc = new Calculator { Operand1 = a, Operand2 = b, Operation = "/", Result = a / b };
            _context.Calculators.Add(calc);
            await _context.SaveChangesAsync();
            return Ok(calc);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calculator>>> GetAll()
        {
            return await _context.Calculators.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Calculator>> Get(int id)
        {
            var calc = await _context.Calculators.FindAsync(id);
            if (calc == null) return NotFound();
            return calc;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Calculator calculator)
        {
            if (id != calculator.Id) return BadRequest();
            _context.Entry(calculator).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var calc = await _context.Calculators.FindAsync(id);
            if (calc == null) return NotFound();
            _context.Calculators.Remove(calc);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
