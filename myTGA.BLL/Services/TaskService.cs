using AutoMapper;
using myTGA_Common.Contracts;
using myTGA_Common.Contracts.Services;
using myTGA_Common.Dto;
using myTGA_Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myTGA.BLL.Services {
    public class TaskService : BaseService, ITaskService {
        public TaskService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) {
        }

        public List<TaskDto> GetAll() {
            return _unitOfWork.GetRepository<Task>().GetAll()
                .Select(x => new TaskDto { 
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
        }
    }
}
