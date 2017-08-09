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
    public class SocioService
    {
        private ContextSystem contexto;
        private Repositorio<Socio> repoSocio;

        public SocioService()
        {
            contexto = new ContextSystem();
            repoSocio = new Repositorio<Socio>(contexto);
        }

        public void Dispose()
        {
            if (contexto != null)
            {
                contexto.Dispose();
            }
        }

        public List<Socio> Listar()
        {
            return repoSocio.ObterTodos().ToList();
        }

        public Socio Consultar(Guid id)
        {
            return repoSocio.Obter(id);
        }

        public List<Socio> ListarSocio(string nmSocio)
        {
            return repoSocio.ObterPorFiltros(c => (nmSocio == null || c.NomeSocio.ToString().Equals(nmSocio))).ToList();
        }

        public Resultado Salvar(Socio socio)
        {
            Resultado retorno = new Resultado();

            Socio socioConsulta = repoSocio.ObterPorFiltros(c => c.idSocio == socio.idSocio).FirstOrDefault();

            if (socioConsulta != null)
            {
                retorno.AddMensagem("Cadastro", "Sócio já cadastrado.");
            }

            if (!retorno.Sucesso)
            {
                if (socio.idSocio == null || socio.idSocio == Guid.Empty)
                {
                    retorno.Erro("Erros encontrados ao cadastrar o sócio");
                }
                else
                {
                    retorno.Erro("Erros encontrados ao alterar acesso.");
                }
                return retorno;
            }

            try
            {
                if (socio.idSocio == null || socio.idSocio == Guid.Empty)
                {
                    socio.idSocio = Guid.NewGuid();
                    repoSocio.Adicionar(socio);
                }
                else
                {
                    repoSocio.Alterar(socio);
                }
                contexto.SaveChanges();
                retorno.Ok("Cadastro de sócio realizado com sucesso.");
            }
            catch (Exception erro)
            {
                retorno.Erro(erro.Message);
            }
            return retorno;
        }

        public List<Socio> Filtrar(Expression<Func<Socio, bool>> filtro, Expression<Func<Socio, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repoSocio.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Resultado Excluir(int id)
        {
            Resultado retorno = new Resultado();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir Socio.");
                return retorno;
            }
            try
            {
                repoSocio.Remover(id);
                contexto.SaveChanges();
                retorno.Ok("Sócio removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o Acesso." + erro.Message);
            }
            return retorno;
        }

        public List<Socio> Filtrar(Socio socio)
        {
            return repoSocio.ObterPorFiltros(c => (
                (socio.idSocio == Guid.Empty || c.idSocio == socio.idSocio) &&
                (socio.NomeSocio == null || c.NomeSocio.ToUpper().Contains(socio.NomeSocio.ToUpper())) &&
                (socio.CPF == null || c.CPF.Contains(socio.CPF)) &&
                (socio.RG == null || c.CPF.Contains(socio.RG))
                )).ToList();
        }
    }
}