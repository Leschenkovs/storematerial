namespace Store.Model
{
    // Модель описывает единицы измерения для материалов
    public class UnitMaterial: BaseModel<int>
    {
        public UnitMaterial()
        {}

        // Идентификатор вида материала
        public virtual int KindMaterialId { get; set; }
        public virtual KindMaterial KindMaterialObj { get; set; }

        // Идентификатор ед. измерения
        public virtual int UnitId { get; set; }
        public virtual Unit UnitObj { get; set; }

        // Идентификатор материала на складе
        public virtual int MaterialInStoreId { get; set; }
        public virtual MaterialInStore MaterialInStoreObj { get; set; }

    }
}
