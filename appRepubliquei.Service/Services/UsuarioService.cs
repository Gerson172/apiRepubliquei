using appRepubliquei.Domain.Commands;
using appRepubliquei.Domain.Contracts.Repository;
using appRepubliquei.Domain.Contracts.Services;
using appRepubliquei.Domain.Entidades;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> ObterUsuarioPorId(int idUsuario)
        {
            return await _usuarioRepository.ObterUsuarioPorId(idUsuario);
        }
        public async Task<RetornoSimples> CadastrarUsuario(CadastrarUsuarioCommand request)
        {
            try
            {
                #region Criptografia em Hash da senha
                byte[] salt = new byte[128 / 8];
                using (var rngCsp = new RNGCryptoServiceProvider())
                {
                    rngCsp.GetNonZeroBytes(salt);
                }
                var senha = request.Senha;
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: senha,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
                request.Senha = hashed;
                #endregion

                await _usuarioRepository.InserirEnderecoUsuario(request.EnderecoUsuario.CEP, request.EnderecoUsuario.Estado, request.EnderecoUsuario.Cidade, request.EnderecoUsuario.Bairro,
                    request.EnderecoUsuario.Logradouro, request.EnderecoUsuario.Numero, request.EnderecoUsuario.Complemento);

                await _usuarioRepository.InserirContatoUsuario(request.Contato.Email, request.Contato.Celular, request.Contato.Telefone);

                await _usuarioRepository.InserirCaracteristicaUsuario(request.CaracteristicaUsuario.Religiao, request.CaracteristicaUsuario.Genero, 
                    request.CaracteristicaUsuario.Sexo, request.CaracteristicaUsuario.OrientacaoSexual,request.CaracteristicaUsuario.AreaInteresse);

                var ContatoUsuario = await _usuarioRepository.ObterUltimoRegistroInseridoContatoUsuario();
                var EnderecoUsuario = await _usuarioRepository.ObterUltimoRegistroInseridoUsuario();
                var CaracteristicaUsuario = await _usuarioRepository.ObterUltimoRegistroInseridoCaracteristicaUsuario();

                await _usuarioRepository.InserirUsuario(request.Nome, request.Sobrenome, request.Senha, request.CPF, request.EstadoCivil,
                    request.DataNascimento, request.CheckProprietario, EnderecoUsuario.ID, ContatoUsuario.ID, CaracteristicaUsuario.ID);

                return new RetornoSimples(true, "Usuario cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao cadastrar usuario: " + ex);
            }
            
        }

        //public async Task<RetornoSimples> AtualizarUsuario(AtualizarUsuarioCommand request)
        //{
        //    try
        //    {
        //        await _usuarioRepository.AtualizarUsuario(request.IdUsuario, request.Nome, request.Sobrenome, request.CPF, request.DataNascimento
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Falha ao Atualizar o usuário: " + ex);
        //    }
        //}
    }
}
