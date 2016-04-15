using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class BaseModel<T>
        where T: struct
    {
        public BaseModel()
        {
            if (Convert.ToInt64(Id) < 1L)
                AddedDate = DateTime.Now;
        }

        public virtual T Id { get; set; }
        public virtual DateTime AddedDate { get; set; }

        public virtual bool IsNew
        {
            get { return Convert.ToInt64(Id) < 1L && Convert.ToInt64(Id) > 0; }
        }

    }
}
