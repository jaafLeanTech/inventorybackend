﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Contracts.Generics
{
    public interface IGenericActionDbDelete<T> where T : class
    {
        Task<bool> DeleteAsync(int id);
    }
}
