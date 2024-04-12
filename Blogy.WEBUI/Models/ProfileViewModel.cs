namespace Blogy.WEBUI.Models
{
    public class ProfileViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
