
namespace CarsharingSystem.WebServices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RatingInputModel
    {
        [Required]
        [MinLength(0)]
        public string TravelId { get; set; }

        [Required]
        [Range(0, 10)]
        public decimal Rating { get; set; }
    }
}