using Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Client.Controllers
{
    public class UserController : Controller
    {

        private readonly string link = "http://localhost:5091/api/";
        HttpClient _client;

        public UserController()
        {
            _client = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            List<User> listUser = new List<User>();
           //string odataQuery = "?$filter= contains(Title, '" + keyword + "')&$expand=Lecturer,Assignments,CourseEnrollments,Quizzes";
            HttpResponseMessage response = await _client.GetAsync(link + "User/getAllUser" );
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                listUser = JsonConvert.DeserializeObject<List<User>>(data);
                return View(listUser);
            }
            return Redirect("/User");
        }

        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(link + "User/addUser", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest("Error adding user");
        }

        [HttpPost]
        public async Task<IActionResult> Update(int userId, string email,string username, string password, string role)
        {
            var updatedUser = new User
            {
                UserId=userId,
                Email=email,
                Username=username,
                Password=password,
                Role=role
            };
            HttpResponseMessage response = await _client.PutAsJsonAsync(link + "User/updateUser", updatedUser);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest("Error updating user");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int userId)
        {
            HttpResponseMessage response = await _client.DeleteAsync(link + $"User/deleteUser/{userId}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest("Error deleting user");
        }
        [HttpGet]
        public async Task<IActionResult> GetUserById(int userId)
        {
            HttpResponseMessage response = await _client.GetAsync(link + $"User/getUserById/{userId}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                User user = JsonConvert.DeserializeObject<User>(data);
                return View(user);
            }
            return NotFound();
        }
    }
}
