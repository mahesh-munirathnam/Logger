﻿using System.Data.Entity;
using Logger.BAL.Interfaces;
using Logger.DAL.Core;
using Logger.DAL.Domain;

namespace Logger.BAL.Repositories
{
    public class PermissionRepository : Repository<Permission>,IPermissionRepository
    {
        public PermissionRepository(DbContext context) : base(context)
        {
        }

    }
}
