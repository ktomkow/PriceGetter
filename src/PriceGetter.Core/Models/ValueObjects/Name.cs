﻿using PriceGetter.Core.BaseClasses.ValueObjects;
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
            this.EnsureNameIsValid(name);

            name = this.Format(name);

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

        private void EnsureNameIsValid(string name)
        {
            string errorMessage = string.Empty;

            if (name.Length < minLength)
            {
                errorMessage += $"Name {name} is too short, minimal name length: {minLength}";
            }

            if (name.Length > maxLength)
            {
                errorMessage += $"Name {name} is too short, minimal name length: {minLength}";
            }

            if (string.IsNullOrWhiteSpace(errorMessage))
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