using BOL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUserDb
    {
        IQueryable<BCUser> GetUsers();
        BCUser GetUserById(int id);

        Task<bool> Create(BCUser employee);
        Task<bool> Update(BCUser employee);
        Task<bool> Delete(int id);


    }
    public class UserDb : IUserDb
    {
        BCDbContext dbContext;
        public UserDb(BCDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<bool> Create(BCUser employee)
        {

            dbContext.Users.Add(employee);
            

            var result = await dbContext.SaveChangesAsync();

            if (result != 0)
                return true;
            else
                return false;
        }

        public async Task<bool> Delete(int id)
        {


            var employee = await dbContext.Users.FindAsync(id);
            if (employee == null)
            {
                return false; 
            }

            dbContext.Users.Remove(employee);
            var result = await dbContext.SaveChangesAsync();

            if (result != 0)
                return true;
            else
                return false;

        }

        
        public BCUser GetUserById(int id)
        {
            return dbContext.Users.Find(id);
        }

        public IQueryable<BCUser> GetUsers()
        {
            return dbContext.Users;
            
        }

        public async Task<bool> Update(BCUser employee)
        {
            dbContext.Entry(employee).State = EntityState.Modified;


            dbContext.Users.Update(employee);
            var result = await dbContext.SaveChangesAsync();

            if (result != 0)
                return true;
            else
                return false;

        }
    }
}
