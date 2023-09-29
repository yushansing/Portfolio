using Microsoft.AspNetCore.Mvc;
using TravelProject1._0.Areas.Admin.Models.DTO;
using TravelProject1._0.Models;

namespace TravelProject1._0.Areas.Admin.Controllers.Api;

[Area("Admin")]
[Route("api/Super/[action]")]
[ApiController]
public class SuperApiController : ControllerBase
{
    private readonly TravelProjectAzureContext _context;

    public SuperApiController(TravelProjectAzureContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<GetAdminDTO> GetAdmin()
    {
        return _context.Admins.Select(a => new GetAdminDTO
        {
            Id = a.Id,
            Name = a.Name,
            Account = a.Account,
            Describe = a.Describe,
            CreateDate = DateTime.Now,
            LoginDate = DateTime.Now
        });
    }

   

    [HttpPost]
    public async Task<bool> CreateAdmin(ManageAdmminDTO? maDto)
    {
        if (maDto == null) return false;
        try
        {
            await _context.Admins.AddAsync(new _0.Models.Admin
            {
                Id = maDto.Id,
                Name = maDto.Name,
                Account = maDto.Account,
                Password = maDto.Password,
                Describe = maDto.Describe,
                LoginDate = DateTime.Now,
                CreateDate = DateTime.Now,
                Role = "Admin"
            });
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }


    [HttpPut("{id}")]
    public async Task<bool> AdminPut(int id, [FromBody] AdminPutDTO apDto)
    {
        var admin = await _context.Admins.FindAsync(id);
        if (admin == null) return false;
        if (admin.Id == 5) return false;
        admin.Name = apDto.Name;
        admin.Account = apDto.Account;
        admin.Describe = apDto.Describe;
        admin.Password = apDto.Password;

        await _context.SaveChangesAsync();
        return true;
    }

    [HttpDelete("{id}")]
    public async Task<bool> AdminDelete(int id)
    {
        var admin = await _context.Admins.FindAsync(id);
        if (admin == null) return false;
        if (admin.Id == 5) return false; 
        try
        {
            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}