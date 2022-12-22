using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Common
{
    public class PublicConst : BaseEntity
    {
        public const string EnterMessage = "لطفا {0} خود را وارد نمایید";
        public const string LengthMessage = "{0} باید بین {2} تا {1} کاراکتر باشد";
        public const string DangrouseMessageForBadCharachter = "در {0} از کاراکترهای نامعتبر استفاده شده است.";
    }
}
