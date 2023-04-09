using System.ComponentModel.DataAnnotations;

namespace BIBF.Test.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}