using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Data.Entity.Core.Objects;
using SystemClub.Migrations;
using SystemClub.Repositorios;
using SystemClub.Context;

namespace SystemClub.Repositorios
{
    public enum Ordenacao
    {
        Asc,
        Desc
    }

    internal class Repositorio<T> : IRepositorio<T> where T : class
    {

        private ContextSystem contexto;

        public Repositorio(ContextSystem contexto)
        {
            this.contexto = contexto;
        }


        public T Adicionar(T t)
        {
            T objetoNovo = setDados.Add(t);
            return objetoNovo;
        }

        public IEnumerable<T> AdicionarLista(IEnumerable<T> t)
        {
            IEnumerable<T> objetoNovo = setDados.AddRange(t);
            return objetoNovo;
        }

        private DbSet<T> setDados
        {
            get
            {
                return contexto.Set<T>();
            }
        }

        public void Alterar(T t)
        {
            var objetoAlterado = contexto.Entry(t);
            setDados.Attach(t);
            objetoAlterado.State = EntityState.Modified;
        }

        public void Remover(params object[] chaves)
        {
            T objetoEncontrado = setDados.Find(chaves);
            if (objetoEncontrado != null)
            {
                setDados.Remove(objetoEncontrado);
            }
        }

        public void Remover(System.Linq.Expressions.Expression<Func<T, bool>> predicado)
        {
            foreach (T item in ObterPorFiltros(predicado))
            {
                Remover(item);
            }
        }

        public void Remover(T t)
        {
            setDados.Remove(t);
        }

        public int Contagem()
        {
            return setDados.Count();
        }

        public int Contagem(System.Linq.Expressions.Expression<Func<T, bool>> predicado)
        {
            return setDados.Count(predicado);
        }

        public bool Contem(Expression<Func<T, bool>> predicado)
        {
            return setDados.Count(predicado) > 0;
        }

        public T Obter(params object[] chaves)
        {
            return setDados.Find(chaves);
        }

        public IQueryable<T> ObterTodos()
        {
            return setDados.AsQueryable();
        }

        public IQueryable<T> ObterPorFiltros(Expression<Func<T, bool>> predicado)
        {
            return setDados.Where(predicado).AsQueryable();
        }

        public IQueryable<T> ObterPorFiltros(Expression<Func<T, bool>> predicado, out int totalPaginas, int tamanho = 10, int pagina = 1)
        {
            var novoSetDados = predicado == null ? ObterTodos() : ObterPorFiltros(predicado);
            int qtdPular = tamanho * (pagina - 1);

            novoSetDados = qtdPular == 0 ? novoSetDados.Take(tamanho) : novoSetDados.Skip(qtdPular).Take(tamanho);
            totalPaginas = novoSetDados.Count();

            return novoSetDados.AsQueryable();
        }

        public IQueryable<T> Filtrar(Expression<Func<T, bool>> filtro, Expression<Func<T, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            var objSet = ((IObjectContextAdapter)contexto).ObjectContext.CreateObjectSet<T>();
            var objQuery = (ObjectQuery<T>)objSet;
            var resultado = objQuery.Where(filtro == null ? t => 1 == 1 : filtro);

            if (campo != null)
            {
                if (ordenacao == Ordenacao.Asc)
                {
                    resultado = resultado.OrderBy(campo);
                }
                else
                {
                    resultado = resultado.OrderByDescending(campo);
                }
            }
            return resultado;
        }
    }
}