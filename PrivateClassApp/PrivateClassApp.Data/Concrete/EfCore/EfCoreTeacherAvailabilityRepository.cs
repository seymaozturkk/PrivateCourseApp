﻿using PrivateClassApp.Data.Abstract;
using PrivateClassApp.Data.Context;
using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Data.Concrete.EfCore
{
    public class EfCoreTeacherAvailabilityRepository : EfCoreGenericRepository<TeacherAvailability>, ITeacherAvailabilityRepository
    {
        public EfCoreTeacherAvailabilityRepository(PrivateClassAppContext _appContext) : base(_appContext)
        {
        }
        PrivateClassAppContext AppContext
        {
            get { return _dbContext as PrivateClassAppContext; }
        }
    }
}
