using Sample.Domain.DTOs.RequestModels;
using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = Sample.Domain.Entities.Task;

namespace Sample.Domain.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetTasksByProjectId(string projectCode);
        IEnumerable<Task> GetTasksBySprintId(int sprintId);
        Task GetTask(int id);
        Task CreateTask(TaskRequestCreate request);
        Task UpdateTask(int id, TaskRequestUpdate request);
        void DeleteTask(int id);
    }
}
