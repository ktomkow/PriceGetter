using PriceGetter.Core.BaseClasses.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects
{
    public class Url : ValueObjectBase
    {
        private readonly string value;

        protected Url() { }

        public Url(string url)
        {
            this.EnsureHasValue(url);

            url = this.Format(url);

            this.EnsureUrlIsValid(url);

            this.value = url;
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            bool typeMatch = base.EqualsType<Url>(obj);

            if (typeMatch == false)
            {
                return false;
            }

            Url instance = obj as Url;

            return this.value == instance.ToString();
        }

        public override string ToString()
        {
            return this.value;
        }

        private string Format(string url)
        {
            url = url.Trim();
            return url;
        }

        private void EnsureHasValue(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException($"Url cannot be null or empty");
            }
        }

        private void EnsureUrlIsValid(string url)
        {
            bool startsWithHttp = url.StartsWith("http") || url.StartsWith("https");

            if(startsWithHttp == false)
            {
                throw new ArgumentException($"Url, must start with 'http' or 'https'");
            }
        }
    }
}
