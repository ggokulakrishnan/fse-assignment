using NSubstitute;
using FSE.PMS.DA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSE.PMS.Tests.UnitTest
{
    public class MockProjectManager
    {
        public ProjectManagerEntities MockDataSetList()
        {
            var dataProjects = new List<Projects>()
            {
                new Projects
                {
                    ProjectID=1,
                    Project="Project 1",
                    StartDate=DateTime.Now.Date,
                    EndDate=DateTime.Now.Date.AddDays(1)
                },
                new Projects
                {
                    ProjectID=2,
                    Project="Project 2",
                    StartDate=DateTime.Now.Date,
                    EndDate=DateTime.Now.Date.AddDays(1)
                },
                new Projects
                {
                    ProjectID=3,
                    Project="Project 3",
                    StartDate=DateTime.Now.Date,
                    EndDate=DateTime.Now.Date.AddDays(1)
                }
            }.AsQueryable();

            //IDbSet<Projects> mocksetProjects = Substitute.For<IDbSet<Projects>>();
            //mocksetProjects.Provider.Returns(dataProjects.Provider);
            //mocksetProjects.Expression.Returns(dataProjects.Expression);
            //mocksetProjects.ElementType.Returns(dataProjects.ElementType);
            //mocksetProjects.GetEnumerator().Returns(dataProjects.GetEnumerator());

            var mocksetProjects = Substitute.For<DbSet<Projects>, IQueryable<Projects>>();
            ((IQueryable<Projects>)mocksetProjects).Provider.Returns(dataProjects.Provider);
            ((IQueryable<Projects>)mocksetProjects).Expression.Returns(dataProjects.Expression);
            ((IQueryable<Projects>)mocksetProjects).ElementType.Returns(dataProjects.ElementType);
            ((IQueryable<Projects>)mocksetProjects).GetEnumerator().Returns(dataProjects.GetEnumerator());

            var dataUsers = new List<Users>()
            {
                new Users
                {
                    UserID=1,
                    ProjectID=1,
                    FirstName="Sathya",
                    LastName="Natarajan",
                    EmployeeID="433461"
                },
                new Users
                {
                    UserID=2,
                    ProjectID=1,
                    FirstName="Murali",
                    LastName="S",
                    EmployeeID="433465"
                },
                new Users
                {
                    UserID=3,
                    ProjectID=2,
                    FirstName="Hari",
                    LastName="M",
                    EmployeeID="433469"
                }
            }.AsQueryable();

            //IDbSet<Users> mocksetUsers = Substitute.For<IDbSet<Users>>();
            //mocksetUsers.Provider.Returns(dataUsers.Provider);
            //mocksetUsers.Expression.Returns(dataUsers.Expression);
            //mocksetUsers.ElementType.Returns(dataUsers.ElementType);
            //mocksetUsers.GetEnumerator().Returns(dataUsers.GetEnumerator());

            var mocksetUsers = Substitute.For<DbSet<Users>, IQueryable<Users>>();
            ((IQueryable<Users>)mocksetUsers).Provider.Returns(dataUsers.Provider);
            ((IQueryable<Users>)mocksetUsers).Expression.Returns(dataUsers.Expression);
            ((IQueryable<Users>)mocksetUsers).ElementType.Returns(dataUsers.ElementType);
            ((IQueryable<Users>)mocksetUsers).GetEnumerator().Returns(dataUsers.GetEnumerator());
            
            var dataTasks = new List<Tasks>()
            {
                new Tasks
                {
                    TaskID=1,
                    Task="Task 1",
                    ProjectID=1,
                    Priority=10,
                    StartDate=DateTime.Now.Date,
                    EndDate=DateTime.Now.Date.AddDays(1)
                },
                new Tasks
                {
                    TaskID=2,
                    Task="Task 2",
                    ProjectID=1,
                    Priority=20,
                    StartDate=DateTime.Now.Date,
                    EndDate=DateTime.Now.Date.AddDays(1),
                    Status=true
                },
                new Tasks
                {
                   TaskID=3,
                    Task="Task 3",
                    ProjectID=2,
                    Priority=10,
                    StartDate=DateTime.Now.Date,
                    EndDate=DateTime.Now.Date.AddDays(1)
                },
                new Tasks
                {
                   TaskID=4,
                    Task="Task 4",
                    ProjectID=2,
                    Priority=20,
                    StartDate=DateTime.Now.Date,
                    EndDate=DateTime.Now.Date.AddDays(1),
                    Status=true
                }
            }.AsQueryable();

            //IDbSet<Tasks> mocksetTasks = Substitute.For<IDbSet<Tasks>>();
            //mocksetTasks.Provider.Returns(dataTasks.Provider);
            //mocksetTasks.Expression.Returns(dataTasks.Expression);
            //mocksetTasks.ElementType.Returns(dataTasks.ElementType);
            //mocksetTasks.GetEnumerator().Returns(dataTasks.GetEnumerator());

            var mocksetTasks = Substitute.For<DbSet<Tasks>, IQueryable<Tasks>>();
            ((IQueryable<Tasks>)mocksetTasks).Provider.Returns(dataTasks.Provider);
            ((IQueryable<Tasks>)mocksetTasks).Expression.Returns(dataTasks.Expression);
            ((IQueryable<Tasks>)mocksetTasks).ElementType.Returns(dataTasks.ElementType);
            ((IQueryable<Tasks>)mocksetTasks).GetEnumerator().Returns(dataTasks.GetEnumerator());

            var dataPTasks = new List<ParentTasks>()
            {
                new ParentTasks
                {
                    ParentTaskID=1,
                    ParentTask="Parent Task 1"
                },
                new ParentTasks
                {
                    ParentTaskID=2,
                    ParentTask="Parent Task 2"
                }
            }.AsQueryable();

            //IDbSet<ParentTasks> mocksetPTasks = Substitute.For<IDbSet<ParentTasks>>();
            //mocksetPTasks.Provider.Returns(dataPTasks.Provider);
            //mocksetPTasks.Expression.Returns(dataPTasks.Expression);
            //mocksetPTasks.ElementType.Returns(dataPTasks.ElementType);
            //mocksetPTasks.GetEnumerator().Returns(dataPTasks.GetEnumerator());

            //ProjectManagerEntities mockContext = Substitute.For<ProjectManagerEntities>();
            //mockContext.Projects.Returns(mocksetProjects);
            //mockContext.Users.Returns(mocksetUsers);
            //mockContext.Tasks.Returns(mocksetTasks);
            //mockContext.ParentTasks.Returns(mocksetPTasks);
            
            var mocksetPTasks = Substitute.For<DbSet<ParentTasks>, IQueryable<ParentTasks>>();
            ((IQueryable<ParentTasks>)mocksetPTasks).Provider.Returns(dataPTasks.Provider);
            ((IQueryable<ParentTasks>)mocksetPTasks).Expression.Returns(dataPTasks.Expression);
            ((IQueryable<ParentTasks>)mocksetPTasks).ElementType.Returns(dataPTasks.ElementType);
            ((IQueryable<ParentTasks>)mocksetPTasks).GetEnumerator().Returns(dataPTasks.GetEnumerator());

            var mockContext = Substitute.For<ProjectManagerEntities>();
            mockContext.Projects.Returns(mocksetProjects);
            mockContext.Users.Returns(mocksetUsers);
            mockContext.Tasks.Returns(mocksetTasks);
            mockContext.ParentTasks.Returns(mocksetPTasks);

            return mockContext;
        }
    }
}
