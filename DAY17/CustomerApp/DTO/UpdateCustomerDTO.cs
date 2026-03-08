using System.ComponentModel.DataAnnotations;

public class UpdateCustomerDTO
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
}