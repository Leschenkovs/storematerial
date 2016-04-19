namespace Store.Model.DTOObjects
{
    public class ExperseDTO
    {
        public int id { get; set; }
        public decimal count { get; set; }

        public string kindMaterialName { get; set; }
        public string costumerName { get; set; }
        public string userFio { get; set; }


        public int materialInStoreId { get; set; }
        public int costumerId { get; set; }
        public int userId { get; set; }
    }
}
