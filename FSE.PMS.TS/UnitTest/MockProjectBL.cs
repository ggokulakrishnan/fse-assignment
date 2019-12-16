﻿using Moq;
using FSE.PMS.DA;
using FSE.PMS.IL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CommonEntities = FSE.PMS.CE;
using System.Text;
using System.Threading.Tasks;
using FSE.PMS.BL;
using System.Collections.ObjectModel;
using NSubstitute;

namespace FSE.PMS.Tests.UnitTest
{
    public class MockProjectBL : IProjectBL
    {
        public Collection<CommonEntities.Projects> GetProjects()
        {
            ProjectManagerEntities mockContext = MockDataSetList();
            var projectBL = new ProjectBL(mockContext);
            Collection<CommonEntities.Projects> projects = projectBL.GetProjects();

            return projects;
        }

        public void AddProject(CommonEntities.Projects project)
        {
            ProjectManagerEntities mockContext = MockDataSetList();
            var projectBL = new ProjectBL(mockContext);
            projectBL.AddProject(project);
        }

        public void UpdateProject(CommonEntities.Projects project)
        {
            ProjectManagerEntities mockContext = MockDataSetList();
            var projectBL = new ProjectBL(mockContext);
            projectBL.UpdateProject(project);
        }

        public void SuspendProject(int projectID)
        {
            ProjectManagerEntities mockContext = MockDataSetList();
            var projectBL = new ProjectBL(mockContext);
            projectBL.SuspendProject(projectID);
        }

        private static ProjectManagerEntities MockDataSetList()
        {
            MockProjectManager mockProj = new MockProjectManager();
            ProjectManagerEntities mockContext = mockProj.MockDataSetList();

            return mockContext;
        }

    }
}
