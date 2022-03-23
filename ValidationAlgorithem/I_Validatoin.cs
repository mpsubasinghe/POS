using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidationAlgorithem
{
    public interface I_Validatoin<AnyType>
    {
        void Validation(AnyType obj);
    }
}
