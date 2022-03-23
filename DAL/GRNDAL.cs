using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using I_MiddleLayer;
using I_DAL;

namespace DAL
{
     public class GRNDAL : CommonDAL, Interface_DAL<IGRN>
     {

         public void Add(IGRN obj)
         {
             throw new NotImplementedException();
         }

         public void Update(IGRN obj)
         {
             throw new NotImplementedException();
         }

         public void Delete(IGRN obj)
         {
             throw new NotImplementedException();
         }

         public IGRN SearchLast()
         {
             throw new NotImplementedException();
         }

         public IEnumerable<IGRN> Search()
         {
             throw new NotImplementedException();
         }

         public IEnumerable<IGRN> Search(int Index)
         {
             throw new NotImplementedException();
         }

         public IEnumerable<IGRN> Search(string Index)
         {
             throw new NotImplementedException();
         }

         public IEnumerable<IGRN> Search(string Index1, string Index2, string Index3)
         {
             throw new NotImplementedException();
         }

         public IEnumerable<IGRN> SearchAny(string Index)
         {
             throw new NotImplementedException();
         }

         public IGRN SearchOne(string Index)
         {
             throw new NotImplementedException();
         }

         public IEnumerable<IGRN> GetData()
         {
             throw new NotImplementedException();
         }

         public IGRN GetData(int Index)
         {
             throw new NotImplementedException();
         }

         public void SetData(List<IGRN> anyTypes)
         {
             throw new NotImplementedException();
         }

         public void Save()
         {
             throw new NotImplementedException();
         }
     }
}
