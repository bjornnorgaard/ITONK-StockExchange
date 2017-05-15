﻿using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface IRegistryService
    {
        Task<bool> ChangeOwnerShip(OwnershipModel ownershipModel);
    }
}
