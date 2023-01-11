using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    //Repository pattern veritabanı ve kod arasında bir katman gibi çalışır.
    //Amaç temel CRUD işlemlerinin ortak bir yerde yazılıp merkezileştrilmesidir.
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        //IQueryable ile yazılan sorgular doğrudan veritabanına gitmez. ToList ToListAsync gibi metodların çağrılması halinde veritabanına gider.
        //Where ile bir sorgu atılmaz, burada sorgu oluşturuluyor. Gönderilmiyor.
        //productRepository.where(x=>x.id>5).OrderBy.ToListAsync() //örnek sorgu
        //yukarıdaki x=>x.id>5 alanının yazılabilmesi için Where içine Expression yazıldı
        //Expression: bir function delegesidir. Delegeler metoda işaret eder.
        //T burada x'e karşılık gelir, bool ise >5 ifadesinden dönen sonuca
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        //yazılımda mümkün olduğunca soyut nesneler kullan. Nesne örneği alınamaz
        //IEnumerable implement etmiş herhangi bir class'a cast edilebilir. İstenilen herhangi bir tipe dönüştürülebilir
        void Update(T entity);//EfCore memory'e alınan entity'nin sadece state değerini değiştirdiğinden async olmasını gerektirecek bir durum yok
        //çünkü işlem uzun sürmemektedir. Memoery'e alınan entity'nin state değeri modified olarak güncellenir.
        //ancak ekleme işlemi uzun sürmektedir ve async olarak yazılır.
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);


    }
}
