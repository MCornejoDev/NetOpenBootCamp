using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityApiBackend.Models.DataModels
{
    public class JwtSettings
    {
        public bool ValidateIsUserSigningKey { get; set; }
        public string IsUserSigningKey { get; set; } = string.Empty;
        public bool ValidateIsUser { get; set; } = true;
        public string? ValidIsUser { get; set; }
        public bool ValidateAudience { get; set; }
        public string? ValidAudience { get; set; }
        public bool RequiredExpirationTime { get; set; }
        public bool ValidateLifeTime { get; set; } = true;
    }
}