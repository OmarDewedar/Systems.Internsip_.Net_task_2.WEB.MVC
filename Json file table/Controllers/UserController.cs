using Systems.Internship_.Net_task_2.WEB.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class UserController : Controller
{
    private readonly HttpClient _httpClient;

    private static List<User> _userList = new List<User>();

    public UserController()
    {
        _httpClient = new HttpClient();
    }

    // Fetch and display all users
    public async Task<IActionResult> Index()
    {
        if (_userList.Count == 0) // Fetch only once
        {
            var response = await _httpClient.GetStringAsync("https://dummyjson.com/users");
            var usersResponse = JsonConvert.DeserializeObject<UserResponse>(response);
            _userList = usersResponse.Users;
        }
        return View(_userList);
    }


    // Create new user view
    // Show Create form
    public IActionResult Create()
    {
        return View();
    }

    // Handle form submission
    [HttpPost]
    public IActionResult Create(User user)
    {
        if (user != null)
        {
            // Generate a new ID for the new user
            int newId = _userList.Any() ? _userList.Max(u => u.Id) + 1 : 1;
            user.Id = newId;

            // Add the new user to the list
            _userList.Add(user);

            // TempData message for success
            TempData["SuccessMessage"] = "User added successfully!";
        }

        return RedirectToAction("Index");
    }



    // View user details
    public IActionResult Details(int id)
    {
        var user = _userList.FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            return NotFound(); // Handle if the user doesn't exist
        }

        return View(user);
    }


    // Edit user
    // Show Edit form with user data
    public IActionResult Edit(int id)
    {
        var userToEdit = _userList.FirstOrDefault(u => u.Id == id);
        if (userToEdit == null) return NotFound();
        return View(userToEdit);
    }

    // Handle the edited data
    [HttpPost]
    [HttpPost]
    public IActionResult Edit(User updatedUser)
    {
        var existingUser = _userList.FirstOrDefault(u => u.Id == updatedUser.Id);

        if (existingUser != null)
        {
            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.Email = updatedUser.Email;
            existingUser.Phone = updatedUser.Phone;
            existingUser.Username = updatedUser.Username;
            existingUser.BirthDate = updatedUser.BirthDate;
            existingUser.Role = updatedUser.Role;

            // Store success message in TempData
            TempData["SuccessMessage"] = $"User with ID {updatedUser.Id} updated successfully!";
        }

        return RedirectToAction("Index");
    }




    // Delete user
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var userToDelete = _userList.FirstOrDefault(u => u.Id == id);

        if (userToDelete != null)
        {
            _userList.Remove(userToDelete);
            TempData["SuccessMessage"] = $"User with ID {id} deleted successfully!";
        }

        return RedirectToAction("Index");
    }



}


