using iplogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UAParser;

namespace iplogger.Controllers
{
    public class HomeController : Controller
    {
        string trackingid = "";
        iplogggerEntities1 db = new iplogggerEntities1();
        [Route("~/")]
        [Route("")]
        public ActionResult index()
        {
            //getting url 
            var url = Request.RawUrl;
            if (url.Length > 1 & url != "/Home/index")
            {
                var idHere = url.Remove(0, 1);
                bool result = db.links.ToList().Exists(m => m.id.Equals(idHere, StringComparison.CurrentCultureIgnoreCase));
                if (result)
                {
                    //authenticating url grabing the original link
                    var result2 = db.links.Where(x => x.id == idHere).Select(x => x.url).ToList();
                    //gathering info of user
                    string ip = Request.UserHostAddress;
                    var userAgent = HttpContext.Request.Headers["User-Agent"].ToString();
                    var uaParser = Parser.GetDefault();
                    ClientInfo c1 = uaParser.Parse(userAgent);
                    //adding into db
                    db.data.Add(new datum()
                    {
                        id = db.links.FirstOrDefault(x => x.id == idHere)?.trackingid ?? "",
                        ipaddress = ip,
                        browser = c1?.UA?.ToString() ?? "",
                        os = (c1?.OS?.ToString() ?? ""),
                        devicetype = c1?.Device?.ToString() ?? "",
                        time = DateTime.Now
                    });
                    db.SaveChanges();
                    Response.Redirect(Convert.ToString(result2[0]));
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult index(string link)
        {

            var sitename = "cutby.link";
            var id = RandomString(6);
            trackingid = RandomString(5);
            string dName = sitename + "/" + id;
            string trackingurl = $"{sitename}/tracking/{trackingid}";
            db.links.Add(new link()
            {
                id = id,
                trackingid = trackingid,
                url = link
            });
            db.SaveChanges();
            return Json(new
            {
                dName,
                trackingurl
            },
             JsonRequestBehavior.AllowGet
             );

        }
        public string RandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
             .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetUserOS(string userAgent)
        {
            // get a parser with the embedded regex patterns
            var uaParser = Parser.GetDefault();
            ClientInfo c = uaParser.Parse(userAgent);
            return c.OS.Family;
        }

        [Route("~/")]
        [Route("")]
        public ActionResult tracking()
        {
            var tracking_id = Request.RawUrl;
            var idHere = tracking_id.Remove(0, 10);
            List<dataModel> d = db.data.Where(x => x.id == idHere).Select(x => new dataModel
            {
                ipaddress = x.ipaddress,
                browser = x.browser,
                os = x.os,
                devicetype = x.devicetype,
                time = x.time
            }).ToList();
            ViewBag.MyList = d;

            return View();
        }
        public class dataModel
        {
            public string ipaddress { set; get; }
            public string browser { set; get; }
            public string os { set; get; }
            public string devicetype { set; get; }
            public Nullable<System.DateTime> time { set; get; }
        }
    }
}