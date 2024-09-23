using Sample.Domain.DTOs.RequestModels;
using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Interfaces
{
    public interface ISprintRepository
    {
        IEnumerable<Sprint> GetSprints();
        Sprint GetSprint(int id);
        Sprint CreateSprint(SprintRequestCreate request);
        Sprint UpdateSprint(int id, SprintRequestUpdate request);
        void DeleteSprint(int id);
    }
}
