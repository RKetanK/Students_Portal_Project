using ASPCoreWebAPICRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebAPICRUD.Controllers
{
    [Route("api/[controller]")] /*when we hit this url with Get request then corresponding action 
    method will be called.
    this is attribute routing unlike conventional routing which is defined in the file Program.cs */

    [ApiController] //this is used in case of webapi
    public class StudentAPIController : ControllerBase
    {
        private readonly Demo_dbContext context; //created by pressing ctrl + . the varable of Demo_dbContext type 
        //using this object we can insert and fetch the data from the datasets present in the Demo_dbContext
        public StudentAPIController(Demo_dbContext context) //passing the parameter of Demo_db type which represents the database
        {
            this.context = context;
        }

        [HttpGet] //Executed without parameter

        /*to fetch/read the data from database:
        We have to permform the action methods asynchronously*/
        public async Task<ActionResult<List<StudentsTable>>> GetStudents()
        { 
            var data = await context.StudentsTables.ToListAsync(); /*converting the data of dbset into
                list and storing in the variable*/
            return Ok(data); //generates status code 200 which gives Ok i.e response is generated with
                             //no issue
                             //data contains the list of students fetched from the table
        /* IMP: In web api application data is returned unlike the mvc application which returns the 
         view */
        }

        [HttpGet("{id}")] //executed with parameter 
        public async Task<ActionResult<StudentsTable>> GetStudentById(int id)
        {
            var student = await context.StudentsTables.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpPost]
        /* when we hit above url with Post request then we have to pass the data of StudentsTable type
          which will be stored in the std variable and will be inserted in the Student table using 
        AddAsync method*/

        public async Task<ActionResult<StudentsTable>> CreateStudent(StudentsTable std) 
        {
            await context.StudentsTables.AddAsync(std); //to add the record
            await context.SaveChangesAsync(); //after adding the record we have to save 
            return Ok();    
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentsTable>> UpdateStudent(int id, StudentsTable std)
        {
            if (id != std.StudentId)
            {
                return BadRequest();
;           }
            context.Entry(std).State = EntityState.Modified;//
            await context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentsTable>> DeleteStudent(int id) //id whose data we want to delete 
        {
            //if the id we passed is valid then stored that record in std
            var std = await context.StudentsTables.FindAsync(id);
            //check whether std is null/not 
            if(std == null)
            {
                return NotFound();
            }
            context.StudentsTables.Remove(std); //data removed 
            await context.SaveChangesAsync(); //100% removed
            return Ok();
        }
    }
}
