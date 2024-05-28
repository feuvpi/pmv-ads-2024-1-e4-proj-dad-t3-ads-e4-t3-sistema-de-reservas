using api_reservas.Models;
using api_reservas.Repositories;
using MongoDB.Driver;

namespace api_reservas.Services
{
    public class CondominioService : BaseService<Condominio>
    {
        private readonly IMongoCollection<Condominio> _collection;
        public CondominioService(MyMongoRepository repository) : base(repository)
        {

        }

        public async Task<Condominio> FindByEmail(string email)
        {
            return await _collection.Find(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<Condominio> FindByCnpj(string cnpj)
        {
            return await _collection.Find(x => x.CNPJ == cnpj).FirstOrDefaultAsync();
        }

        public async Task<Condominio> CreateCondominoAsync(Condominio condominio)
        {
            await _collection.InsertOneAsync(condominio);
            var condoCreated = await FindByCnpj(condominio.CNPJ);
            return condoCreated;
        }


    }
}
