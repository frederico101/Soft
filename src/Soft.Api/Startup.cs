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

        app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
        {
            TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            }
        });
    }
}
