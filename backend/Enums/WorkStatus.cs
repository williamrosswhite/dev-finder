using System.ComponentModel.DataAnnotations;

namespace DevFinder.Backend.Enums
{
    public enum WorkStatus
    {
        [Display(Name = "Employed and not looking")]
        EmployedNotLooking,

        [Display(Name = "Employed but passively looking")]
        EmployedPassivelyLooking,

        [Display(Name = "Employed but actively looking")]
        EmployedActivelyLooking,

        [Display(Name = "Employed but desperately looking")]
        EmployedDesperatelyLooking,

        [Display(Name = "Unemployed and not looking")]
        UnemployedNotLooking,

        [Display(Name = "Unemployed but passively looking")]
        UnemployedPassivelyLooking,

        [Display(Name = "Unemployed but actively looking")]
        UnemployedActivelyLooking,

        [Display(Name = "Unemployed but actively looking")]
        UnemployedDesperatelyLooking,
    }
}