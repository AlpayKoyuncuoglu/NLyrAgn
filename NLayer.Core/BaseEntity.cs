using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    public abstract class BaseEntity//newlenemez kılındı 
    {
        //Eğer burada EntityId gibi bir ifade kullanılsaydı PrimaryKey olduğunu belirtmek için
        //[Key] ifadesi kullanılmalıydı
        //Bu sebeple mümkün olduğunca custom isimler verilmekten kaçınılmalı
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
