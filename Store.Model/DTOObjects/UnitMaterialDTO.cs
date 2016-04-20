namespace Store.Model.DTOObjects
{
    public class UnitMaterialDTO
    {
        public int id { get; set; }
        public string unitShotrName { get; set; }

        public int unitId { get; set; }
        public int kindMaterialId { get; set; }
    }

    public class DropDownUnitMaterialDTO
    {
        public int id { get; set; }
        public string unitShotrName { get; set; }
        public string kindMaterialname { get; set; }

        public int unitId { get; set; }
        public int kindMaterialId { get; set; }
    }
}
