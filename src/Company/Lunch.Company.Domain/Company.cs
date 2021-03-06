﻿using Lunch.Company.Domain.Dtos;
using System;
using System.Collections.Generic;

namespace Lunch.Company.Domain
{
    public class Company
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public CompanySize CompanySize { get; set; }
        public IList<Office> Offices { get; set; }

        private readonly Errors errors;

        public Company(Errors errors)
        {
            this.errors = errors;
        }

        
    }
}
