using StudentsAPI.Core.Entities;
using StudentsAPI.V2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAPIClient.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly CommitsAPIService commitsAPIService;
        private readonly StudentsAPIService studentsAPIService;
        private readonly List<Statistic> statistics;

        public StatisticsService(CommitsAPIService commitsAPIService, StudentsAPIService studentsAPIService)
        {
            this.commitsAPIService = commitsAPIService;
            this.studentsAPIService = studentsAPIService;
            statistics = new List<Statistic>();
        }


        public async Task<IEnumerable<Statistic>> Get(string orderByProperty = null)
        {
            await GenerateStatistics();

            IEnumerable<Statistic> res = orderByProperty.ToLower() switch
            {
                "name" => statistics.OrderBy(s => s.StudentName),
                "commits" => statistics.OrderBy(s => s.CommitCount),
                "lines" => statistics.OrderBy(s => s.CodeLinesCount),
                _ => statistics
            };

            return res;
        }

        private async Task GenerateStatistics()
        {
            var students = await studentsAPIService.Get();
            var commits = await commitsAPIService.Get();

            foreach (var student in students)
            {
                var studentsCommits = commits.Where(c => c.UserId == student.Id);

                Statistic statistic = new Statistic
                {
                    StudentName = student.FirstName + student.LastName,
                    CommitCount = studentsCommits.Count(),
                    CodeLinesCount = studentsCommits.Select(sc => sc.LinesModified ?? 0)
                                                    .Sum(x => (int)x)
                };

                statistics.Add(statistic);
            }
        }
    }
}
