using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.UnitOfWorks
{
    //UnitOfWork tek bir transaction ile farklı repository'ler üzerinde yapılan değişklikleri tek seferde gerçekler.
    //olası bir hatada kendi rollback yapar.
    //kullanılmaması halinde bir reponun gerçeklenmesi, bağlı olanın gerçeklenmemesi durumu oluşabilir.
    //bu durum ise veri tutarsızlığına yol açar

    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
