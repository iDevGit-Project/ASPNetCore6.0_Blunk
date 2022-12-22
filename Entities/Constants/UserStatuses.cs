using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Constants
{
    public enum UserStatuses
    {
        [Display(Name = "فعال")]
        active = 01,
        deactive = 02
    }
}
