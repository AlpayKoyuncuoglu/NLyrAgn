using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        //List bir sınıftır. List sınıfı sayesinde biz c#'da listeler oluşturabiliyoruz. ICollection ise bir interface yani arayüz.
        //ICollection arayüzünden new anahtarı ile yeni instance oluşturamayız

        //Category üzerinden bütün Product'lara gidilebildiği için Products bir navigation property'dir
        public ICollection<Product> Products { get; set; }

    }
}
