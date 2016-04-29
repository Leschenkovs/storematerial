using System;

namespace Store.Model
{
    public class BaseModel<T>
        where T: struct
    {
        public BaseModel()
        {
            Random rdm = new Random();
            DateTime now = DateTime.Now;
            int month = rdm.Next(1, 13);
            int day = rdm.Next(1, 29);
            if (Convert.ToInt64(Id) < 1L)
            {
                AddedDate = new DateTime(now.Year,month,day);
            }
        }

        public virtual T Id { get; set; }
        public virtual DateTime AddedDate { get; set; }

        public virtual bool IsNew
        {
            get { return Convert.ToInt64(Id) < 1L && Convert.ToInt64(Id) > 0; }
        }

    }
}
