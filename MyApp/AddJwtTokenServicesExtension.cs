using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend
{
    public static class AddJwtTokenServicesExtension
    {
        public static void AddJwtTokenServices(this IServiceCollection Services, IConfiguration Configuration)
        {
            //Add JWT Settings 
            var bindJwtSettings = new JwtSettings();
            Configuration.Bind("JsonWebTokenKeys", bindJwtSettings);

            //Add Singleton of JWT Settings
            Services.AddSingleton(bindJwtSettings);

            Services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = bindJwtSettings.ValidateIsUserSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSettings.IsUserSigningKey)),
                    ValidateIssuer = bindJwtSettings.ValidateIsUser,
                    ValidIssuer = bindJwtSettings.ValidIsUser,
                    ValidateAudience = bindJwtSettings.ValidateAudience,
                    ValidAudience = bindJwtSettings.ValidAudience,
                    RequireExpirationTime = bindJwtSettings.RequiredExpirationTime,
                    ValidateLifetime = bindJwtSettings.ValidateLifeTime,
                    ClockSkew = TimeSpan.FromDays(1)
                };
            });
        }
    }
}