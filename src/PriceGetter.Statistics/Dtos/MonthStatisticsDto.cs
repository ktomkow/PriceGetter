namespace PriceGetter.Statistics.Dtos
{
    public class MonthStatisticsDto
    {
        public decimal MaxPrice { get; set; }

        public decimal MinPrice { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }
    }
}
