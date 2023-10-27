using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace TPINTEGRADOR.Models.daos.auxClasses
{
    public static class SessionManager
    {
        private static Usuario Usuario;
        private static Persona Persona;

        public static Persona GetPersona() => Persona;


        public static Usuario GetUser() => Usuario;

        public static async Task Login(ClaimsPrincipal user)
        {
            var name = user.Identity.Name;
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userEmail = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var userName = user.FindFirst(ClaimTypes.Name)?.Value ?? user.Identity.Name;
            var userSurname = user.FindFirst(ClaimTypes.Surname)?.Value;

            Usuario User = null;
            Persona newPerson = null;

            if (!DataFactory.UsuarioDao.ExistUser(userId, userEmail))
            {
                newPerson = new Persona(userName, userSurname);
                User = new Usuario(userEmail, userId, newPerson);
                DataFactory.UsuarioDao.Insert(User);
            }
            else
            {
                User = DataFactory.UsuarioDao.GetByTokenAndEmail(userId, userEmail);
                newPerson = User.Persona;
            }

            Usuario = User;
            Persona = newPerson;

        }

        public static async Task Logout()
        {
            Usuario = null;
        }
    }
}
