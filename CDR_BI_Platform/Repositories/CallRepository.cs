using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using CDR_BI_Platform.Models;
using CDR_BI_Platform.Repositories.Interfaces;

namespace CDR_BI_Platform.Repositories
{
    public class CallRepository: BaseRepository<Call>, ICallRepository
    {
        public CallRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
