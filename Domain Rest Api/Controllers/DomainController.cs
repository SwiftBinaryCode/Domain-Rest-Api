using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Domain_Rest_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainController : ControllerBase
    {
        private readonly DataContext _context;

        public DomainController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Domain>>> GetDomains()
        {

            return Ok(await _context.Domains.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Domain>> GetDomainById(int id)
        {
            var domain = await _context.Domains.FindAsync(id);
            if (domain == null)
                return BadRequest("Domain not found.");
            return Ok(domain);
        }


        [HttpPost]
        public async Task<ActionResult<List<Domain>>> AddDomain(Domain domain)
        {
         
            _context.Domains.Add(domain);
            await _context.SaveChangesAsync();

            return Ok(await _context.Domains.ToListAsync());
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<List<Domain>>> UpdateOwnerName(Domain request)
        {
            var dbDomain = await _context.Domains.FindAsync(request.Id);
            if (dbDomain == null)
                return BadRequest("Domain not found.");

            dbDomain.OwnerName = request.OwnerName;
            dbDomain.TimeUpdated = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(await _context.Domains.ToListAsync());
        }




        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Domain>>> DeleteDomainById(int id)
        {
            var dbDomain = await _context.Domains.FindAsync(id);
            if (dbDomain == null)
                return BadRequest("Hero not found.");

            _context.Domains.Remove(dbDomain);
            await _context.SaveChangesAsync();

            return Ok(await _context.Domains.ToListAsync());
        }
    }
}
