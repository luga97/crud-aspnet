using ControleDeContatos.Data;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeContatos.Repositorio
{
    public class UsuarioRepositorio : IUserRepository
    {
        private readonly CrudContext _context;

        public UsuarioRepositorio(CrudContext bancoContent)
        {
            this._context = bancoContent;
        }

        public UserModel FindByLogin(string login)
        {
            return _context.Users.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UserModel FindByEmailOrLogin(string email, string login)
        {
            return _context.Users.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public UserModel FindById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<UserModel> FindAll()
        {
            return _context.Users
                .Include(x => x.Contacts)
                .ToList();
        }

        public UserModel Add(UserModel usuario)
        {
            usuario.CreateDate = DateTime.Now;
            usuario.SetSenhaHash();
            _context.Users.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public UserModel Update(UserModel usuario)
        {
            UserModel usuarioDB = FindById(usuario.Id);

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização do usuário!");

            usuarioDB.Name = usuario.Name;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Profile = usuario.Profile;
            usuarioDB.UpdateDate = DateTime.Now;

            _context.Users.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }

        public UserModel ChangePassword(ChangePasswordModel alterarSenhaModel)
        {
            UserModel usuarioDB = FindById(alterarSenhaModel.Id);

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado!");

            if (!usuarioDB.IsPasswordValid(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha atual não confere!");

            if (usuarioDB.IsPasswordValid(alterarSenhaModel.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual!");

            usuarioDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
            usuarioDB.UpdateDate = DateTime.Now;

            _context.Users.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }

        public bool Delete(int id)
        {
            UserModel usuarioDB = FindById(id);

            if (usuarioDB == null) throw new Exception("Houve um erro na deleção do usuário!");

            _context.Users.Remove(usuarioDB);
            _context.SaveChanges();

            return true;
        }
    }
}
