using PriceGetter.Core.BaseClasses.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects
{
    public class Price : ValueObjectBase
    {
        private static readonly int decimalPlaces = 4;

        public decimal Value { get; }

        protected Price() { }

        public Price(decimal price)
        {
            if (this.IsPriceValid(price))
            {
                this.Value = this.Round(price);
            }
            else
            {
                throw new ArgumentException("Incorrect price", nameof(price));
            }
        }

        private decimal Round(decimal value)
        {
            decimal newValue = decimal.Round(value, decimalPlaces);
            return newValue;
        }

        private bool IsPriceValid(decimal price)
        {
            if(price < 0)
            {
                throw new ArgumentException(nameof(price));
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            bool typeMatch = base.EqualsType<Price>(obj);

            if (typeMatch == false)
            {
                return false;
            }

            Price instance = obj as Price;

            return this.Value == instance.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        #region Operators

        public static bool operator ==(Price leftPrice, Price rightPrice)
        {
            return leftPrice.Equals(rightPrice);
        }

        public static bool operator !=(Price leftPrice, Price rightPrice)
        {
            return !leftPrice.Equals(rightPrice);
        }

        public static bool operator >(Price leftPrice, Price rightPrice)
        {
            bool result = leftPrice.Value > rightPrice.Value;
            return result;
        }

        public static bool operator <(Price leftPrice, Price rightPrice)
        {
            bool result = leftPrice.Value < rightPrice.Value;
            return result;
        }

        public static bool operator >=(Price leftPrice, Price rightPrice)
        {
            bool result = leftPrice.Value >= rightPrice.Value;
            return result;
        }

        public static bool operator <=(Price leftPrice, Price rightPrice)
        {
            bool result = leftPrice.Value <= rightPrice.Value;
            return result;
        }

        public static Price operator +(Price leftPrice, Price rightPrice)
        {
            decimal sum = leftPrice.Value + rightPrice.Value;
            Price result = new Price(sum);
            return result;
        }

        public static Price operator -(Price leftPrice, Price rightPrice)
        {
            decimal difference = leftPrice.Value - rightPrice.Value;

            if(difference < 0)
            {
                difference = 0m;
            }

            Price result = new Price(difference);
            return result;
        }

        public static Price operator /(Price price, int divider)
        {
            if(divider == 0)
            {
                throw new InvalidOperationException("Cannot divide by 0!");
            }

            if(divider < 0)
            {
                divider = -divider;
            }

            decimal mathResult = price.Value / divider;
            Price result = new Price(mathResult);

            return result;
        }

        #endregion
    }
}
