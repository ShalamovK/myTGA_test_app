using AutoMapper;
using myTGA_Common.Contracts;
using myTGA_Common.Contracts.Services;
using myTGA_Common.Dto;
using myTGA_Common.Entities;
using System.Collections.Generic;
using System.Linq;

namespace myTGA.BLL.Services {
    public class EmployeeService : BaseService, IEmployeeService {
        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) {
        }

        public List<EmployeeDto> GetAll() {
            return _unitOfWork.GetRepository<Employee>().GetAll()
                .Select(x => new EmployeeDto {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).ToList();
        }
    }
}
