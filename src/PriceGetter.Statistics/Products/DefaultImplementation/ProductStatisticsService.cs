using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Infrastructure.Logging;
using PriceGetter.Statistics.Domain;
using PriceGetter.Statistics.Dtos;
using PriceGetter.Statistics.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceGetter.Statistics.Products.DefaultImplementation
{
    public class ProductStatisticsService : IProductStatisticsService
    {
        private readonly IMonthStatisticsCreator monthStatistics;
        private readonly IPriceGetterLogger logger;
        private readonly IProductsRepository productsRepository;

        public ProductStatisticsService(
            IMonthStatisticsCreator monthStatistics,
            IPriceGetterLogger logger,
            IProductsRepository productsRepository)
        {
            this.monthStatistics = monthStatistics ?? throw new ArgumentNullException(nameof(monthStatistics));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
        }

        public async Task<IEnumerable<MonthStatisticsDto>> PrepareMonthStatistics(Guid productId)
        {
            if(productId.Equals(Guid.Empty))
            {
                throw new ArgumentNullException(nameof(productId));
            }

            Product product = await this.productsRepository.Get(productId);

            IEnumerable<MonthStatistics> statistics = this.monthStatistics.Create(product);

            IEnumerable<MonthStatisticsDto> statisticsDtos = this.Map(statistics);

            return statisticsDtos;
        }

        private IEnumerable<MonthStatisticsDto> Map(IEnumerable<MonthStatistics> statistics)
        {
            List<MonthStatisticsDto> list = new List<MonthStatisticsDto>();
            foreach (var item in statistics)
            {
                try
                {
                    list.Add(this.Map(item));
                }
                catch (ArgumentNullException e)
                {
                    this.logger.Error(e, "Unexcpected null");
                    continue;
                }
            }

            return list;
        }

        private MonthStatisticsDto Map(MonthStatistics statistics)
        {
            if (statistics is null)
            {
                throw new ArgumentNullException(nameof(statistics));
            }

            return new MonthStatisticsDto
            {
                MaxPrice = statistics.MaxPrice.ValueAsDecimal,
                MinPrice = statistics.MinPrice.ValueAsDecimal,
                Month = statistics.Month,
                Year = statistics.Year
            };
        }
    }
}
