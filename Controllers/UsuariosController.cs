using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;
using RpgApi.Utils;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {

        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {

            _context = context;
        }

        //Verificação de existência de usuário    
        private async Task<bool> UsuarioExistente(string Username)
        {

            if (await _context.TB_USUARIOS.AnyAsync(x => x.Username.ToLower() == Username.ToLower()))
            {

                return true;
            }
            else
            {
                return false;
            }

        }


        [HttpPost("Registrar")]
        //Regsitra um Usuário
        public async Task<IActionResult> RegistrarUsuario(Usuario user)
        {
            try
            {
                if (await UsuarioExistente(user.Username)) //Verifica se o usuário já existe na base dados, caso exista ele retorna uma mensagem
                    throw new System.Exception("Nome de usuário já existe");

                //Faz a criptografia da senha do usuário
                Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                user.PasswordString = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                //Adiciona o usuário no banco
                await _context.TB_USUARIOS.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }

        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)

        {
            try
            {
                Usuario? usuario = await _context.TB_USUARIOS
                   .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado.");
                }
                else if (!Criptografia.VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else
                {

                    usuario.DataAcesso = DateTime.Now;

                    await _context.SaveChangesAsync();

                    return Ok(usuario);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }

        }


        [HttpPut("AlterarSenha")]

        public async Task<IActionResult> AlterarSenha(Usuario Password)
        {
            

            Usuario usuario = new Usuario();

            usuario.PasswordString = Password.ToString();

            Criptografia.CriarPasswordHash(usuario.PasswordString, out byte[] hash, out byte[] salt);

            usuario.PasswordHash = hash;
            usuario.PasswordSalt = salt;


            await _context.TB_USUARIOS.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return Ok(usuario.Id);


        }

        [HttpGet("ExibirTodosUsuario")]

        public async Task<IActionResult> ExibirTodosUsuario()
        {

            try
            {

                List<Usuario> lista = await _context.TB_USUARIOS.ToListAsync();
                return Ok(lista);

            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



    }
}










