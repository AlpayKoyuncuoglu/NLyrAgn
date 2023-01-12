using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    //Product'a bağlı olduğu için tekrar BaseEntity'den miras almaya gerek yok
    //Product'ın oluşturulma tarihi ProductFeature'un da oluşturulma tarihidir zaten
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }


    }
}
