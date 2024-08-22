using MySocialAppAPI.BAL.Interface;
using MySocialAppAPI.RequestModel;
using MySocialAppAPI.ResponnceModel;
using MySocialAppAPI.TenantDB;
using System.Linq;

namespace MySocialAppAPI.BAL.Repository
{
    public class LoginRegister : ILoginRegister
    {
        private readonly MySocialAppDBContext _context;

        public LoginRegister(MySocialAppDBContext context)
        {
            _context = context;
        }
        public string Login(ResLogin data)
        {
            var login = CheckUser(data);
            if (login != null)
                return login;
            else
                return null;
        }
        public string CheckUser(ResLogin data)
        {
            var user = _context.MySocials.Where(
                          query => query.Username.Equals(data.Username) && query.Password.Equals(data.Password)).SingleOrDefault();

            if (user == null)
            {
                return null;
            }
            else
            {
                return (user.Id).ToString();
            }
        }
        public bool Register(ReqRegister data)
        {
            var mySocials = new MySocial();
            mySocials.Name = data.Name;
            mySocials.Username = data.Username;
            mySocials.Password = data.Password;
            mySocials.AccountCreated = System.DateTime.UtcNow;
            
            _context.MySocials.Add(mySocials);
            _context.SaveChanges();
            return true;
        }
    }
}
