using CarRentalApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApp.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        public int CarId { get; set; }

        // Usuń [Required] stąd. 
        // Opcjonalnie dodaj [ValidateNever] jeśli używasz .NET 6+, aby walidacja całkowicie to ignorowała
        [ValidateNever]
        public Car Car { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required, DataType(DataType.Date)]
        // Upewnij się, że masz zaimplementowany atrybut DateGreaterThan lub usuń go do testów
        // [DateGreaterThan("StartDate", ErrorMessage = "End date must be after start date")] 
        public DateTime EndDate { get; set; }

        // UserId ustawiasz w kontrolerze, więc nie może być wymagane w formularzu
        [ValidateNever]
        public string UserId { get; set; }

        [ValidateNever]
        public ApplicationUser User { get; set; }
    }
}
