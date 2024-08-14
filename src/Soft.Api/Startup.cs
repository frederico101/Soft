using Microsoft.Owin;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using Owin;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class Startup
{
    public void Configuration(IAppBuilder app)
    {
        var key = Encoding.ASCII.GetBytes("s3gur1t33eyJw7S3c53tK3y-frederico-brit0-alves");
        var issuer = "https://myapp.example.com";  // Your issuer URL or unique identifier
        var audience = "https://myapp.example.com"; // Your audience URL or unique identifier

        app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
        {
            TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidIssuer = issuer,
                ValidAudience = audience
            }
        });
    }
}
