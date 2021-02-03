using LawProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LawProject.Application.Interfaces.Repositories
{
    public interface ILegalRepositoryAsync : IGenericRepositoryAsync<LegalDocument>
    {
        Task<bool> IsUniqueLegalCode(string legalCode);
    }
}
