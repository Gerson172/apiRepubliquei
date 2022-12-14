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
        public const string ObterUsuarioPorId = @"SELECT * FROM Usuario WITH (NOLOCK) WHERE ID = @IdUsuario";
        #endregion

        public const string ObterUsuario = @"SELECT * FROM usuario WITH (NOLOCK)";

        public const string ObterUsuarioContato = @"SELECT u.ID,Nome, Sobrenome, Senha, Email
                                                    FROM Usuario u WITH (NOLOCK)
                                                    INNER JOIN contato c ON (u.IdContato = c.ID)";

        public const string ObterUsuarioContatoPorId = @"SELECT u.ID,Nome, Sobrenome, Senha, Email
                                                            FROM Usuario u WITH (NOLOCK)
                                                            INNER JOIN contato c ON (u.IdContato = c.ID)
                                                            WHERE u.ID = @IdUsuario";

        public const string InserirUsuario = @"INSERT INTO usuario(Nome,Sobrenome,Senha,CPF,EstadoCivil, DataNascimento,CheckProprietario, IdEnderecoUsuario,IdContato,IdCaracteristicaUsuario)
                                                                 VALUES(@Nome, @Sobrenome, @Senha, @Cpf, @EstadoCivil, @DataNascimento,@CheckProprietario,@IdEnderecoUsuario,@IdContato,@IdCaracteristicaUsuario)";

        public const string InserirEnderecoUsuario = @"INSERT INTO endereco_usuario(CEP,Estado,Cidade,Bairro,Logradouro,Numero,Complemento)
                                                        VALUES(@Cep,@Estado, @Cidade, @Bairro, @Logradouro, @Numero, @Complemento)";

        public const string InserirContatoUsuario = @"INSERT INTO contato(Email,Telefone,Celular)
                                                        VALUES(@Email, @Telefone, @Celular)";

        public const string InserirCaracteristicaUsuario = @"INSERT INTO caracteristica_usuario(Religiao,Genero,Sexo,OrientacaoSexual,AreaInteresse)
                                                                 VALUES(@Religiao, @Genero, @Sexo,@OrientacaoSexual,@AreaInteresse)";
        
        public const string ObterUltimoRegistroInseridoUsuario = @"SELECT TOP 1 * FROM endereco_usuario WITH (NOLOCK) ORDER BY ID DESC;";

        public const string ObterUltimoRegistroInseridoContatoUsuario = @"SELECT TOP 1 * FROM contato WITH (NOLOCK) ORDER BY ID DESC;";

        public const string ObterUltimoRegistroInseridoCaracteristicaUsuario = @"SELECT TOP 1 * FROM caracteristica_usuario WITH (NOLOCK) ORDER BY ID DESC;";


        public const string InserirCaracteristicaImovel = @"INSERT INTO caracteristica_imovel(TipoImovel,TipoQuarto,TipoSexo)
                                                                VALUES(@TipoImovel, @TipoQuarto, @TipoSexo)";

        public const string InserirEnderecoImovel = @"INSERT INTO endereco_imovel(CEP,Cidade,Bairro, Logradouro, Numero,Complemento, Estado)
                                                                VALUES(@Cep, @Cidade, @Bairro, @Logradouro, @Numero, @Complemento, @Estado)";

        public const string InserirRegraImovel = @"INSERT INTO regra_imovel(Fumante,Animal,Alcool, Visitas, Crianca,Drogas)
                                                        VALUES(@Fumante, @Animal, @Alcool, @Visitas, @Crianca, @Drogas)";

        public const string InserirImovel = @"INSERT INTO imovel(Midia,CapacidadePessoas,Valor, Descricao, PossuiGaragem,PossuiAcessibilidade,IdRegraImovel,IdCaracteristicaImovel, IdEnderecoImovel,IdUsuario, PossuiAcademia, PossuiPiscina, PossuiMobilia, PossuiAreaLazer,QtdBanheiros,QtdQuartos, NomeImovel)
                                                         VALUES(@Midia, @CapacidadePessoas, @Valor, @Descricao, @PossuiGaragem, @PossuiAcessibilidade,@RegraImovel, @CaracteristicaImovel, @EnderecoImovel, @IdUsuarioProprietario, @PossuiAcademia,@PossuiPiscina, @PossuiMobilia, @PossuiAreaLazer,@QuantidadeBanheiros, @QuantidadeQuartos, @NomeImovel)";

        public const string ObterUltimoRegistroInseridoCaracteristicaImovel = @"SELECT TOP 1 * FROM caracteristica_imovel ORDER BY ID DESC;";
        public const string ObterUltimoRegistroInseridoEnderecoImovel = @"SELECT TOP 1 * FROM endereco_imovel  WITH (NOLOCK) ORDER BY ID DESC;";
        public const string ObterUltimoRegistroInseridoRegraImovel = @"SELECT TOP 1 * FROM regra_imovel WITH (NOLOCK) ORDER BY ID DESC;";

        public const string ObterImovel = @"SELECT 
											i.ID IdImovel,
											i.Midia, 
											i.NomeImovel,
											i.CapacidadePessoas,
											i.Valor,
											i.Descricao,
											i.PossuiGaragem,
											i.PossuiAcessibilidade,
											i.PossuiAcademia,
											i.PossuiPiscina,
											i.PossuiMobilia,
											i.PossuiAreaLazer,
											i.QtdBanheiros,
											i.QtdQuartos,
											u.ID IdUsuario,
											u.Nome,
											u.Sobrenome,
											ei.CEP,
											ei.Cidade,
											ei.Bairro,
											ei.Logradouro,
											ei.Numero,
											ei.Complemento,
											ei.Estado,
											ri.Fumante,
											ri.Animal,
											ri.Alcool,
											ri.Visitas,
											ri.Crianca,
											ri.Drogas,
											ci.TipoImovel,
											ci.TipoSexo,
											ci.TipoQuarto
										FROM IMOVEL i WITH (NOLOCK)
										INNER JOIN USUARIO u ON (i.IdUsuario = u.ID)
										INNER JOIN ENDERECO_IMOVEL ei ON(i.IdEnderecoImovel = ei.ID)
										INNER JOIN REGRA_IMOVEL ri ON(i.IdRegraImovel = ri.ID)
										INNER JOIN CARACTERISTICA_IMOVEL ci ON (i.IdCaracteristicaImovel = ci.ID)";

        public const string ObterImovelPorId = @"SELECT 
													i.ID IdImovel,
													i.Midia, 
													i.NomeImovel,
													i.CapacidadePessoas,
													i.Valor,
													i.Descricao,
													i.PossuiGaragem,
													i.PossuiAcessibilidade,
													i.PossuiAcademia,
													i.PossuiPiscina,
													i.PossuiMobilia,
													i.PossuiAreaLazer,
													i.QtdBanheiros,
													i.QtdQuartos,
													u.ID IdUsuario,
													u.Nome,
													u.Sobrenome,
													ei.CEP,
													ei.Cidade,
													ei.Bairro,
													ei.Logradouro,
													ei.Numero,
													ei.Complemento,
													ei.Estado,
													ri.Fumante,
													ri.Animal,
													ri.Alcool,
													ri.Visitas,
													ri.Crianca,
													ri.Drogas,
													ci.TipoImovel,
													ci.TipoSexo,
													ci.TipoQuarto
												FROM IMOVEL i WITH (NOLOCK)
												INNER JOIN USUARIO u ON (i.IdUsuario = u.ID)
												INNER JOIN ENDERECO_IMOVEL ei ON(i.IdEnderecoImovel = ei.ID)
												INNER JOIN REGRA_IMOVEL ri ON(i.IdRegraImovel = ri.ID)
												INNER JOIN CARACTERISTICA_IMOVEL ci ON (i.IdCaracteristicaImovel = ci.ID)
												WHERE i.ID = @IdImovel";

        public const string VerificarExisteEmailSenha = @"SELECT TOP 1 u.ID,Nome, Sobrenome, Senha, Email
                                                            FROM Usuario u WITH (NOLOCK)
                                                            INNER JOIN contato c ON (u.IdContato = c.ID)
                                                        WHERE c.Email = @Email
                                                           OR u.CPF = @Cpf";

		public const string DeletarImovelPorId = @"DELETE FROM IMOVEL WHERE ID = @IdImovel";

	}
}
