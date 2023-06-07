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
        public const string ObterUsuarioPorId = @"SELECT 
													u.ID,
													u.nome,
													u.sobrenome,
													u.senha,
													u.cpf,
													u.EstadoCivil,
													u.DataNascimento,
													u.checkProprietario,
													u.idEnderecoUsuario,
													u.idContato,
													u.idCaracteristicaUsuario,
													cau.genero,
													cau.sexo
												FROM USUARIO u
												INNER JOIN CARACTERISTICA_USUARIO cau 
												ON (cau.id = u.IdCaracteristicaUsuario) WHERE U.ID = @IdUsuario";
        #endregion

        public const string ObterUsuario = @"SELECT * FROM USUARIO U
												INNER JOIN CARACTERISTICA_USUARIO cau ON (cau.ID = U.IdCaracteristicaUsuario)";

		public const string ObterUsuarioPorEmail = @"SELECT u.Nome
                                                    FROM Usuario u WITH (NOLOCK)
                                                    INNER JOIN contato c ON (u.IdContato = c.ID)
													WHERE c.Email = @Email";

		public const string ObterTokenPorEmail = @"SELECT c.Email, u.TokenTemp, u.DataToken
                                                    FROM Usuario u WITH (NOLOCK)
                                                    INNER JOIN contato c ON (u.IdContato = c.ID)
													WHERE c.Email = @Email";

		public const string ObterUsuarioContato = @"SELECT u.ID,Nome, Sobrenome, Senha, Email
                                                    FROM Usuario u WITH (NOLOCK)
                                                    INNER JOIN contato c ON (u.IdContato = c.ID)";

        public const string ObterUsuarioContatoPorId = @"SELECT u.ID,Nome, Sobrenome, Senha, Email
                                                            FROM Usuario u WITH (NOLOCK)
                                                            INNER JOIN contato c ON (u.IdContato = c.ID)
                                                            WHERE u.ID = @IdUsuario";

        public const string InserirUsuario = @"INSERT INTO usuario(Nome,Sobrenome,Senha,CPF,EstadoCivil, DataNascimento,CheckProprietario, CheckTermos, IdEnderecoUsuario,IdContato,IdCaracteristicaUsuario)
															VALUES(@Nome, @Sobrenome, @Senha, @Cpf, @EstadoCivil, @DataNascimento,@CheckProprietario,@CheckTermos, @IdEnderecoUsuario,@IdContato,@IdCaracteristicaUsuario)";

        public const string InserirEnderecoUsuario = @"INSERT INTO endereco_usuario(CEP,Estado,Cidade,Bairro,Logradouro,Numero,Complemento)
                                                        VALUES(@Cep,@Estado, @Cidade, @Bairro, @Logradouro, @Numero, @Complemento)";

        public const string InserirContatoUsuario = @"INSERT INTO contato(Email,Telefone,Celular)
                                                        VALUES(@Email, @Telefone, @Celular)";

        public const string InserirCaracteristicaUsuario = @"INSERT INTO caracteristica_usuario(Religiao,Genero,Sexo,OrientacaoSexual,AreaInteresse)
                                                                 VALUES(@Religiao, @Genero, @Sexo,@OrientacaoSexual,@AreaInteresse)";
        
        public const string ObterUltimoRegistroInseridoUsuario = @"SELECT TOP 1 * FROM endereco_usuario WITH (NOLOCK) ORDER BY ID DESC;";

        public const string ObterUltimoRegistroInseridoContatoUsuario = @"SELECT TOP 1 * FROM contato WITH (NOLOCK) ORDER BY ID DESC;";

        public const string ObterUltimoRegistroInseridoCaracteristicaUsuario = @"SELECT TOP 1 * FROM caracteristica_usuario WITH (NOLOCK) ORDER BY ID DESC;";

		public const string ExcluirUsuarioPorId = @"DELETE FROM Usuario WHERE ID = @IdUsuario";

		public const string InserirCaracteristicaImovel = @"INSERT INTO caracteristica_imovel(TipoImovel,TipoQuarto,TipoSexo)
                                                                VALUES(@TipoImovel, @TipoQuarto, @TipoSexo)";

        public const string InserirEnderecoImovel = @"INSERT INTO endereco_imovel(CEP,Cidade,Bairro, Logradouro, Numero,Complemento, Estado)
                                                                VALUES(@Cep, @Cidade, @Bairro, @Logradouro, @Numero, @Complemento, @Estado)";

        public const string InserirRegraImovel = @"INSERT INTO regra_imovel(Fumante,Animal,Alcool, Visitas, Crianca,Drogas)
                                                        VALUES(@Fumante, @Animal, @Alcool, @Visitas, @Crianca, @Drogas)";

        public const string InserirImovel = @"INSERT INTO imovel(Midia,CapacidadePessoas,Valor, Descricao, PossuiGaragem,PossuiAcessibilidade,IdRegraImovel,IdCaracteristicaImovel, IdEnderecoImovel,IdUsuario, PossuiAcademia, PossuiPiscina, PossuiMobilia, PossuiAreaLazer,QtdBanheiros,QtdQuartos, NomeImovel, Verificado, UniversidadeProxima)
                                                         VALUES(@Midia, @CapacidadePessoas, @Valor, @Descricao, @PossuiGaragem, @PossuiAcessibilidade,@RegraImovel, @CaracteristicaImovel, @EnderecoImovel, @IdUsuarioProprietario, @PossuiAcademia,@PossuiPiscina, @PossuiMobilia, @PossuiAreaLazer,@QuantidadeBanheiros, @QuantidadeQuartos, @NomeImovel, @Verificado, @UniversidadeProxima)";

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
												i.Verificado,
												I.UniversidadeProxima,
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
													i.Verificado,
													i.UniversidadeProxima,
													u.ID IdUsuario,
													u.Nome,
													u.Sobrenome,
													ei.Id IdEnderecoImovel,
													ei.CEP,
													ei.Cidade,
													ei.Bairro,
													ei.Logradouro,
													ei.Numero,
													ei.Complemento,
													ei.Estado,
													ri.Id IdRegraImovel,
													ri.Fumante,
													ri.Animal,
													ri.Alcool,
													ri.Visitas,
													ri.Crianca,
													ri.Drogas,
													ci.Id IdCaracteristicaImovel,
													ci.TipoImovel,
													ci.TipoSexo,
													ci.TipoQuarto
												FROM IMOVEL i WITH (NOLOCK)
												INNER JOIN USUARIO u ON (i.IdUsuario = u.ID)
												INNER JOIN ENDERECO_IMOVEL ei ON(i.IdEnderecoImovel = ei.ID)
												INNER JOIN REGRA_IMOVEL ri ON(i.IdRegraImovel = ri.ID)
												INNER JOIN CARACTERISTICA_IMOVEL ci ON (i.IdCaracteristicaImovel = ci.ID)
												WHERE i.ID = @IdImovel";

		public const string ObterImovelPorUsuarioId = @"SELECT 
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
															i.Verificado,
															i.UniversidadeProxima,
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
														WHERE u.ID = @IdUsuario";

		public const string VerificarExisteEmailSenha = @"SELECT TOP 1 u.ID,Nome, Sobrenome, Senha, Email
                                                            FROM Usuario u WITH (NOLOCK)
                                                            INNER JOIN contato c ON (u.IdContato = c.ID)
                                                        WHERE c.Email = @Email
													      AND Senha = @Senha";

		public const string VerificarEmailCpf = @"SELECT TOP 1 u.ID,Nome, Sobrenome, Senha, Email
                                                            FROM Usuario u WITH (NOLOCK)
                                                            INNER JOIN contato c ON (u.IdContato = c.ID)
                                                        WHERE c.Email = @Email
													      AND Cpf = @Cpf";

		public const string VerificarEmail = @"SELECT TOP 1 u.ID,Nome, Sobrenome, Senha, Email
                                                            FROM Usuario u WITH (NOLOCK)
                                                            INNER JOIN contato c ON (u.IdContato = c.ID)
                                                        WHERE c.Email = @Email;";



		public const string DeletarImovelPorId = @"DELETE FROM IMOVEL WHERE ID = @IdImovel";

        public const string InserirTokenUsuario = @"UPDATE Usuario
													SET TokenTemp = @Token,
														DataToken = @DataToken
													WHERE ID = (SELECT TOP 1 u.ID
																FROM Usuario u WITH (NOLOCK)
																INNER JOIN contato c ON (u.IdContato = c.ID)
																WHERE c.Email = @Email);";

		public const string AtualizarSenha = @"UPDATE Usuario
												SET Senha = @NovaSenha
												WHERE ID = (SELECT TOP 1 u.ID
															FROM Usuario u WITH (NOLOCK)
															INNER JOIN contato c ON (u.IdContato = c.ID)
															WHERE c.Email = @Email);";

		public const string AtualizarImovel = @"UPDATE IMOVEL SET
													Midia = @Midia,
													NomeImovel = @NomeImovel,
													CapacidadePessoas = @CapacidadePessoas,
													Valor = @Valor,
													Descricao = @Descricao,
													PossuiGaragem = @PossuiGaragem,
													PossuiAcessibilidade = @PossuiAcessibilidade,
													PossuiPiscina = @PossuiPiscina,
													PossuiMobilia = @PossuiMobilia,
													QtdBanheiros = @QuantidadeBanheiros,
													QtdQuartos = @QuantidadeQuartos,
													UniversidadeProxima = @UniversidadeProxima
												WHERE ID = @IdImovel;
												
												UPDATE REGRA_IMOVEL SET
													Fumante = @Fumante,
													Animal = @Animal,
													Alcool = @Alcool,
													Visitas = @Visitas,
													Crianca = @Crianca,
													Drogas = @Drogas
												WHERE ID = @IdRegraImovel;
												
												UPDATE CARACTERISTICA_IMOVEL SET
													TipoImovel = @TipoImovel,
													TipoQuarto = @TipoQuarto,
													TipoSexo = @TipoSexo
												WHERE ID = @IdCaracteristicaImovel;
												
												UPDATE ENDERECO_IMOVEL SET
													CEP = @CEP,
													Cidade = @Cidade,
													Bairro = @Bairro,
													Logradouro = @Logradouro,
													Numero = @Numero,
													Complemento = @Complemento,
													Estado = @Estado
												WHERE ID = @IdEnderecoImovel";

	}
}
