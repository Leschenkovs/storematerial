using System.Collections.Generic;

namespace Store.Model.DTOObjects
{
    public class CostumerDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string telephone { get; set; }
        public string description { get; set; }
    }


    public class CostumerInfoForChartDTO
    {
        public string costumerName { get; set; }
        public List<CostumerCost> costs { get; set; }
    }

    public class CostumerCost
    {
        public int month { get; set; }
        public decimal fullCost { get; set; }
    }
}
