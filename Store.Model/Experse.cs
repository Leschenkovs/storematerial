namespace Store.Model
{
    // Модель описывает расходы (отгрузки) со склада
    public class Experse: BaseModel<int>
    {
        public Experse() { }

        // Идентификатор материала на складе
        public virtual int MaterialInStoreId { get; set; }
        public virtual MaterialInStore MaterialInStoreObj { get; set; }

        // Идентификатор организации-потребителя
        public virtual int CostumerId { get; set; }
        public virtual Costumer CostumerObj { get; set; }

        // Идентификатор работника, который оформил отгрузку
        public virtual int UserId { get; set; }
        public virtual User UserObj { get; set; }

        // Кол-во
        public decimal Count { get; set; }

		  // Стоимость
		  public decimal FullCost { get; set; }
    }
}
