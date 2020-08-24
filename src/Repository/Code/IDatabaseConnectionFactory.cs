using System.Data;
using System.Threading.Tasks;

namespace Repository.Code
{
    public interface IDatabaseConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsync();
    }
}