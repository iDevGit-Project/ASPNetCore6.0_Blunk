using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Constants
{
    public enum ContentTypes
    {
        [Display(Name = "عکس")]
        Picture,
        [Display(Name = "ویدیو")]
        Video,
        [Display(Name = "متن")]
        Text,
        [Display(Name = "ترکیبی")]
        Complex,
        [Display(Name = "چند ستونی")]
        Certificate,
    }
}
