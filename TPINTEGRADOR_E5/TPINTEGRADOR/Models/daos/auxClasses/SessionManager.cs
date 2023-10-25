using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace TPINTEGRADOR.Models.daos.auxClasses
{
    public static class SessionManager
    {
        private static Usuario Usuario;

        public static Usuario GetUser() {
            return Usuario;
        }

        public static async Task Login(ClaimsPrincipal User) {
            var sub = User.FindFirst("sub")?.Value;
        }
    }
}
