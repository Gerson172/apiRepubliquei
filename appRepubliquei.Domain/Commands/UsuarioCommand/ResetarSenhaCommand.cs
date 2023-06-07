﻿using appRepubliquei.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Commands.UsuarioCommand
{
    public class ResetarSenhaCommand : IRequest<RetornoSimples>
    {
        public string Email { get; set; }
        public string NovaSenha { get; set; }
        public string Token { get; set; }
    }
}