﻿using appRepubliquei.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Contracts.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterUsuarioPorId(int id);
        Task InserirEnderecoUsuario(int cep, string cidade, string bairro, string logradouro, string numero, string complemento);
        Task InserirContatoUsuario(string email, string celular, string telefone);
        Task InserirCaracteristicaUsuario(string religiao, string genero, string sexo, string orientacaoSexual, string areaInteresse);
        Task InserirUsuario(string nome, string sobrenome, string senha, string cpf, string estadoCivil, DateTime dataNascimento, int fkEnderecoUsuario,int fkContato,int fkCaracteristicaUsuario);
        Task<EnderecoUsuario> ObterUltimoRegistroInseridoUsuario();
        Task<Contato> ObterUltimoRegistroInseridoContatoUsuario();
        Task<CaracteristicaUsuario> ObterUltimoRegistroInseridoCaracteristicaUsuario();

    }
}
