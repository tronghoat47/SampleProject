using Sample.Domain.DTOs.RequestModels;
using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Interfaces
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjects();
        Project GetProject(string projectCode);
        Project CreateProject(ProjectCreateRequest projectRequest);
        Project UpdateProject(string projectCode, ProjectUpdateRequest projectRequest);
        void DeleteProject(string projectCode);

        IEnumerable<Member> GetMembersInProject(string projectCode);
        Member AddMemberToProject(MemberCreateRequest memberCreateRequest);
        Member UpdateMemberInProject(string projectCode, string employeeCode, MemberUpdateRequest memberUpdateRequest);
        void RemoveMemberFromProject(string projectCode, string employeeCode);
    }
}
