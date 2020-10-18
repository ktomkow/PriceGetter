using PriceGetter.Core.BaseClasses.ValueObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects
{
    public class Money : ValueObjectBase
    {
        private static readonly int decimalPlaces = 2;

        public decimal ValueAsDecimal { get; }

        public string ValueAsString => this.ToString();

        protected Money() { }

        public Money(decimal price)
        {
            if (this.IsPriceValid(price))
            {
                this.ValueAsDecimal = this.Round(price);
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
            bool typeMatch = base.EqualsType<Money>(obj);

            if (typeMatch == false)
            {
                return false;
            }

            Money instance = obj as Money;

            return this.ValueAsDecimal == instance.ValueAsDecimal;
        }

        public override int GetHashCode()
        {
            return ValueAsDecimal.GetHashCode();
        }

        public override string ToString()
        {
            return this.ValueAsDecimal.ToString("F", CultureInfo.InvariantCulture);
        }

        #region Operators

        public static bool operator ==(Money leftPrice, Money rightPrice)
        {
            return leftPrice.Equals(rightPrice);
        }

        public static bool operator !=(Money leftPrice, Money rightPrice)
        {
            return !leftPrice.Equals(rightPrice);
        }

        public static bool operator >(Money leftPrice, Money rightPrice)
        {
            bool result = leftPrice.ValueAsDecimal > rightPrice.ValueAsDecimal;
            return result;
        }

        public static bool operator <(Money leftPrice, Money rightPrice)
        {
            bool result = leftPrice.ValueAsDecimal < rightPrice.ValueAsDecimal;
            return result;
        }

        public static bool operator >=(Money leftPrice, Money rightPrice)
        {
            bool result = leftPrice.ValueAsDecimal >= rightPrice.ValueAsDecimal;
            return result;
        }

        public static bool operator <=(Money leftPrice, Money rightPrice)
        {
            bool result = leftPrice.ValueAsDecimal <= rightPrice.ValueAsDecimal;
            return result;
        }

        public static Money operator +(Money leftPrice, Money rightPrice)
        {
            decimal sum = leftPrice.ValueAsDecimal + rightPrice.ValueAsDecimal;
            Money result = new Money(sum);
            return result;
        }

        public static Money operator -(Money leftPrice, Money rightPrice)
        {
            decimal difference = leftPrice.ValueAsDecimal - rightPrice.ValueAsDecimal;

            if(difference < 0)
            {
                difference = 0m;
            }

            Money result = new Money(difference);
            return result;
        }

        public static Money operator /(Money price, int divider)
        {
            if(divider == 0)
            {
                throw new InvalidOperationException("Cannot divide by 0!");
            }

            if(divider < 0)
            {
                divider = -divider;
            }

            decimal mathResult = price.ValueAsDecimal / divider;
            Money result = new Money(mathResult);

            return result;
        }

        #endregion
    }
}
