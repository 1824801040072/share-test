using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.HienThi;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonViVanTaisController : ControllerBase
    {
        private readonly LuuTru<Models.DonViVanTai> _LuuTruRepository;

        private readonly APIDbContext _context;

        public DonViVanTaisController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/DonViVanTais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonViVanTai>>> GetDonViVanTais()
        {
          if (_context.DonViVanTais == null)
          {
              return NotFound();
          }
            return await _context.DonViVanTais.ToListAsync();
        }

        // GET: api/DonViVanTais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonViVanTai>> GetDonViVanTai(Guid id)
        {
          if (_context.DonViVanTais == null)
          {
              return NotFound();
          }
            var donViVanTai = await _context.DonViVanTais.FindAsync(id);

            if (donViVanTai == null)
            {
                return NotFound();
            }

            return donViVanTai;
        }

        // PUT: api/DonViVanTais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonViVanTai(Guid id, DonViVanTai donViVanTai)
        {
            if (id != donViVanTai.Uuid)
            {
                return BadRequest();
            }

            _context.Entry(donViVanTai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonViVanTaiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DonViVanTais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DonViVanTai>> PostDonViVanTai(DonViVanTai donViVanTai)
        {
          if (_context.DonViVanTais == null)
          {
              return Problem("Entity set 'APIDbContext.DonViVanTais'  is null.");
          }
            _context.DonViVanTais.Add(donViVanTai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonViVanTai", new { id = donViVanTai.Uuid }, donViVanTai);
        }

        // DELETE: api/DonViVanTais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonViVanTai(Guid id)
        {
            if (_context.DonViVanTais == null)
            {
                return NotFound();
            }
            var donViVanTai = await _context.DonViVanTais.FindAsync(id);
            if (donViVanTai == null)
            {
                return NotFound();
            }

            _context.DonViVanTais.Remove(donViVanTai);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonViVanTaiExists(Guid id)
        {
            return (_context.DonViVanTais?.Any(e => e.Uuid == id)).GetValueOrDefault();
        }

        [Route("search")]
        [HttpGet]
        public async Task<ResponseAPI<dynamic>> SearchDonViVanTai([FromQuery] string textForSearch, [FromQuery] int pageNumber,
        [FromQuery] int pageSize)
        {
            try
            {
                var DonViVanTaiSearch = await _LuuTruRepository.Search(DonViVanTai =>
                        (EF.Functions.FreeText(DonViVanTai.MaSoThue, textForSearch) ||
                         EF.Functions.FreeText(DonViVanTai.MaDonViVanTai, textForSearch)),
                    pageNumber, pageSize).ToListAsync();
                return new ThanhCong().HienThiThanhCong("Tìm kiếm thành công", DonViVanTaiSearch);
            }
            catch (Exception ex)
            {
                return new Loi().HienThiLoi("Tìm kiếm thất bại", ex.ToString());
            }
        }
    }
}
