using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IBCDb
    {
        IUserDb UserDb { get; }
    }

    public class BCDb : IBCDb
    {
        BCDbContext context;
        public BCDb(BCDbContext _context)
        {
            context = _context;
        }

        IUserDb _userDb;
       
        public IUserDb UserDb
        {
            get
            {
                if (_userDb == null)
                {
                    _userDb = new UserDb(context);
                }
                return _userDb;
            }
        }

    }
}
