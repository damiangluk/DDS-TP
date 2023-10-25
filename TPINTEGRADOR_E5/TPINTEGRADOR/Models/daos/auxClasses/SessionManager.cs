using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace TPINTEGRADOR.Models.daos.auxClasses
{
    public static class SessionManager
    {
        private static Usuario Usuario;

        public static Usuario GetUser() => Usuario;

        public static async Task Login(ClaimsPrincipal user)
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userEmail = user.FindFirst(ClaimTypes.Email)?.Value;
            var userName = user.FindFirst(ClaimTypes.Name)?.Value ?? user.Identity.Name;
            var userSurname = user.FindFirst(ClaimTypes.Surname)?.Value;

            Usuario User = null; 

            if(!DataFactory.UsuarioDao.ExistUser(userId, userEmail))
            {
                Persona newPerson = null;

                if (userName != null && userSurname != null)
                {
                    newPerson = new Persona(userName, userSurname);
                }

                User = new Usuario(userEmail, userId, newPerson);
                DataFactory.UsuarioDao.Insert(User);
            } 
            else
            {
                User = DataFactory.UsuarioDao.GetByTokenAndEmail(userId, userEmail);
            }

            Usuario = User;
        }

        public static async Task Logout()
        {
            Usuario = null;
        }
    }
}
