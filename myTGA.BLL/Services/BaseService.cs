using AutoMapper;
using myTGA_Common.Contracts;
using myTGA_Common.Contracts.Services;
using System;

namespace myTGA.BLL.Services {
    public class BaseService : IBaseService {
        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper) {
            if (unitOfWork == null) {
                throw new NullReferenceException("UnitOfWork");
            }

            if (mapper == null) {
                throw new NullReferenceException("Mapper");
            }

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
