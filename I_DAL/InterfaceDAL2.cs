using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I_DAL
{
    public interface InterfaceDAL2<AnyType> 
    {
       IEnumerable<AnyType> SearchAllByObj(AnyType obj);
       AnyType SearchOneByObj(AnyType obj);
    }
}
