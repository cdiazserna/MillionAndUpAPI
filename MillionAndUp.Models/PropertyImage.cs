﻿using Microsoft.AspNetCore.Http;

namespace MillionAndUp.Models
{
    public class PropertyImage : AuditBase
    {
        public Guid? File { get; set; }
        public bool Enabled { get; set; }
        public Property? Property { get; set; }
    }
}
