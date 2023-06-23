using appRepubliquei.Domain.Commands.ImovelCommand;
using appRepubliquei.Domain.Contracts.Repository;
using appRepubliquei.Domain.Contracts.Services;
using appRepubliquei.Domain.Entidades;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Services
{
    public class ImovelService : IImovelService
    {
        private readonly IImovelRepository _imovelRepository;
        private readonly IConfiguration _configuration;

        public ImovelService(IImovelRepository imovelRepository, IConfiguration configuration)
        {
            _imovelRepository = imovelRepository;
            _configuration = configuration;

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

                await _imovelRepository.InserirImovel(request.CapacidadePessoas, request.Valor, request.Descricao,
                    request.PossuiAcessibilidade, request.PossuiGaragem, request.PossuiAcademia, request.PossuiMobilia, 
                    request.PossuiAreaLazer, request.PossuiPiscina, request.QuantidadeBanheiros,
                    request.QuantidadeQuartos, caracteristicaImovel.ID, enderecoImovel.ID, regraImovel.ID, request.IdUsuario, request.NomeImovel,
                    request.Verificado, request.UniversidadeProxima, request.Midia1, request.Midia2, request.Midia3);


                var container = new BlobContainerClient(_configuration["Blob:ConnectionString"], _configuration["Blob:ContainerName"]);
                var arquivos = new List<string> { request.Midia1, request.Midia2, request.Midia3 };
                foreach (var arquivo in arquivos)
                {
                    byte[] arquivoBytes = Convert.FromBase64String(arquivo);
                    using (var stream = new MemoryStream(arquivoBytes))
                    {
                        stream.Position = 0;
                        await container.UploadBlobAsync(arquivo, stream);
                    }
                }
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
                foreach (var items in dadosImovel)
                {
                    items.Midia1 = ObterUrlImagem(items.Midia1);
                    items.Midia2 = ObterUrlImagem(items.Midia2);
                    items.Midia3 = ObterUrlImagem(items.Midia3);
                }
                return dadosImovel;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Obter Imóvel: " + ex);
            }
        }
        private string ObterUrlImagem(string nomeImagem)
        {
            try
            {
                var container = new BlobContainerClient(_configuration["Blob:ConnectionString"], _configuration["Blob:ContainerName"]);
                var blobClient = container.GetBlobClient(nomeImagem);
                return blobClient.Uri.AbsoluteUri;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao Obter Url da Imagem: " + ex);
            }   
        }
    }
}
