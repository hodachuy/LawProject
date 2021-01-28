using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
    }
}
