﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Stomatology.Repository
{
    public class DoctorRepository : BaseRepository
    {
        public DoctorRepository(ISession session) : base(session)
        {
        }
    }
}
