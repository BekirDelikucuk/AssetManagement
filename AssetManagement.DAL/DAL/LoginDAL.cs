using AssetManagement.DAL.Repositories;
using AssetManagement.DTO.DTO;
using AssetManagement.Provider;


namespace AssetManagement.DAL.DAL
{
    public class LoginDAL : ISelect<LoginDTO>
    {
        public MyProvider provider = null;
        public void Select(LoginDTO login)
        {
            provider = new MyProvider("Select * from Login where UserName='" + login.UserName + "'And Password='" + login.Password + "'");
        }
    }
}
