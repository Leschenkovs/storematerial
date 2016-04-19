namespace Store.Model.DTOObjects
{
    public class MaterialInStoreDTO
    {
        public int id { get; set; }
        public decimal count { get; set; }
        public decimal priceSupply { get; set; }
        public string kindMaterialName { get; set; }


        public int kindMaterialId { get; set; }
    }
}
