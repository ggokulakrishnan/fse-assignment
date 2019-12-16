using System.Collections.ObjectModel;
using CommonEntities = FSE.PMS.CE;

namespace FSE.PMS.IL
{
    public interface IUserBL
    {
        Collection<CommonEntities.Users> GetUsers();
        void AddUser(CommonEntities.Users user);
        void UpdateUser(CommonEntities.Users user);
        void DeleteUser(CommonEntities.Users user);
    }
}
