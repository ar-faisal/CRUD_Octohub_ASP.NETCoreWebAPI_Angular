using BOL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IBCDb bcDb;

        public EmployeesController(IBCDb _bcDb)
        {
            bcDb = _bcDb;
        }

        // GET: api/Employees
        
        [HttpGet("GetEmployees")]
        public async Task<ActionResult<IEnumerable<BCUser>>> GetEmployees()
        {
           
            var employees = await bcDb.UserDb.GetUsers().ToListAsync();
            
            return employees;
            
            

            
        }

        // GET: api/Employees/5
        [HttpGet("GetEmployee/{id}")]
        public async Task<ActionResult<BCUser>> GetEmployee(int id)
        {
            var employee =  bcDb.UserDb.GetUserById(id);

            

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutEmployee/{id}")]
        public async Task<IActionResult> PutEmployee(int id, BCUser updatedEmployee)
        {
            try
            {
                if (id != updatedEmployee.Eid)
                {
                    return BadRequest();
                }

                bool updated = await bcDb.UserDb.Update(updatedEmployee);

                if (updated)

                {
                    return NoContent();
                }
                else
                {
                    // Handle the case where creation in the database failed
                    return StatusCode(500, "Failed to create the StoryPost.");
                }

            }
            catch (Exception E)
            {
                var msg = (E.InnerException != null) ? (E.InnerException.Message) : (E.Message);
                return StatusCode(500, "Admin is working on it! " + msg);
            }


        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BCUser>> PostEmployee(BCUser employee)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    bool updated = await bcDb.UserDb.Create(employee);

                    if (updated)

                    {
                        return NoContent();
                    }
                    else
                    {
                        // Handle the case where creation in the database failed
                        return StatusCode(500, "Failed to create the StoryPost.");
                    }


                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception E)
            {
                var msg = (E.InnerException != null) ? E.InnerException.Message : E.Message;
                //log msg
                return StatusCode(500, msg);
            }
        }

        // DELETE: api/Employees/5
        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {

            try
            {
                bool updated = await bcDb.UserDb.Delete(id);
                if (updated)

                {
                    return NoContent();
                }
                else
                {
                    // Handle the case where creation in the database failed
                    return StatusCode(500, "Failed to create the StoryPost.");
                }
            }
            catch (Exception E)
            {
                var msg = (E.InnerException != null) ? (E.InnerException.Message) : (E.Message);
                return StatusCode(500, "Admin is working on it! " + msg);
            }



        }

        
    }
}
