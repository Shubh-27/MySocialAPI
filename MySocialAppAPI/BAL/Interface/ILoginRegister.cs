using MySocialAppAPI.RequestModel;
using MySocialAppAPI.ResponnceModel;

namespace MySocialAppAPI.BAL.Interface
{
    public interface ILoginRegister
    {
        public string Login(ResLogin data);

        public bool Register(ReqRegister data);

        public string CheckUser(ResLogin data);
    }
}
