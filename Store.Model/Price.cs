﻿using System;

namespace Store.Model
{
    // Модель описывает цену реализации
    public class Price:BaseModel<int>
    {
        public Price() { }

        // Идентификатор материала на складе
        public virtual int MaterialInStoreId { get; set; }
        public virtual MaterialInStore MaterialInStoreObj { get; set; }


        // Цена реализации
        public decimal PriceValue { get; set; }

        // Дата действия ОТ
        public DateTime DateOt { get; set; }

        // Дата действия ДО
        public DateTime DateDo { get; set; }
    }
}
