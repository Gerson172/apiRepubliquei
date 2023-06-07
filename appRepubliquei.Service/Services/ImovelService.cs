using appRepubliquei.Domain.Commands.ImovelCommand;
using appRepubliquei.Domain.Contracts.Repository;
using appRepubliquei.Domain.Contracts.Services;
using appRepubliquei.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Services
{
    public class ImovelService : IImovelService
    {
        private readonly IImovelRepository _imovelRepository;

        public ImovelService(IImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
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
                                                                request.EnderecoImovel.Numero, request.EnderecoImovel.Complemento, request.EnderecoImovel.Estado);

                await _imovelRepository.InserirRegraImovel(request.RegraImovel.Fumante, request.RegraImovel.Animal,
                    request.RegraImovel.Alcool, request.RegraImovel.Visitas, request.RegraImovel.Crianca,
                    request.RegraImovel.Drogas);

                var caracteristicaImovel = await _imovelRepository.ObterUltimoRegistroCaracteristicaImovel();
                var enderecoImovel =  await _imovelRepository.ObterUltimoRegistroEnderecoImovel();
                var regraImovel = await _imovelRepository.ObterUltimoRegistroRegraImovel();

                await _imovelRepository.InserirImovel(request.Midia, request.CapacidadePessoas, request.Valor, request.Descricao,
                    request.PossuiAcessibilidade, request.PossuiGaragem, request.PossuiAcademia, request.PossuiMobilia, 
                    request.PossuiAreaLazer, request.PossuiPiscina, request.QuantidadeBanheiros,
                    request.QuantidadeQuartos, caracteristicaImovel.ID, enderecoImovel.ID, regraImovel.ID, request.IdUsuario, request.NomeImovel,
                    request.Verificado, request.UniversidadeProxima);

                return new RetornoSimples(true, "Imovel Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao cadastrar Imóvel: " + ex);
            }
        }

        public async Task<RetornoSimples> DeletarImovelPorId(int idImovel)
        {
            try
            {
                await _imovelRepository.DeletarImovelPorId(idImovel);

                return new RetornoSimples(true, "Imovel deletado com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao deletar Imóvel: " + ex);
            }
           
        }

        public async Task<IEnumerable<vwImovel>> ObterImovel()
        {
            try
            {
                var dadosImovel = await _imovelRepository.ObterImovel();
                if (dadosImovel == null)
                {
                    throw new Exception("Imovel não encontrado");
                }
                return dadosImovel;
            }
            catch(Exception ex)
            {
                throw new Exception("Falha ao Obter Imóvel: " + ex);
            }
        }

        public async Task<vwImovel> ObterImovelPorId(int idImovel)
        {
            try
            {
                var dadosImovel = await _imovelRepository.ObterImovelPorId(idImovel);
                if (dadosImovel == null)
                {
                    throw new Exception("Imovel não encontrado");
                }
                return dadosImovel;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Obter Imóvel: " + ex);
            }
        }
        public async Task<RetornoSimples> AtualizarImovel(AtualizarImovelCommand request)
        {
            try
            {
                var imovel = await _imovelRepository.ObterImovelPorId(request.ID);
                if (imovel == null)
                {
                    throw new Exception("Imovel não encontrado");
                }
                await _imovelRepository.AtualizarImovel(request, imovel.IdEnderecoImovel, imovel.IdCaracteristicaImovel, imovel.IdImovel, imovel.IdRegraImovel);

                return new RetornoSimples(true, "Imovel atualizado com sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao atualizar imovel: " + ex);
            }
        }

        public async Task<IEnumerable<vwImovel>> ObterImovelPorUsuarioId(int? idUsuario)
        {
            try
            {
                var dadosImovel = await _imovelRepository.ObterImovelPorUsuarioId(idUsuario);
                if (dadosImovel == null)
                {
                    throw new Exception("Imovel não encontrado");
                }
                return dadosImovel;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Obter Imóvel: " + ex);
            }
        }
    }
}
