﻿namespace Store.Model.DTOObjects
{
    public class KindMaterialDTO
    {
        public int id { get; set; }
        public string articul { get; set; }
        public string name { get; set; }
        public string units { get; set; }
    }

    public class CreateKindMaterialDTO
    {
        public int id { get; set; }
        public string articul { get; set; }
        public string name { get; set; }
        public int[] units { get; set; }
    }
}
