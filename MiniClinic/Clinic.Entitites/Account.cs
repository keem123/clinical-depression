﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Entitites
{
    public enum AccountType
    {
        Administrator = 2048,
        Regular = 100,
        None = 0,
    }
    public enum AccountStatus
    {
        Active = 1,
        Inactive = 0,
        None = 0,
    }
    public class Account : EntityBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public AccountType Type { get; set; } = AccountType.None;
        public AccountStatus Status { get; set; } = AccountStatus.None;
    }
}