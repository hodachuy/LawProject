using AutoMapper;
using LawProject.Application.Interfaces.Repositories;
using LawProject.Application.Wrappers;
using LawProject.Domain.Entities;
using LawProject.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LawProject.Application.Features.LegalDocuments.Commands.Create
{
    public abstract class CreateLegalCommand : IRequest<Response<long>>
    {
        public long LegalID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string PublishNo { get; set; }
        public DateTime? PublishedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsPublish { get; set; }
        public long? DocTypeID { get; set; }
        public long? AgencyID { get; set; }
        public long? AreaID { get; set; }
        public string LegalCode { get; set; }
        public string Notes { get; set; }
        public string SigningTitle { get; set; }
        public string SignerName { get; set; }
        public long ViewCount { get; set; }
        public long? EditorID { get; set; }
        public long? LegalTypeID { get; set; }
        public long? LegalRefID { get; set; }
        public string Content { get; set; }
        public string TableOfContents { get; set; }
        public long? LegalGroupID { get; set; }
        public Status.Legal StatusValue { get; set; }
        public string EnglishContent { get; set; }
        public string BookAuthor { get; set; }
        public string CombineAgencyIDs { get; set; }
        public string FTS_FullContent { get; set; }
        public int? DistrictID { get; set; }
        public int? ProvinceID { get; set; }
        public string FTS_FullTitle { get; set; }
        public string FooterRecipients { get; set; }
        public string FooterSigner { get; set; }
        public string FooterAppendix { get; set; }
        public bool HasTrained { get; set; }
        public bool HasAppendix { get; set; }
    }

    public class CreateLegalCommandHandler : IRequestHandler<CreateLegalCommand, Response<long>>
    {
        private readonly ILegalRepositoryAsync _legalRepository;
        private readonly IMapper _mapper;
        public CreateLegalCommandHandler(ILegalRepositoryAsync legalRepository, IMapper mapper)
        {
            _legalRepository = legalRepository;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreateLegalCommand request, CancellationToken cancellationToken)
        {
            var legal = _mapper.Map<LegalDocument>(request);
            await _legalRepository.AddAsync(legal);
            return new Response<long>(legal.LegalID);
        }
    }
}
