using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I_DAL
{
   public interface Interface_DAL<AnyType> 
    {

        void Add(AnyType obj); // Inmemory addition
        void Update(AnyType obj);
        void Delete(AnyType obj);// Inmemory updatione
        // Design pattern :- Iterator
        AnyType SearchLast();
       IEnumerable<AnyType> Search();
        IEnumerable<AnyType> Search(int Index);
        IEnumerable<AnyType> Search(string Index);
        IEnumerable<AnyType> Search(string Index1, string Index2, string Index3);
        IEnumerable<AnyType> SearchAny(string Index);
         AnyType SearchOne(string Index);


        IEnumerable<AnyType> GetData();// Inmemory 
        AnyType GetData(int Index);// Inmemory 
        void SetData(List<AnyType> anyTypes);// Inmemory 

        void Save(); // Physical committ

    }
}
