using api.Dal.Data;
using api.Dal.IRepository;
using api.Dto;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Dal.CRepository
{
    public class CInformacoes : IInformacoesRepository
    {
        private readonly AppDbContext _dbContext;

        public CInformacoes(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<Dto_Informacoes> BuscarPorId(int id)
        {
            return await _dbContext.informacoes
                .Where(x => x.id == id)
                .Select(x => new Dto_Informacoes
                {
                  Id = x.id,
                  Titulo = x.titulo,
                  Descricao = x.descricao,
                  Evento = x.evento,
                  Organizacao = x.organizacao,
                  Data_De_Realizacao = x.data_de_realizacao,


                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<Dto_Informacoes>> BuscarTodasInformacoes()
        {
            return await _dbContext.informacoes
                .Select(x => new Dto_Informacoes
                {
                    Id = x.id,
                    Titulo = x.titulo,
                    Descricao = x.descricao,
                    Evento = x.evento,
                    Organizacao = x.organizacao,
                    Data_De_Realizacao = x.data_de_realizacao,
                    Foto = x.foto,
                })
                .ToListAsync();
        }

        public async Task<Dto_Informacoes> Adicionar(Dto_Informacoes dto_informacoes)
        {
            var informacoes = new Informacoes
            {
                // Mapear as propriedades do DTO para a entidade
                titulo = dto_informacoes.Titulo,
                descricao = dto_informacoes.Descricao,
                dataa = dto_informacoes.Dataa,
                evento = dto_informacoes.Evento,
                organizacao = dto_informacoes.Organizacao,
                foto = dto_informacoes.Foto,
                data_de_realizacao = dto_informacoes.Data_De_Realizacao,
               
                // Adicionar outras propriedades conforme necessário
            };

            _dbContext.informacoes.Add(informacoes);
            await _dbContext.SaveChangesAsync();

            // Atualizar o DTO com o ID gerado (se necessário)
            dto_informacoes.Id = informacoes.id;

            return dto_informacoes;
        }


        public async Task<Dto_Informacoes> Actualizar(Dto_Informacoes dto_informacoes, int id)
        {
            try
            {
                var informacoesPorID = await _dbContext.informacoes.FirstOrDefaultAsync(x => x.id == id);
                if (informacoesPorID == null)
                {
                    throw new Exception($"Informações para o id {id} não foram encontradas no banco de dados.");
                }

                informacoesPorID.titulo = dto_informacoes.Titulo ?? throw new ArgumentException("Título não pode ser nulo");
                informacoesPorID.descricao = dto_informacoes.Descricao ?? throw new ArgumentException("Descrição não pode ser nula");
                // Atualizar outras propriedades conforme necessário

                _dbContext.informacoes.Update(informacoesPorID);
                await _dbContext.SaveChangesAsync();

                return new Dto_Informacoes
                {
                    Id = informacoesPorID.id,
                    Titulo = informacoesPorID.titulo,
                    Descricao = informacoesPorID.descricao
                    // Mapear outras propriedades conforme necessário
                };
            }
            catch (DbUpdateException ex)
            {
                // Captura a exceção interna e loga os detalhes
                var innerException = ex.InnerException?.Message;
                Console.WriteLine($"Erro ao salvar as alterações: {innerException}");
                throw; // Re-lança a exceção para ser tratada pelo chamador
            }
            catch (Exception ex)
            {
                // Captura outras exceções e loga os detalhes
                Console.WriteLine($"Erro: {ex.Message}");
                throw; // Re-lança a exceção para ser tratada pelo chamador
            }
        }


        public async Task<bool> Apagar(int id)
        {
            var informacoesPorID = await _dbContext.informacoes.FirstOrDefaultAsync(x => x.id == id);
            if (informacoesPorID == null)
            {
                throw new Exception($"Informações para o id {id} não foram encontradas no banco de dados.");
            }

            _dbContext.informacoes.Remove(informacoesPorID);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
