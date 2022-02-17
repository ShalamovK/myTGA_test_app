using myTGA_Common.Dto;
using System.Collections.Generic;

namespace myTGA_Common.Contracts.Services {
    public interface ITaskService : IBaseService {
        List<TaskDto> GetAll();
    }
}
