using projectframe.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projectframe.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-CUOIADU\\SQLEXPRESS;Initial Catalog=\"Profile DB\";Integrated Security=True;Encrypt=False");
        public ActionResult Index()
        {
            int a = 0;
            return View();
        }
        [HttpPost]
        public ActionResult Index(DBLAYER modal)
        {
            SqlCommand cmd = new SqlCommand("sp_profileConection", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name",modal.name);
            cmd.Parameters.AddWithValue("@mobile",modal.number);
            cmd.Parameters.AddWithValue("@email",modal.email);
            cmd.Parameters.AddWithValue("@subject",modal.subject);
            cmd.Parameters.AddWithValue("@message",modal.message);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("About");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return RedirectToAction("index");
        }
    }
}