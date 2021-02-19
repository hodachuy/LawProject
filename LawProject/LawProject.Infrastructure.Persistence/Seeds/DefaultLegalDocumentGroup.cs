using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LawProject.Infrastructure.Persistence.Seeds
{
    public class DefaultLegalDocumentGroup
    {
        private ILegalGroupRepositoryAsync _legalGroupRepository;
        public async Task CreateLegalGroup(ILegalGroupRepositoryAsync legalGroupRepository)
        {
            _legalGroupRepository = legalGroupRepository;

            List<LegalDocumentGroup> _lstLegalGroup = new List<LegalDocumentGroup>()
            {
                new LegalDocumentGroup() { 
                    Name = "Văn bản pháp luật",
                    Alias = "van-ban-phap-luat",
                    Value = 1
                },
                new LegalDocumentGroup() {
                    Name = "Văn bản Ủy ban nhân dân",
                    Alias = "van-ban-uy-ban-nhan-dan",
                    Value = 2
                },
                new LegalDocumentGroup()
                {
                    Name = "Công văn",
                    Alias = "cong-van",
                    Value = 3
                },
                new LegalDocumentGroup()
                {
                    Name = "Tiêu chuẩn Việt Nam",
                    Alias = "tieu-chuan-viet-nam",
                    Value = 4
                },
                new LegalDocumentGroup()
                {
                    Name = "Dự thảo",
                    Alias = "du-thao",
                    Value = 5
                },
                new LegalDocumentGroup()
                {
                    Name = "Chỉ dẫn áp dụng",
                    Alias = "chi-dan-ap-ding",
                    Value = 6
                },
                new LegalDocumentGroup()
                {
                    Name = "Văn bản hợp nhất",
                    Alias = "van-ban-hop-nhap",
                    Value = 7
                },
                new LegalDocumentGroup()
                {
                    Name = "Văn bản địa phương",
                    Alias = "van-ban-dia-phuong",
                    Value = 8
                }
            };

            foreach(var item in _lstLegalGroup)
            {
                await _legalGroupRepository.AddAsync(item);
            }
        }
    }
}
