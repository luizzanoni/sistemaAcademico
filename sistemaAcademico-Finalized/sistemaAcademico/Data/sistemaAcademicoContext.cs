using Microsoft.EntityFrameworkCore;
using sistemaAcademico.Models;

namespace sistemaAcademico.Data
{
    public class sistemaAcademicoContext : DbContext
    {
        public DbSet<Aluno> alunos { get; set; }
        public DbSet<Professor> professores { get; set; }

        //Conexao banco de dados
        //Data Source = (localdb)\MSSQLlocalDB;Integrated Security = True

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLlocalDB;Integrated Security=True;Initial Catalog=sistemaAcademico");
            
            base.OnConfiguring (optionsBuilder);
        }
    }
}
