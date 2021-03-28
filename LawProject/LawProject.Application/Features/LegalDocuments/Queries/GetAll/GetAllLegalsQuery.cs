using AutoMapper;
using LawProject.Application.Interfaces.Repositories;
using LawProject.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LawProject.Application.Features.LegalDocuments.Queries.GetAll
{
    public class GetAllLegalsQuery : IRequest<PagedResponse<IEnumerable<GetAllLegalsViewModel>>>
    {
        public Dictionary<string, string> ParamFilters { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllLegalsQueryHandler : IRequestHandler<GetAllLegalsQuery, PagedResponse<IEnumerable<GetAllLegalsViewModel>>>
    {
        private readonly ILegalRepositoryAsync _legalRepository;
        private readonly IMapper _mapper;
        public GetAllLegalsQueryHandler(ILegalRepositoryAsync legalRepository, IMapper mapper)
        {
            _legalRepository = legalRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllLegalsViewModel>>> Handle(GetAllLegalsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllLegalsParameter>(request);
            var legal = await _legalRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var lstLegalViewModel = _mapper.Map<IEnumerable<GetAllLegalsViewModel>>(legal);
            return new PagedResponse<IEnumerable<GetAllLegalsViewModel>>(lstLegalViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
