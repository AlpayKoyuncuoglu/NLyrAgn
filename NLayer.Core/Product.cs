using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    //class'ın default erişim belirleyicisi internal
    public class Product : BaseEntity
    {
        //null olması halinde exception fırlatılması sağlanır
        //public Product(string name)
        //{
        //    //Name = name ?? throw new ArgumentNullException("name");//name'in static yazımı
        //    Name = name ?? throw new ArgumentNullException(nameof(Name));
        //}

        //class içindeki property'lerin default erişim belirleyicisi ise private
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        //Eğer CategoryId alttaki gibi tanımlansaydı 
        ////public int Category_Id { get; set; }
        //[ForeignKey("Category_Id")]
        //Buna gerek kalmamasının sebebi Ef Core'un belli bir yazım şeklini doğrudan tanıması
        //Category ve ProductFeature'lar birer navigation property'dirler
        public Category Category { get; set; }
        public ProductFeature ProductFeature { get; set; }
        //int ve decimal property'ler yeşille işaretlenmez çünkü default değerleri vardır, Value Type'tırlar. Bu değer 0'dır.
        //Category, ProductFeature ve Name(string olduğu için) referans tiptir ve null olması halinde olası hatalara işaret edilir.
    }
}
