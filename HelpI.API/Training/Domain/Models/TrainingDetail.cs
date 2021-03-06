using System;
using System.Collections.Generic;
using HelpI.API.SeedWork;

namespace HelpI.API.Training.Domain.Models
{
    public class TrainingDetail : ValueObject
    {
        public TrainingDetail()
        {
        }

        public TrainingDetail(Uri videoUri, DateTime publishedDate, string currency, decimal price)
        {
            VideoUri = videoUri;
            PublishedDate = publishedDate;
            Currency = currency;
            Price = price;
        }
        public Uri VideoUri { get; private set; }
        public DateTime PublishedDate { get; private set; }
        public string Currency { get; private set; }
        public decimal Price { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return VideoUri;
            yield return PublishedDate;
            yield return Currency;
            yield return Price;
        }
    }
}
