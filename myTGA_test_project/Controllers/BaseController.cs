using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;

namespace myTGA_test_project.Controllers {
    public class BaseController : Controller {
        protected IServiceProvider _serviceProvider;
        protected IMapper _mapper;

        public BaseController(IServiceProvider serviceProvider, IMapper mapper) {
            _serviceProvider = serviceProvider;
            _mapper = mapper;
        }
    }
}
