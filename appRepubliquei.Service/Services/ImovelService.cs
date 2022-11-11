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
    public class ImovelService : IImovelService
    {
        private readonly IImovelRepository _imovelRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public ImovelService(IImovelRepository imovelRepository, IUsuarioRepository usuarioRepository)
        {
            _imovelRepository = imovelRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<RetornoSimples> CadastrarImovel(InserirImovelCommand request)
        {
            try
            {
                await _imovelRepository.InserirCaracteristicaImovel(request.CaracteristicaImovel.TipoImovel,
                                                                request.CaracteristicaImovel.TipoQuarto,
                                                                request.CaracteristicaImovel.TipoSexo);

                await _imovelRepository.InserirEnderecoImovel(request.EnderecoImovel.CEP, request.EnderecoImovel.Cidade, 
                                                                request.EnderecoImovel.Bairro,request.EnderecoImovel.Logradouro,
                                                                request.EnderecoImovel.Numero, request.EnderecoImovel.Complemento);

                await _imovelRepository.InserirRegraImovel(request.RegraImovel.Fumante, request.RegraImovel.Animal,
                    request.RegraImovel.Alcool, request.RegraImovel.Visitas, request.RegraImovel.Crianca,
                    request.RegraImovel.Drogas);

                var caracteristicaImovel = await _imovelRepository.ObterUltimoRegistroCaracteristicaImovel();
                var enderecoImovel =  await _imovelRepository.ObterUltimoRegistroEnderecoImovel();
                var regraImovel = await _imovelRepository.ObterUltimoRegistroRegraImovel();

                await _imovelRepository.InserirImovel(request.Midia, request.CapacidadePessoas, request.Valor, request.Descricao,
                    request.PossuiAcessibilidade, request.PossuiGaragem, request.PossuiAcademia, request.PossuiMobilia, 
                    request.PossuiAreaLazer, request.PossuiPiscina, request.QuantidadeBanheiros, request.QuantidadeComodo, 
                    request.QuantidadeQuartos, request.IdUsuario, caracteristicaImovel.ID, enderecoImovel.ID, regraImovel.ID);

                return new RetornoSimples(true, "Imovel Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao cadastrar Imóvel: " + ex);
            }
        }
    }
}
