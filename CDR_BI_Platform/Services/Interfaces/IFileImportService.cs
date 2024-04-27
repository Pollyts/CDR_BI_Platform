using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using CDR_BI_Platform.Models;

namespace CDR_BI_Platform.Services.Interfaces
{
    public interface IFileImportService
    {
        void Save(IFormFile file);
    }
}
