using Dapper;
using Domain.Entity;
using Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repository
{
    public class LoginRepository : GenericRepository<Login>, ILoginRepository
    {
        public LoginRepository(IDbTransaction transaction) : base(transaction)
        {

        }
        public Cliente SignIn(Login login)
        {
            var linq = Connection.Query<Login>("SELECT * FROM Login WHERE email = @Email AND password = @pass", new { @Email = login.Email,@pass = login.Password}, Transaction).ToList();
            Login usuario = linq.FirstOrDefault();
            if (usuario != null)
            {
                var retornaruser = Connection.Query<Cliente>("SELECT * FROM Cliente WHERE UserId = @userId", new { @userId = usuario.UserId }, Transaction).ToList();
                if (retornaruser != null)
                {
                    return retornaruser.FirstOrDefault();
                }
                else return null;
            }
            else return null;
        }
    }
}
