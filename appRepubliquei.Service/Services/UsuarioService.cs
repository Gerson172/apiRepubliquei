using appRepubliquei.Domain.Commands.UsuarioCommand;
using appRepubliquei.Domain.Contracts.Repository;
using appRepubliquei.Domain.Contracts.Services;
using appRepubliquei.Domain.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;

namespace appRepubliquei.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly SmtpClient _smtpClient;
        private readonly IConfiguration _configuration;

        public UsuarioService(IUsuarioRepository usuarioRepository, SmtpClient smtpClient, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _smtpClient = smtpClient;
            _configuration = configuration;
            
        }

        public async Task<Usuario> ObterUsuarioPorId(int? idUsuario)
        {
            try
            {           
                return await _usuarioRepository.ObterUsuarioPorId(idUsuario);
            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao obter um usuario: " + ex);
            }

        }

        public async Task<IEnumerable<Usuario>> ObterUsuario(ObterUsuarioCommand request)
        {
            try
            {
                return await _usuarioRepository.ObterUsuario();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao obter usuario: " + ex);
            }
        }

        public async Task<IEnumerable<vwUsuarioContato>> ObterUsuarioContato(ObterUsuarioContatoCommand request)
        {
            try
            {
                return await _usuarioRepository.ObterUsuarioContato();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao obter contato do usuario: " + ex);
            }
        }

        public async Task<vwUsuarioContato> ObterUsuarioContatoPorId(ObterUsuarioContatoPorIdCommand request)
        {
            try
            {
                return await _usuarioRepository.ObterUsuarioContatoPorId(request.IdUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao obter contato do usuario: " + ex);
            }
        }

        public async Task<RetornoSimples> CadastrarUsuario(CadastrarUsuarioCommand request)
        {
            try
            {
                //#region Criptografia em Hash da senha
                //byte[] salt = new byte[128 / 8];
                //using (var rngCsp = new RNGCryptoServiceProvider())
                //{
                //    rngCsp.GetNonZeroBytes(salt);
                //}
                //var senha = request.Senha;
                //string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                //password: senha,
                //salt: salt,
                //prf: KeyDerivationPrf.HMACSHA256,
                //iterationCount: 100000,
                //numBytesRequested: 256 / 8));
                //request.Senha = hashed;
                //#endregion

                var result = _usuarioRepository.VerificarEmailCpf(request.Contato.Email, request.CPF);
                if (result)
                {
                    return new RetornoSimples(false, "Já possui Email ou CPF cadastrado com esse usuário.");
                }

                await _usuarioRepository.InserirEnderecoUsuario(request.EnderecoUsuario.CEP, request.EnderecoUsuario.Estado, request.EnderecoUsuario.Cidade, request.EnderecoUsuario.Bairro,
                    request.EnderecoUsuario.Logradouro, request.EnderecoUsuario.Numero, request.EnderecoUsuario.Complemento);

                await _usuarioRepository.InserirContatoUsuario(request.Contato.Email, request.Contato.Celular, request.Contato.Telefone);

                await _usuarioRepository.InserirCaracteristicaUsuario(request.CaracteristicaUsuario.Religiao, request.CaracteristicaUsuario.Genero, 
                    request.CaracteristicaUsuario.Sexo, request.CaracteristicaUsuario.OrientacaoSexual,request.CaracteristicaUsuario.AreaInteresse);

                var ContatoUsuario = await _usuarioRepository.ObterUltimoRegistroInseridoContatoUsuario();
                var EnderecoUsuario = await _usuarioRepository.ObterUltimoRegistroInseridoUsuario();
                var CaracteristicaUsuario = await _usuarioRepository.ObterUltimoRegistroInseridoCaracteristicaUsuario();

                await _usuarioRepository.InserirUsuario(request.Nome, request.Sobrenome, request.Senha, request.CPF, request.EstadoCivil,
                    request.DataNascimento, request.CheckProprietario,request.CheckTermos, EnderecoUsuario.ID, ContatoUsuario.ID, CaracteristicaUsuario.ID);

                return new RetornoSimples(true, "Usuario cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao cadastrar usuario: " + ex);
            }
            
        }

        public async Task<RetornoSimples> ExcluirUsuarioPorId(ExcluirUsuarioPorIdCommand request)
        {
            try
            {
                await _usuarioRepository.ExcluirUsuarioPorId(request.IdUsuario);

                return new RetornoSimples(true, "Usuario excluido com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao excluir usuario: " + ex);
            }
        }

        public async Task<RetornoSimples> SolicitarAlteracao(SolicitarAlteracaoCommand request)
        {
            try
            {
                bool user =  _usuarioRepository.VerificarEmail(request.Email);
                if (user != true)
                {
                    return new RetornoSimples(false, "E-mail não cadastrado!");
                }
                var usuario = await _usuarioRepository.ObterUsuarioPorEmail(request.Email);

                var token = GeneratePasswordResetToken();
                var encodedToken = HttpUtility.UrlEncode(token);
                var url = $"https://localhost:3000/redefinir-senha?email={request.Email}&token={encodedToken}";

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Html/email.html");
                string htmlBody = File.ReadAllText(path)
                    .Replace("[FIRSTNAME]", usuario.Nome)
                    .Replace("[LINKRESETARSENHA]", url);

                string emailSender = _configuration.GetValue<string>("Email:Smtp:Sender");

                // Create the mail message:
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpClient.Credentials.GetCredential(_smtpClient.Host, _smtpClient.Port, "Basic").UserName),
                    Subject = "Redefinição de Senha",
                    Body = htmlBody,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(request.Email);

                await _smtpClient.SendMailAsync(mailMessage);

                // Cadastro do token no banco

                await _usuarioRepository.InserirTokenUsuario(request.Email, encodedToken);

                return new RetornoSimples(true, "Email de redefinição de senha enviado com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao enviar email de alteração de senha: " + ex);
            }
        }

        public string GeneratePasswordResetToken()
        {
            byte[] tokenBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(tokenBytes);
            }

            string token = Convert.ToBase64String(tokenBytes);
            return token;
        }

        public async Task<RetornoSimples> RedefinirSenha(ResetarSenhaCommand request)
        {
            var token = await _usuarioRepository.ObterTokenPorEmail(request.Email);

            if (request.Token != token.TokenTemp)
            {
                return new RetornoSimples(false, "Token inválido");
            }

            var tempoToken = DateTime.Now - token.DataToken;

            if(tempoToken.TotalMinutes > 10)
            {
                return new RetornoSimples(false, "Tempo limite atingido, solicite novamente a redefinição de senha");
            }

            await _usuarioRepository.AtualizarSenhaNova(request.NovaSenha, request.Email);
            return new RetornoSimples(true, "Senha atualizada com sucesso");
        }

        //public async Task<RetornoSimples> AtualizarUsuario(AtualizarUsuarioCommand request)
        //{
        //    try
        //    {
        //        await _usuarioRepository.AtualizarUsuario(request.IdUsuario, request.Nome, request.Sobrenome, request.CPF, request.DataNascimento)
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Falha ao Atualizar o usuário: " + ex);
        //    }
        //}
    }
}
