using confitec.Entities;
using confitec.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace confitec.Controllers
{
  [ApiController]
  [Route("api/users")]
  public class UserController : ControllerBase
  {
    private readonly UsersDbContext _context;
    public UserController(UsersDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
      var users = _context.Users.Where(u => !u.IsDeleted).ToList();

      return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var user = _context.Users.SingleOrDefault(u => u.Id == id);

      if (user == null)
      {
        return NotFound();
      }

      return Ok(user);
    }

    [HttpPost]
    public IActionResult Post(User user)
    {
      _context.Users.Add(user);
      _context.SaveChanges();

      return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, User input)
    {
      var user = _context.Users.SingleOrDefault(u => u.Id == id);

      if (user == null)
      {
        return NotFound();
      }

      user.Update(input.Nome, input.Sobrenome, input.Email, input.DataNascimento, input.Escolaridade);

      _context.Users.Update(user);
      _context.SaveChanges();

      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var user = _context.Users.SingleOrDefault(u => u.Id == id);

      if (user == null)
      {
        return NotFound();
      }

      user.Delete();

      _context.SaveChanges();

      return NoContent();
    }

  }
}
