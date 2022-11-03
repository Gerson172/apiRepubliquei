using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Infra.Data.Queries
{
    internal static class Queries
    {
        #region ObterUsuarioPorId
        public const string ObterUsuarioPorId = @"SELECT * FROM Usuario WHERE ID = @IdUsuario";
        #endregion

        public const string InserirUsuario = @"INSERT INTO usuario(Nome,Sobrenome,Senha,CPF,EstadoCivil, DataNascimento, IdEnderecoUsuario,IdContato,IdCaracteristicaUsuario)
                                                                 VALUES(@Nome, @Sobrenome, @Senha, @Cpf, @EstadoCivil, @DataNascimento,@@IDENTITY,@@IDENTITY,@@IDENTITY)";
        public const string InserirEnderecoUsuario = @"INSERT INTO endereco_usuario(CEP,Cidade,Bairro,Logradouro,Numero,Complemento)
                                                        VALUES(@Cep, @Cidade, @Bairro, @Logradouro, @Numero, @Complemento)";

        public const string InserirContatoUsuario = @"INSERT INTO contato(Email,Telefone,Celular)
                                                        VALUES(@Email, @Telefone, @Celular)";

        public const string InserirCaracteristicaUsuario = @"INSERT INTO caracteristica_usuario(Religiao,Genero,Sexo,OrientacaoSexual,AreaInteresse)
                                                                 VALUES(@Religiao, @Genero, @Sexo,@OrientacaoSexual,@AreaInteresse)";
        
        public const string ObterUltimoRegistro = @"SELECT TOP 1 FROM ";
    }
}
