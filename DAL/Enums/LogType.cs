using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enums
{
    public enum LogType
    {
        [Display(Name="Added")]
        Add,
        [Display(Name = "Removed")]
        Remove,
        [Display(Name = "Updated")]
        Update,
        [Display(Name = "Error")]
        Error
    }
}
