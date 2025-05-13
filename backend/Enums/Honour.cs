using System.ComponentModel.DataAnnotations;

namespace DevFinder.Backend.Enums
{
    public enum DegreeType
    {
        [Display(Name = "High School Diploma")]
        HighSchoolDiploma,

        [Display(Name = "Associate Degree")]
        AssociateDegree,

        [Display(Name = "Bachelor's Degree")]
        BachelorsDegree,

        [Display(Name = "Master's Degree")]
        MastersDegree,

        [Display(Name = "Doctorate (PhD)")]
        Doctorate,

        [Display(Name = "Professional Degree")]
        ProfessionalDegree,

        [Display(Name = "Certificate")]
        Certificate,

        [Display(Name = "Diploma")]
        Diploma,

        [Display(Name = "Technical Diploma")]
        TechnicalDiploma,

        [Display(Name = "Other")]
        Other
    }
}