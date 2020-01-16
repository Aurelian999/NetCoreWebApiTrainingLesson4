using StudentsAPI.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsAPIClient.Services
{
    public interface ICommitsAPIService
    {
        Task<IEnumerable<CodeCommit>> Get();
    }
}