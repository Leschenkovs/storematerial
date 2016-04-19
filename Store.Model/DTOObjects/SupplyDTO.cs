using System;

namespace Store.Model.DTOObjects
{
    public class SupplyDTO
    {
        public int id { get; set; }
        public decimal count { get; set; }
        public string ttn { get; set; }
        public string kindMaterialName { get; set; }
        public string providerName { get; set; }
		  public DateTime data { get; set; }


        public int materialInStoreId {get; set; }
        public int providerId { get; set; }
    }
}
