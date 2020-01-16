using StudentsAPI.V2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsAPIClient.Services
{
    public interface IStudentsAPIService
    {
        Task<IEnumerable<Student>> Get();
    }
}