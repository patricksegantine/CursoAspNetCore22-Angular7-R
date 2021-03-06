﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using Eventos.IO.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Eventos.IO.Infra.CrossCutting.Identity.Models
{
    public class SignedUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public SignedUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public Guid GetUserId()
        {
            return IsAuthenticated()
                ? Guid.Parse(_accessor.HttpContext.User.GetUserId())
                : Guid.NewGuid();
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
