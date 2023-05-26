using appRepubliquei.Domain.Commands.LoginCommand;
using appRepubliquei.Domain.Contracts.Repository;
using appRepubliquei.Domain.Contracts.Services;
using appRepubliquei.Domain.Entidades;
using appRepubliquei.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace appRepubliquei.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        private readonly SigninConfigurations _signinConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly IConfiguration _configuration;

        public LoginService(IUsuarioRepository usuarioRepository, 
                            SigninConfigurations signinConfigurations, 
                            TokenConfigurations tokenConfigurations, 
                            IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _tokenConfigurations = tokenConfigurations;
            _signinConfigurations = signinConfigurations;
            _configuration = configuration;
        }

        public async Task<vwExisteUsuario> VerificarExistenciaLogin(VerificarExistenciaLoginCommand request)
        {
            try
            {
                if (request.Email != null && !string.IsNullOrEmpty(request.Email) &&
                    request.Senha != null && !string.IsNullOrEmpty(request.Senha))
                {
                    var retorno = await _usuarioRepository.VerificarExistenciaLogin(request.Email, request.Senha);
                    if(retorno.Sucesso == false)
                    {
                        return retorno;
                    }
                    else
                    {
                        // Aqui começa o JWT
                        ClaimsIdentity identity = new ClaimsIdentity(
                            new GenericIdentity(request.Email),
                            new[]
                            {
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // jid -> id token
                                new Claim(JwtRegisteredClaimNames.UniqueName, request.Email),
                                new Claim("userId", retorno.ExisteUsuario.ID.ToString())
                            }
                        );

                        DateTime createDate = DateTime.Now;
                        DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                        var handler = new JwtSecurityTokenHandler();
                        string token = CreateToken(identity, createDate, expirationDate, handler);

                        return SuccessObject(createDate, expirationDate, token, retorno.ExisteUsuario);
                    }
                }
                return new vwExisteUsuario
                {
                    Mensagem = "Campo de email ou senha vazio ou inválido",
                    Autheiticated = false,
                    Sucesso = false
                };
            }
            catch (Exception ex)
            {
                return new vwExisteUsuario
                {
                    Mensagem = "Ocorreu um erro ao verificar a existência do usuario: " + ex,
                    Autheiticated = false,
                    Sucesso = false
                };

                throw new Exception("Imovel não encontrado");
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signinConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });
            
            var token = handler.WriteToken(securityToken);
            return token;
        }

        private vwExisteUsuario SuccessObject(DateTime createDate, DateTime expirationDate, string token, ExisteUsuarioInternal user)
        {
            return new vwExisteUsuario
            {
                Autheiticated = true,
                Created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                AcessToken = token,
                UserName = user.Email,
                Name = user.Nome,
                Mensagem = "Usuario Logado com sucesso",
                Sucesso = true,
                ExisteUsuario = user
            };
        }
    }
}
