using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemClub.Models;
using SystemClub.Services;

namespace SystemClub.Controllers
{
    public class SocioController : Controller
    {
        // GET: Socio
        public ActionResult Index()
        {
            return View();
        }

        public string GravaSocio()
        {
            SocioService service = new SocioService();
            Socio socio = new Socio();
            socio.NomeSocio = "TESTE DE CADASTRO3333333333333333";
            service.Salvar(socio);

            return "";
        }

        public JsonResult Listar()
        {
            SocioService service = new SocioService();
            List<Socio> lstSocio = service.ListarSocio("TESTE DE CADASTRO3333333333333333");
            return Json(lstSocio, JsonRequestBehavior.AllowGet);
        }


    }
}