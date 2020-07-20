using PriceGetter.Core.BaseClasses.ValueObjects;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects
{
    public class Name : ValueObjectBase
    {
        private static readonly int minLength = 4;
        private static readonly int maxLength = 100;

        public string Value { get; }

        public Name(string name)
        {
            this.EnsureHasValue(name);

            name = this.Format(name);

            this.EnsureNameIsValid(name);

            this.Value = name;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            bool typeMatch = base.EqualsType<Name>(obj);

            if (typeMatch == false)
            {
                return false;
            }

            Name instance = obj as Name;

            return this.Value == instance.Value;
        }

        public static bool operator ==(Name leftName, Name rightName)
        {
            return leftName.Equals(rightName);
        }

        public static bool operator !=(Name leftName, Name rightName)
        {
            return !leftName.Equals(rightName);
        }

        private void EnsureHasValue(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"Name cannot be null or empty");
            }
        }

        private void EnsureNameIsValid(string name)
        {
            string errorMessage = string.Empty;

            if (name.Length < minLength)
            {
                errorMessage += $"Name {name} is too short, minimal name length: {minLength}";
            }
            else if (name.Length > maxLength)
            {
                errorMessage += $"Name {name} is too short, minimal name length: {minLength}";
            }

            if (string.IsNullOrWhiteSpace(errorMessage) == false)
            {
                throw new ArgumentException(errorMessage);
            }
        }

        private string Format(string name)
        {
            name = name.Trim();
            return name;
        }
    }
}
