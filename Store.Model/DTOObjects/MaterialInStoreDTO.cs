namespace Store.Model.DTOObjects
{
    public class MaterialInStoreDTO
    {
        //public int id { get; set; }
        public decimal count { get; set; }
        public string kindMaterialName { get; set; }
        public string unitName { get; set; }

        public int unitMaterialId { get; set; }
    }

    public class MaterialInStoreCountSupplyAndExperseDTO
    {
        public int month { get; set; }
        public decimal supply { get; set; }
        public decimal experse { get; set; }
    }
}
