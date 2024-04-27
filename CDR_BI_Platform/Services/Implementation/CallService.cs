using System.Collections.Generic;
using System.Linq;
using System;
using CDR_BI_Platform.Models;
using CDR_BI_Platform.Repositories.Interfaces;
using CDR_BI_Platform.Services.Interfaces;
using CDR_BI_Platform.Extentions;
using Microsoft.Extensions.Logging;
using CDR_BI_Platform.ViewModels;

namespace CDR_BI_Platform.Services.Implementation
{
    public class CallService : IBaseService<Call> , ICallService
    {
        protected readonly IBaseRepository<Call> _repository;
        private readonly ILogger<Call> _logger;

        public CallService(IBaseRepository<Call> repository,
            ILogger<Call> logger)
        {
            _repository = repository;
            _logger = logger;
        }        

        public virtual StatisticViewModel GetStatistic(DateTime? startDate, DateTime? endDate)
        {
            var calls = GetCallsByDate(startDate, endDate);

            return new StatisticViewModel()
            {
                CallsCount = CallsCount(calls),
                TheLongestCall = TheLongestCall(calls),
            }
        }

        public IQueryable<Call> GetCallsByDate(DateTime? startDate, DateTime? endDate)
        {
            var query = _repository.GetQuery()
                .Where(c => startDate != null && endDate == null && c.Date>startDate ||
                startDate == null && endDate != null && c.Date<endDate ||
                startDate !=null && endDate !=null && c.Date>startDate && c.Date<endDate ||
                startDate == null && endDate == null);

            return query;
        }

        public LinkedEntity? TheLongestCall(IQueryable <Call> query)
        {
            return query.OrderByDescending(c=>c.Duration).Select(c=> new LinkedEntity() { Id = c.Id, Value = c.Duration.ToString()}).FirstOrDefault();
        }

        public int CallsCount(IQueryable<Call> query)
        {
            return query.Count();
        }

        public void CreateFromFile(IFormFile file)
        {
            List<Call> calls = new List<Call>();
            switch (file.ContentType)
            {
                case "csv":
                    calls = ParseCSV(file);
                    break;
            }

            SaveCallsToDB(calls);                
        }

        private List<Call> ParseCSV(IFormFile file)
        {
            List<Call> records = new List<Call>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                //Headers
                reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var values = line.Split(',');

                    Call record = new Call
                    {
                        CallPhone = values[0],
                        RecipientPhone = values[1],
                        Date = DateTime.Parse(values[2]),
                        EndTime = DateTime.Parse(values[3]),
                        Duration = int.Parse(values[4]),
                        Cost = int.Parse(values[5]),
                        Reference = values[6],
                        Currency = values[7]
                    };

                    records.Add(record);
                }
            }

            return records;
        }

        private void SaveCallsToDB(List<Call> calls)
        {
            foreach (var call in calls)
            {
                _repository.Add(call);
            }
            _repository.SaveChanges();
        }

        public virtual Call Get(int id)
        {
            var entity = _repository.FirstOrDefault(entity => entity.Id == id);
            if (entity == null)
                throw new ClientException("Item not fount");

            return entity;
        }

        public virtual IEnumerable<Call> GetAll()
        {
            return _repository.GetQuery().AsEnumerable();
        }

        public int Create(Call create)
        {
            var item = _repository.Add(create);
            _repository.SaveChanges();
            return item.Id;
        }

        public void Update(Call edit)
        {
            _repository.Update(edit);
            _repository.SaveChanges();
        }

        public void Delete(int id)
        {
            var translator = _repository.FirstOrDefault(t => t.Id == id);
            _repository.Delete(translator);
            _repository.SaveChanges();
        }
    }
}

