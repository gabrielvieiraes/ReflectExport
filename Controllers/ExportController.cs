using System.Text;
using Microsoft.AspNetCore.Mvc;
using ReflectExport.Models;
using ReflectExport.Service;

namespace ReflectExport.Controllers
{
    [ApiController]
    [Route("/api/export")]
    public class ExportController : ControllerBase
    {
        private readonly IExportService _exportService;
        public List<User> fakeUsers { get; set; }
        public ExportController()
        {
            _exportService = new ExportService();
            fakeUsers = GenerateFakeUsers();
        }

        [HttpGet("csv")]
        public IActionResult ExportUsersCSVExample()
        {
            var csvString = _exportService.ExportCSV(fakeUsers);

            var csvBytes = Encoding.UTF8.GetBytes(csvString);

            return File(csvBytes, "text/csv", "usersExample.csv");
        }

        [HttpGet("json")]
        public IActionResult ExportUsersJsonExample()
        {
            var csvString = _exportService.ExportJson(fakeUsers);

            var csvBytes = Encoding.UTF8.GetBytes(csvString);

            return File(csvBytes, "application/json", "usersExample.json");
        }

        #region FakeData
        private List<User> GenerateFakeUsers() => new List<User>
           {
               new User { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", DateOfBirth = new DateTime(1990, 1, 1), PhoneNumber = "123-456-7890", Address = "123 Main St, Springfield" },
               new User { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", DateOfBirth = new DateTime(1985, 5, 15), PhoneNumber = "987-654-3210", Address = "456 Elm St, Springfield" },
               new User { Id = 3, FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com", DateOfBirth = new DateTime(1992, 3, 10), PhoneNumber = "555-123-4567", Address = "789 Oak St, Springfield" },
               new User { Id = 4, FirstName = "Bob", LastName = "Brown", Email = "bob.brown@example.com", DateOfBirth = new DateTime(1988, 7, 20), PhoneNumber = "444-987-6543", Address = "321 Pine St, Springfield" },
               new User { Id = 5, FirstName = "Charlie", LastName = "Davis", Email = "charlie.davis@example.com", DateOfBirth = new DateTime(1995, 11, 25), PhoneNumber = "333-456-7890", Address = "654 Maple St, Springfield" },
               new User { Id = 6, FirstName = "Diana", LastName = "Evans", Email = "diana.evans@example.com", DateOfBirth = new DateTime(1991, 9, 5), PhoneNumber = "222-123-4567", Address = "987 Birch St, Springfield" },
               new User { Id = 7, FirstName = "Ethan", LastName = "Garcia", Email = "ethan.garcia@example.com", DateOfBirth = new DateTime(1987, 4, 18), PhoneNumber = "111-987-6543", Address = "123 Cedar St, Springfield" },
               new User { Id = 8, FirstName = "Fiona", LastName = "Harris", Email = "fiona.harris@example.com", DateOfBirth = new DateTime(1993, 6, 12), PhoneNumber = "999-456-7890", Address = "456 Walnut St, Springfield" },
               new User { Id = 9, FirstName = "George", LastName = "Ivy", Email = "george.ivy@example.com", DateOfBirth = new DateTime(1989, 2, 28), PhoneNumber = "888-123-4567", Address = "789 Chestnut St, Springfield" },
               new User { Id = 10, FirstName = "Hannah", LastName = "Jones", Email = "hannah.jones@example.com", DateOfBirth = new DateTime(1994, 8, 22), PhoneNumber = "777-987-6543", Address = "321 Willow St, Springfield" },
               new User { Id = 11, FirstName = "Ian", LastName = "King", Email = "ian.king@example.com", DateOfBirth = new DateTime(1990, 12, 30), PhoneNumber = "666-456-7890", Address = "654 Poplar St, Springfield" },
               new User { Id = 12, FirstName = "Julia", LastName = "Lewis", Email = "julia.lewis@example.com", DateOfBirth = new DateTime(1986, 10, 8), PhoneNumber = "555-123-4567", Address = "987 Aspen St, Springfield" },
               new User { Id = 13, FirstName = "Kevin", LastName = "Miller", Email = "kevin.miller@example.com", DateOfBirth = new DateTime(1991, 1, 14), PhoneNumber = "444-987-6543", Address = "123 Redwood St, Springfield" },
               new User { Id = 14, FirstName = "Laura", LastName = "Nelson", Email = "laura.nelson@example.com", DateOfBirth = new DateTime(1992, 3, 19), PhoneNumber = "333-456-7890", Address = "456 Cypress St, Springfield" },
               new User { Id = 15, FirstName = "Michael", LastName = "Owen", Email = "michael.owen@example.com", DateOfBirth = new DateTime(1988, 7, 25), PhoneNumber = "222-123-4567", Address = "789 Fir St, Springfield" }
           };

        #endregion
    }
}
