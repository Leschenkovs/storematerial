using System;

namespace Store.Model.DTOObjects
{
    public class PriceDTO
    {
        public int id { get; set; }
        public decimal priceValue { get; set; }
        public DateTime dateOt { get; set; }
        public DateTime? dateDo { get; set; }
        public int materialInStoreId { get; set; }

    }
}
