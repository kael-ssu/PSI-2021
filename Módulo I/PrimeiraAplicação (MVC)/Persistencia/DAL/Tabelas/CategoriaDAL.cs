using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Contexts;
using Modelo.Tabelas;
using System.Data.Entity;

namespace Persistencia.DAL.Tabelas
{
    public class CategoriaDAL
    {
        EFContext context = new EFContext();

        public IQueryable<Categoria> ObterCategoriasClassificadasPorNome()
        {
            return context.Categorias.OrderBy(c => c.Nome);
        }

        public Categoria ObterCategoriaPorId(long id)
        {
            return context.Categorias.Find(id);
        }

        public void GravarCategoria(Categoria Categoria)
        {
            if (Categoria.CategoriaId == 0)
                context.Categorias.Add(Categoria);
            else
                context.Entry(Categoria).State = EntityState.Modified;

            context.SaveChanges();
        }

        public Categoria EliminarCategoriaPorId(long id)
        {
            Categoria Categoria = ObterCategoriaPorId(id);
            context.Categorias.Remove(Categoria);
            context.SaveChanges();
            return Categoria;
        }
    }
}
