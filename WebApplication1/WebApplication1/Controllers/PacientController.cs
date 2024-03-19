using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacientController : ControllerBase
    {
        private readonly ISessionFactory _sessionFactory;

        public PacientController(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        [HttpPost]
        public IActionResult CreatePacient([FromBody] PacientDto pacientDto)
        {
            try
            {
                using (var session = _sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var pacient = new Pacient
                    {
                        name = pacientDto.name
                    };

                    session.Save(pacient);
                    transaction.Commit();
                }

                return Ok(new { message = "Pacient created successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating pacient: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetPacient()
        {
            try
            {
                using (var session = _sessionFactory.OpenSession())
                {
                    var pacients = session.Query<Pacient>().OrderBy(emp => emp.id).ToList();

                    return Ok(pacients);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving pacients: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePacient(int id)
        {
            try
            {
                using (var session = _sessionFactory.OpenSession())
                {
                    var pacient = session.Get<Pacient>(id);
                    if (pacient == null)
                    {
                        return NotFound($"Pacient with ID {id} not found");
                    }

                    using (var transaction = session.BeginTransaction())
                    {
                        session.Delete(pacient);                        

                        transaction.Commit();
                    }

                    return Ok(new { message = $"Pacient with ID {id} deleted successfully" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting Pacient: {ex.Message}");
            }
        }



    }
}