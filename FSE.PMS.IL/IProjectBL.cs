using System.Collections.ObjectModel;

namespace FSE.PMS.IL
{
    public interface IProjectBL
    {
        Collection<CE.Projects> GetProjects();
        void AddProject(CE.Projects project);
        void UpdateProject(CE.Projects project);
        void SuspendProject(int projectID);
    }
}
