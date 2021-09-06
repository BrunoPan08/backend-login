using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoKeener3.Authentication
{
    public class AplicacaoDbContexto : IdentityDbContext<AplicacaoUsuario>
    {
        public AplicacaoDbContexto(DbContextOptions<AplicacaoDbContexto> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
