using GenerateCodeProject.Models;
using GenerateCodeProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenerateCodeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : ControllerBase
    {
        public CodeService _codeService;
        public CodeController(CodeService codeService)
        {
            _codeService = codeService;
        }

        [Authorize]
        [HttpGet("GetAllCode")]
        public async Task<IActionResult> GetAllCode()
        {
            var result = _codeService.GetAllCode();
            return Ok(result);
        }

        [Authorize]
        [HttpPost("CheckCode/{code}")]
        public async Task<IActionResult> CheckCode([FromBody]String code)
        {
            bool result = _codeService.CheckCode(code);
            return Ok(result);
        }

    }
}
