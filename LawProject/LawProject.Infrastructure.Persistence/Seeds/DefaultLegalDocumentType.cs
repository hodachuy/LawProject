using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LawProject.Infrastructure.Persistence.Seeds
{
    public class DefaultLegalDocumentType
    {
        private ILegalTypeRepositoryAsync _legalTypeRepository;
        public async Task CreateLegalType(ILegalTypeRepositoryAsync legalTypeRepository)
        {
            _legalTypeRepository = legalTypeRepository;

            List<LegalDocumentType> _lstLegalType = new List<LegalDocumentType>()
            {
                new LegalDocumentType() {
                    Name = "Văn bản pháp quy",
                    Alias = "LegalDocument"
                },
                new LegalDocumentType() {
                    Name = "Văn bản điều hành",
                    Alias = "LegalDocument_VBDH"
                },
                new LegalDocumentType()
                {
                    Name = "Văn bản hợp nhất",
                    Alias = "LegalDocument_VBHN"
                },
                new LegalDocumentType()
                {
                    Name = "Văn bản sửa đổi bổ sung",
                    Alias = "LegalDocument_VBSDBS"
                },
                new LegalDocumentType()
                {
                    Name = "Văn bản được căn cứ",
                    Alias = "LegalDocument_VBDCC"
                },
                new LegalDocumentType()
                {
                    Name = "Văn bản được dẫn chiếu",
                    Alias = "LegalDocument_VBDDC"
                },
                new LegalDocumentType()
                {
                    Name = "Văn bản",
                    Alias = "Văn bản"
                },
                new LegalDocumentType()
                {
                    Name = "Văn bản đính chính",
                    Alias = "LegalDocument_VBDC"
                },
                new LegalDocumentType()
                {
                    Name = "Văn bản bị sửa đổi bổ sung",
                    Alias = "LegalDocument_VBBSDBS"
                },
                new LegalDocumentType()
                {
                    Name = "Văn bản bị đính chính",
                    Alias = "LegalDocument_VBBDC"
                },
                new LegalDocumentType()
                {
                    Name = "Văn bản hướng dẫn",
                    Alias = "LegalDocument_VBHD"
                },
                new LegalDocumentType()
                {
                    Name = "Văn bản được hướng dẫn",
                    Alias = "LegalDocument_VBDHD"
                },
                new LegalDocumentType()
                {
                    Name = "Văn bản thay thế",
                    Alias = "LegalDocument_VBTT"
                },
                new LegalDocumentType()
                {
                    Name = "Văn bản bị thay thế",
                    Alias = "LegalDocument_VBBTT"
                },
                new LegalDocumentType()
                {
                    Name = "Văn bản hợp nhất",
                    Alias = "LegalDocument_VBHN"
                },
                new LegalDocumentType()
                {
                    Name = "Văn bản được hợp nhất",
                    Alias = "LegalDocument_VBDHN"
                },
                new LegalDocumentType()
                {
                    Name = "Văn bản liên quan ngôn ngữ",
                    Alias = "LegalDocument_VBLQNN"
                },
            };

            foreach (var item in _lstLegalType)
            {
                await _legalTypeRepository.AddAsync(item);
            }
        }
    }
}
