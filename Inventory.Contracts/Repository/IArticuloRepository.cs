using Inventory.Contracts.Generics;
using Inventory.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Contracts.Repository
{
    public interface IArticuloRepository:IGenericActionDbAddUpdate<Articulo>, IGenericActionDbQuery<Articulo>
    {

    }
}
