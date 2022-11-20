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

        public const string ObterUsuario = @"SELECT * FROM Usuario";


        public const string InserirUsuario = @"INSERT INTO usuario(Nome,Sobrenome,Senha,CPF,EstadoCivil, DataNascimento, IdEnderecoUsuario,IdContato,IdCaracteristicaUsuario)
                                                                 VALUES(@Nome, @Sobrenome, @Senha, @Cpf, @EstadoCivil, @DataNascimento,@CheckProprietario,@IdEnderecoUsuario,@IdContato,@IdCaracteristicaUsuario)";

        public const string InserirEnderecoUsuario = @"INSERT INTO endereco_usuario(CEP,Estado,Cidade,Bairro,Logradouro,Numero,Complemento)
                                                        VALUES(@Cep,@Estado, @Cidade, @Bairro, @Logradouro, @Numero, @Complemento)";

        public const string InserirContatoUsuario = @"INSERT INTO contato(Email,Telefone,Celular)
                                                        VALUES(@Email, @Telefone, @Celular)";

        public const string InserirCaracteristicaUsuario = @"INSERT INTO caracteristica_usuario(Religiao,Genero,Sexo,OrientacaoSexual,AreaInteresse)
                                                                 VALUES(@Religiao, @Genero, @Sexo,@OrientacaoSexual,@AreaInteresse)";
        
        public const string ObterUltimoRegistroInseridoUsuario = @"SELECT TOP 1 * FROM endereco_usuario ORDER BY ID DESC;";

        public const string ObterUltimoRegistroInseridoContatoUsuario = @"SELECT TOP 1 * FROM contato ORDER BY ID DESC;";

        public const string ObterUltimoRegistroInseridoCaracteristicaUsuario = @"SELECT TOP 1 * FROM caracteristica_usuario ORDER BY ID DESC;";


        public const string InserirCaracteristicaImovel = @"INSERT INTO caracteristica_imovel(TipoImovel,TipoQuarto,TipoSexo)
                                                                VALUES(@TipoImovel, @TipoQuarto, @TipoSexo)";

        public const string InserirEnderecoImovel = @"INSERT INTO endereco_imovel(CEP,Cidade,Bairro, Logradouro, Numero,Complemento)
                                                                VALUES(@Cep, @Cidade, @Bairro, @Logradouro, @Numero, @Complemento)";

        public const string InserirRegraImovel = @"INSERT INTO regra_imovel(Fumante,Animal,Alcool, Visitas, Crianca,Drogas)
                                                        VALUES(@Fumante, @Animal, @Alcool, @Visitas, @Crianca, @Drogas)";

        public const string InserirImovel = @"INSERT INTO imovel(Midia,CapacidadePessoas,Valor, Descricao, PossuiGaragem,PossuiAcessibilidade,IdRegraImovel,IdCaracteristicaImovel, IdEnderecoImovel,IdUsuario, PossuiAcademia, PossuiPiscina, PossuiMobilia, PossuiAreaLazer,QtdBanheiros,QtdQuartos)
                                                         VALUES(@Midia, @CapacidadePessoas, @Valor, @Descricao, @PossuiGaragem, @PossuiAcessibilidade,@RegraImovel, @CaracteristicaImovel, @EnderecoImovel, @IdUsuarioProprietario, @PossuiAcademia,@PossuiPiscina, @PossuiMobilia, @PossuiAreaLazer,@QuantidadeBanheiros, @QuantidadeQuartos)";

        public const string ObterUltimoRegistroInseridoCaracteristicaImovel = @"SELECT TOP 1 * FROM caracteristica_imovel ORDER BY ID DESC;";
        public const string ObterUltimoRegistroInseridoEnderecoImovel = @"SELECT TOP 1 * FROM endereco_imovel ORDER BY ID DESC;";
        public const string ObterUltimoRegistroInseridoRegraImovel = @"SELECT TOP 1 * FROM regra_imovel ORDER BY ID DESC;";

        public const string ObterImovel = @"SELECT * FROM imovel";

        public const string ObterImovelPorId = @"SELECT * FROM imovel WHERE ID = @IdImovel";
    }
}
