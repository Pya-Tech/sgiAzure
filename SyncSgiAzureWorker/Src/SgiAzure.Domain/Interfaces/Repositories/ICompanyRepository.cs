using SgiAzure.Domain.Interfaces.Entities;

namespace SgiAzure.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface encargada de abstraer 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICompanyRepository<T> where T : ICompany
    {

        /// <summary>
        /// Método encargado de obtener todas las compañías
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllCompanies(CancellationToken ct = default);

        /// <summary>
        /// Método encargado de obtener una compañía a partir del identificador
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<T> GetCompanyById(int companyId, CancellationToken ct = default);

        Task<T> GetCompanyByName(string companyName, CancellationToken ct = default);
    }
}