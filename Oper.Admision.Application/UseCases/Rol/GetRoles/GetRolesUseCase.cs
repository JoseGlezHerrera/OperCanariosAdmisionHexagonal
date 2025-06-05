using AutoMapper;
using Oper.Admision.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oper.Admision.Application.UseCases.Rol.GetRoles
{
    public class GetRolesUseCase
    {
        private readonly IRolRepository _rolRepository;
        private readonly IMapper _mapper;
        public GetRolesUseCase(IRolRepository rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }
        public List<GetRolesOutput> Execute(GetRolesInput input)
        {
            var roles = _rolRepository.GetAll();
            return _mapper.Map<List<GetRolesOutput>>(roles);
        }
    }
}
