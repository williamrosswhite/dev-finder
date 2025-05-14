using DevFinder.Data;
using DevFinder.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace DevFinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ProfileController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost("profile")]
        [RequestSizeLimit(10_000_000)] // 10 MB limit, adjust as needed
        public async Task<IActionResult> UploadProfile([FromForm] ProfileUploadDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Profile))
                return BadRequest("Profile data is required.");

            // Parse the JSON profile string
            ProfileDto? profileObj;
            try
            {
                profileObj = System.Text.Json.JsonSerializer.Deserialize<ProfileDto>(dto.Profile);
                if (profileObj == null)
                {
                    return BadRequest("Invalid profile JSON.");
                }
            }
            catch
            {
                return BadRequest("Invalid profile JSON.");
            }

            // Save the image if provided
            string? imagePath = null;
            if (dto.ProfileImage != null && dto.ProfileImage.Length > 0)
            {
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                var fileName = $"{Guid.NewGuid()}_{dto.ProfileImage.FileName}";
                var filePath = Path.Combine(uploads, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.ProfileImage.CopyToAsync(stream);
                }
                imagePath = $"/uploads/{fileName}";
            }

            var entity = ProfileMapper.ToEntity(profileObj, imagePath);
            _db.Profiles.Add(entity);
            await _db.SaveChangesAsync();

            return Ok(new { message = "Profile received", imagePath });
        }
    }
}