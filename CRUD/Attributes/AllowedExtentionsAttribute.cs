using System.ComponentModel.DataAnnotations;

namespace CRUD.Attributes;

public class AllowedExtentionsAttribute(string allowedExtentions) : ValidationAttribute
{
    private readonly string _allowedExtentions = allowedExtentions;


    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var file = value as IFormFile;
        if (file != null)
        {
            var extension = Path.GetExtension(file.FileName);
            var isAllowed = _allowedExtentions.Split(',').Contains(extension, StringComparer.OrdinalIgnoreCase);

            if (!isAllowed)
                return new ValidationResult($"Only {_allowedExtentions} are Allowed!");
        }
        return ValidationResult.Success;
    }

}
