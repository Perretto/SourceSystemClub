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
    public class DependenteService
    {
        private ContextSystem contexto;
        private Repositorio<Dependente> repoDependente;

        public DependenteService()
        {
            contexto = new ContextSystem();
            repoDependente = new Repositorio<Dependente>(contexto);
        }

        public void Dispose()
        {
            if (contexto != null)
            {
                contexto.Dispose();
            }
        }

        public List<Dependente> Listar()
        {
            return repoDependente.ObterTodos().ToList();
        }

        public Dependente Consultar(int id)
        {
            return repoDependente.Obter(id);
        }

        public List<Dependente> ListarDependente(string nmDependente)
        {
            return repoDependente.ObterPorFiltros(c => (nmDependente == null || c.NomeDependente.ToString().Equals(nmDependente))).ToList();
        }

        public Resultado Salvar(Dependente dependente)
        {
            Resultado retorno = new Resultado();

            Dependente dependenteConsulta = repoDependente.ObterPorFiltros(c => c.idDependente != dependente.idDependente).FirstOrDefault();

            if (dependenteConsulta != null)
            {
                retorno.AddMensagem("Cadastro", "Dependente já cadastrado.");
            }

            if (!retorno.Sucesso)
            {
                if (dependente.idDependente == null)
                {
                    retorno.Erro("Erros encontrados ao cadastrar o dependente");
                }
                else
                {
                    retorno.Erro("Erros encontrados ao alterar dependente.");
                }
                return retorno;
            }

            try
            {
                if (dependente.idDependente == null)
                {
                    repoDependente.Adicionar(dependente);
                }
                else
                {
                    repoDependente.Alterar(dependente);
                }
                contexto.SaveChanges();
                retorno.Ok("Cadastro de dependente realizado com sucesso.");
            }
            catch (Exception erro)
            {
                retorno.Erro(erro.Message);
            }
            return retorno;
        }

        public List<Dependente> Filtrar(Expression<Func<Dependente, bool>> filtro, Expression<Func<Dependente, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repoDependente.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Resultado Excluir(int id)
        {
            Resultado retorno = new Resultado();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir Dependente.");
                return retorno;
            }
            try
            {
                repoDependente.Remover(id);
                contexto.SaveChanges();
                retorno.Ok("Dependente removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o Dependente." + erro.Message);
            }
            return retorno;
        }

        public List<Dependente> Filtrar(Dependente dependente)
        {
            return repoDependente.ObterPorFiltros(c => (
                (dependente.idDependente == null || c.idDependente == dependente.idDependente) &&
                (dependente.NomeDependente == null || c.NomeDependente.ToUpper().Contains(dependente.NomeDependente.ToUpper())) &&
                (dependente.CPF == null || c.CPF.Contains(dependente.CPF)) &&
                (dependente.RG == null || c.CPF.Contains(dependente.RG))
                )).ToList();
        }
    }
}