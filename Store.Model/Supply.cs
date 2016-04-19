namespace Store.Model
{
    // Модель описывает поставки на склад
    public class Supply: BaseModel<int>
    {
        public Supply()
        {
            
        }

        // Идентификатор материала на складе
        public virtual int MaterialInStoreId { get; set; }
        public virtual MaterialInStore MaterialInStoreObj { get; set; }

        // Идентификатор организации-поставщика
        public virtual int ProviderId { get; set; }
        public virtual Provider ProviderObj { get; set; }

        // Идентификатор работника, который оформил поставку
        //public virtual int UserId { get; set; }
        //public virtual User UserObj { get; set; }

        // Кол-во
        public decimal Count { get; set; }

        // Номер ТТН
        public string Ttn { get; set; } 

    }
}
