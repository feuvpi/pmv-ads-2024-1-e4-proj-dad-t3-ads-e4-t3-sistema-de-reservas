using api_reservas.Helpers;
using api_reservas.Models;
using api_reservas.Models.Dtos;
using api_reservas.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_reservas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController 
    {
        private readonly JwtMiddleware _jwtService;
        private readonly AuthService _authService;
        public AuthController(AuthService repo, JwtMiddleware jwtMiddleare) 
        {
            _authService = repo;
            _jwtService = jwtMiddleare;
        }

        // -- POST REGISTRO
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterDTO entity)
        {
            if (entity.isCondomino)
            {
                // -- cria um condomino
                Condomino condomino = new(entity);

                // -- chama o controlador de condomino para criar um novo condomno
                //CondominoService condominioService = new CondominoService(_myMongoRepository);

                // -- apos retorno bem sucedido do usuario criado, cria e retorno um jwt
                //condominioService.CreateAsync(condomino);

                // -- cria jwt e retora junto com outros dados do usuario


            }
            else
            {
                // -- cria um condomino
                Condominio condominio = new(entity);

                // -- chama o controlador de condomino para criar um novo condomno
                //CondominioService condominioService = new CondominioService(_myMongoRepository);

                // -- apos retorno bem sucedido do usuario criado, cria e retorno um jwt
                //condominioService.CreateAsync(condominio);

                // -- cria jwt e retora junto com outros dados do usuario


            }

            return null;
        }

    }
}
