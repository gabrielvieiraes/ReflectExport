using Microsoft.AspNetCore.Mvc;
using ReflectExport.Attributes;

namespace ReflectExport.Models
{
    public class User
    {
        [ExportColumn]
        [ExportColumnName("Identificador")]
        public int Id { get; set; }
        [ExportColumn]
        [ExportColumnName("Primeiro nome")]
        public string FirstName { get; set; }
        [ExportColumn]
        [ExportColumnName("Sobrenome")]
        public string LastName { get; set; }
        [ExportColumn]
        [ExportColumnName("E-mail")]
        public string Email { get; set; }
        [ExportColumn]
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        [ExportColumn]
        [ExportColumnName("Situação")]
        public bool IsActive { get; set; }
        [ExportColumn]
        [ExportColumnName("Criado em")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
