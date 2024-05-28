using api_reservas.Models;
using api_reservas.Models.BaseModels;
using api_reservas.Models.Dtos;
using api_reservas.Repositories;
using MongoDB.Driver;

namespace api_reservas.Services
{
    public class AuthService : BaseService<BaseUser>
    {
        private readonly CondominioService _condominioService;
        private readonly CondominoService _condominoService;
        public AuthService(MyMongoRepository repository) : base(repository)
        {

        }

        public async Task Login(LoginDto loginDTO)
        {
            // -- retrieve salt
            var condominio = await _condominioService.FindByEmail(loginDTO.Email);
            if(condominio == null) { 
            }
            // -- checkpassword
        }


        public async Task CreateUserAsync(RegisterDTO newUser)
        {
            // -- email check
            var condominoEmailCheck = await _condominoService.FindByEmail(newUser.Email);
            var condominioEmailCheck = await _condominioService.FindByEmail(newUser.Email);
            if(condominioEmailCheck != null || condominoEmailCheck != null)
            {
                throw new Exception("Email already in use.");
            }
            // -- check user type
            if (newUser.isCondominio)
            {
                var condominioCnpjCheck = await _condominioService.FindByCnpj(newUser.Cnpj);
                if(condominioCnpjCheck != null) throw new Exception("Cnpj already in use.");
                Condominio newCondominio = new Condominio(newUser);
                await _condominioService.CreateAsync(newCondominio);
            }
            else {
                var condominoCnpjCheck = await _condominoService.FindByCpf(newUser.Cpf);
                if (condominoCnpjCheck != null) throw new Exception("Cpf already in use.");
                Condomino newCondomino = new Condomino(newUser);
                await _condominoService.CreateAsync(newCondomino);
            }
        }

    }
}
