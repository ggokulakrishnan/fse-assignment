using Moq;
using NSubstitute;
using FSE.PMS.BL;
using FSE.PMS.DA;
using FSE.PMS.IL;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using CommonEntities = FSE.PMS.CE;

namespace FSE.PMS.Tests.UnitTest
{
    public class MockUserBL : IUserBL
    {
        ProjectManagerEntities mockContext = MockDataSetList();

        public Collection<CommonEntities.Users> GetUsers()
        {
            var userBL = new UserBL(mockContext);
            Collection<CommonEntities.Users> users = userBL.GetUsers();

            return users;
        }

        public void AddUser(CommonEntities.Users user)
        {
            var userBL = new UserBL(mockContext);
            userBL.AddUser(user);
        }

        public void UpdateUser(CommonEntities.Users user)
        {
            var userBL = new UserBL(mockContext);
            userBL.UpdateUser(user);
        }

        public void DeleteUser(CommonEntities.Users user)
        {
            var userBL = new UserBL(mockContext);
            userBL.DeleteUser(user);
        }

        private static ProjectManagerEntities MockDataSetList()
        {
            MockProjectManager mockProj = new MockProjectManager();
            ProjectManagerEntities mockContext = mockProj.MockDataSetList();

            return mockContext;
        }
    }
}
