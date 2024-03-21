using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ISessionFactory _sessionFactory;

        public PatientController(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        [HttpPost]
        public IActionResult CreatePatient([FromBody] PatientDto patientDto)
        {
            try
            {
                using (var session = _sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var patient = new Patient
                    {
                        name = patientDto.name,
                        age = patientDto.age
                    };

                    session.Save(patient);
                    transaction.Commit();
                }

                return Ok(new { message = "Patient created successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating patient: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetPatient()
        {
            try
            {
                using (var session = _sessionFactory.OpenSession())
                {
                    var patients = session.Query<Patient>().OrderBy(emp => emp.id).ToList();

                    return Ok(patients);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving patients: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            try
            {
                using (var session = _sessionFactory.OpenSession())
                {
                    var patient = session.Get<Patient>(id);
                    if (patient == null)
                    {
                        return NotFound($"Patient with ID {id} not found");
                    }

                    using (var transaction = session.BeginTransaction())
                    {
                        session.Delete(patient);                        

                        transaction.Commit();
                    }

                    return Ok(new { message = $"Patient with ID {id} deleted successfully" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting Patient: {ex.Message}");
            }
        }

    }
}