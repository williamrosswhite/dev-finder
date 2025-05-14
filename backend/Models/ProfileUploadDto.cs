public class ProfileUploadDto
{
    public string Profile { get; set; } = null!;
    public IFormFile ProfileImage { get; set; } = null!;
}
