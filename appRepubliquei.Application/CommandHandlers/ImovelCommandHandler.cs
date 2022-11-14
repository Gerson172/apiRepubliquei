using appRepubliquei.Domain;
using appRepubliquei.Domain.Commands;
using appRepubliquei.Domain.Contracts.Services;
using appRepubliquei.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace appRepubliquei.Application.CommandHandlers
{
    public class ImovelCommandHandler : IRequestHandler<InserirImovelCommand, RetornoSimples>,
                                        IRequestHandler<ObterImovelCommand, Imovel>,
                                        IRequestHandler<ObterImovelPorIdCommand, Imovel>
    {
        private readonly IImovelService _imovelService;
        public ImovelCommandHandler(IImovelService imovelService)
        {
            _imovelService = imovelService;
        }
        public async Task<RetornoSimples> Handle(InserirImovelCommand request, CancellationToken cancellationToken)
        {
            return await _imovelService.CadastrarImovel(request);
        }

        public async Task<Imovel> Handle(ObterImovelCommand request, CancellationToken cancellationToken)
        {
            return await _imovelService.ObterImovel();
        }

        public async Task<Imovel> Handle(ObterImovelPorIdCommand request, CancellationToken cancellationToken)
        {
            return await _imovelService.ObterImovelPorId(request.IdImovel);
        }
    }
}
