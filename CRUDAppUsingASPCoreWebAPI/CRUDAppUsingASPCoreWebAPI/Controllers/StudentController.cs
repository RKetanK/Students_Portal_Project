using CRUDAppUsingASPCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CRUDAppUsingASPCoreWebAPI.Controllers
{
    //Its a normal API controller 
    public class StudentController : Controller
    {
        private string url = "https://localhost:7241/api/StudentAPI/";
        private HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage response = client.GetAsync(url).Result; //response is stored in JSON format
            if (response.IsSuccessStatusCode) 
            {
                //used to read the JSON as string
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                if (data != null) 
                {
                    students = data;
                }
               
            }
            return View(students);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode) 
            {
                TempData["insert_message"] = "Student Added...";
                return RedirectToAction("Index"); 
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result; //response is stored in JSON format
            //here
            string result = response.Content.ReadAsStringAsync().Result;// Reading the content from response
            var data = JsonConvert.DeserializeObject<Student>(result);// converting JSON in Student obj
            if (data != null)
            {
                std = data;
            }
            return View(std);
        }

        [HttpPost]
        public IActionResult Edit(Student std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(url + std.studentId, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["update_message"] = "Student Updated...";
                return RedirectToAction("Index"); //after udation we will be rediredted to the index page 
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result; //response is stored in JSON format
            //here
            string result = response.Content.ReadAsStringAsync().Result;// Reading the content from response
            var data = JsonConvert.DeserializeObject<Student>(result);// converting JSON in Student obj
            if (data != null)
            {
                std = data;
            }
            return View(std);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result; //response is stored in JSON format
            //here
            string result = response.Content.ReadAsStringAsync().Result;// Reading the content from response
            var data = JsonConvert.DeserializeObject<Student>(result);// converting JSON in Student obj
            if (data != null)
            {
                std = data;
            }
            return View(std);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(url + id).Result; //response is stored in JSON format
            
            if (response.IsSuccessStatusCode)
            {
                TempData["delete_message"] = "Student Deleted...";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
