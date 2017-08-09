using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SystemClub.Context;
using SystemClub.Framework;
using SystemClub.Migrations;
using SystemClub.Models;
using SystemClub.Repositorios;

namespace SystemClub.Services
{
    public class AgregadoService
    {
        private ContextSystem contexto;
        private Repositorio<Agregado> repoAgregado;

        public AgregadoService()
        {
            contexto = new ContextSystem();
            repoAgregado = new Repositorio<Agregado>(contexto);
        }

        public void Dispose()
        {
            if (contexto != null)
            {
                contexto.Dispose();
            }
        }

        public List<Agregado> Listar()
        {
            return repoAgregado.ObterTodos().ToList();
        }

        public Agregado Consultar(int id)
        {
            return repoAgregado.Obter(id);
        }

        public List<Agregado> ListarAgregado(string nmAgregado)
        {
            return repoAgregado.ObterPorFiltros(c => (nmAgregado == null || c.NomeAgregado.ToString().Equals(nmAgregado))).ToList();
        }

        public Resultado Salvar(Agregado agregado)
        {
            Resultado retorno = new Resultado();

            Agregado agregadoConsulta = repoAgregado.ObterPorFiltros(c => c.idAgregado != agregado.idAgregado).FirstOrDefault();

            if (agregadoConsulta != null)
            {
                retorno.AddMensagem("Cadastro", "Agregado já cadastrado.");
            }

            if (!retorno.Sucesso)
            {
                if (agregado.idAgregado == null)
                {
                    retorno.Erro("Erros encontrados ao cadastrar o agregado");
                }
                else
                {
                    retorno.Erro("Erros encontrados ao alterar agregado.");
                }
                return retorno;
            }

            try
            {
                if (agregado.idAgregado == null)
                {
                    repoAgregado.Adicionar(agregado);
                }
                else
                {
                    repoAgregado.Alterar(agregado);
                }
                contexto.SaveChanges();
                retorno.Ok("Cadastro de agregado realizado com sucesso.");
            }
            catch (Exception erro)
            {
                retorno.Erro(erro.Message);
            }
            return retorno;
        }

        public List<Agregado> Filtrar(Expression<Func<Agregado, bool>> filtro, Expression<Func<Agregado, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repoAgregado.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Resultado Excluir(int id)
        {
            Resultado retorno = new Resultado();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir Agregado.");
                return retorno;
            }
            try
            {
                repoAgregado.Remover(id);
                contexto.SaveChanges();
                retorno.Ok("Agregado removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o Agregado." + erro.Message);
            }
            return retorno;
        }

        public List<Agregado> Filtrar(Agregado agregado)
        {
            return repoAgregado.ObterPorFiltros(c => (
                (agregado.idAgregado == null || c.idAgregado == agregado.idAgregado) &&
                (agregado.NomeAgregado == null || c.NomeAgregado.ToUpper().Contains(agregado.NomeAgregado.ToUpper())) &&
                (agregado.CPF == null || c.CPF.Contains(agregado.CPF)) &&
                (agregado.RG == null || c.CPF.Contains(agregado.RG))
                )).ToList();
        }
    }
}