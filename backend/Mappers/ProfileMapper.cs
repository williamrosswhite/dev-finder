using DevFinder.Data;

namespace DevFinder.Mappers;

public static class ProfileMapper
{
    public static Profile ToEntity(ProfileDto dto, string? imagePath)
    {
        return new Profile
        {
            Salutation = Enum.TryParse<Backend.Enums.Salutation>(dto.Name?.Salutation, out var salutation) ? salutation : null,
            FirstName = dto.Name?.FirstName ?? string.Empty,
            MiddleName = dto.Name?.MiddleName,
            LastName = dto.Name?.LastName ?? string.Empty,
            PreferredFirstName = dto.Name?.PreferredFirstName,
            Pronouns = dto.Name?.Pronouns,
            Phone = dto.Phone ?? string.Empty,
            PhoneExtension = dto.PhoneExtension,
            ProfileImageUrl = imagePath,
            Address = dto.Address == null ? null : new Address
            {
                Unit = dto.Address.Unit,
                StreetAddress = dto.Address.StreetAddress ?? string.Empty,
                City = dto.Address.City ?? string.Empty,
                Province = dto.Address.Province ?? string.Empty,
                PostalCode = dto.Address.PostalCode ?? string.Empty,
                Country = dto.Address.Country ?? string.Empty
            }
        };
    }
}