﻿namespace api_reservas.Models
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int TokenExpireInMinutes { get; set; }

    }
}
