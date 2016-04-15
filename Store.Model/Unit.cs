

namespace Store.Model
{
    // Модель описывает единицы измерения
    public class Unit: BaseModel<int>
    {
        // Название
        public string Name { get; set; }

        // Краткое название
        public string ShortName { get; set; }
    }
}
