// UserModel.cs

using System.ComponentModel.DataAnnotations;

public class UserModel
{
    public int UserID { get; set; }

    [Required]
    public string UserName { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
