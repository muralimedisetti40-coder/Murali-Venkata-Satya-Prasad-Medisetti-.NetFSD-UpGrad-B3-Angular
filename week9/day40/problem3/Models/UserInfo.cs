using System.ComponentModel.DataAnnotations;

public class UserInfo
{
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    public string EmailId { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    [Required]
    public string Role { get; set; }
}