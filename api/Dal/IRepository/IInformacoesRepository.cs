using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dto;
using api.Models;

namespace api.Dal.IRepository
{
    public interface IInformacoesRepository
    {
        Task<Dto_Informacoes> BuscarPorId(int id);
        Task<List<Dto_Informacoes>> BuscarTodasInformacoes();
        Task<Dto_Informacoes> Actualizar(Dto_Informacoes dto_informacoes, int id);
        Task<Dto_Informacoes> Adicionar(Dto_Informacoes dto_informacoes);
        Task<bool> Apagar(int id);
    }
}
