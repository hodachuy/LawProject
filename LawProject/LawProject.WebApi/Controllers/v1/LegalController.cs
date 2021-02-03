using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LawProject.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class LegalController : BaseApiController
    {
        private readonly ILogger<ProductController> _logger;
        public LegalController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
    }
}
