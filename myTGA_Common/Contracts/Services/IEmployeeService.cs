using myTGA_Common.Dto;
using System.Collections.Generic;

namespace myTGA_Common.Contracts.Services {
    public interface IEmployeeService : IBaseService {
        List<EmployeeDto> GetAll();
    }
}
