//using System.Collections.Generic;
//using System.Web.Http;
////using U8API;
//using U8WebAPIApplication.Models;

//namespace U8WebAPIApplication.Controllers
//{
//    [RoutePrefix("api/hello")]
//    public class HelloController : ApiController
//    {
//        // GET api/hello
//        [HttpGet]
//        [Route("")]
//        public IHttpActionResult Get()
//        {
//            string msg= "";
//            U8Login.clsLogin clsLogin = new U8LoginManager().LoginToU8("AS", "999", "2025", "demo", "DEMO", "2025-12-01", "192.168.88.252", "");
//            if (!string.IsNullOrEmpty(clsLogin.ShareString))
//            {
               
//                System.Diagnostics.Debug.WriteLine("开始");
//                return Ok(new { code = -1,message = clsLogin.ShareString });
//            }
//            Dictionary<string, object> result=new Voucher().Select(clsLogin, "08", "1000104585", ref msg);
//            //bool UnVerifybool = new QTRK().UnVerify(clsLogin, "08", "1000104585", ref msg);
//            //bool Verifybool = new QTRK().Verify(clsLogin, "08", "1000104585", ref msg);
//            //bool Deletebool = new QTRK().Delete(clsLogin, "08", "1000104585", ref msg);
//            return Ok(new { code = 1, message = msg, data = result });
//        }

//        // GET api/hello/5
//        [HttpGet]
//        [Route("{id:int}")]
//        public IHttpActionResult Get(int id)
//        {
//            return Ok(new { id = id, message = $"Hello, your id is {id}" });
//        }

//        // POST api/hello
//        [HttpPost]
//        [Route("")]
//        public IHttpActionResult Post([FromBody] Dictionary<string, object> data)
//        {
//            if (data == null)
//                return BadRequest("Missing request body");

//            System.Diagnostics.Debug.WriteLine(data);

//            string msg = "";
//            U8Login.clsLogin clsLogin = new U8LoginManager().LoginToU8("AS", "999", "2025", "demo", "DEMO", "2025-12-01", "192.168.88.252", "");
//            if (!string.IsNullOrEmpty(clsLogin.ShareString))
//            {

//                System.Diagnostics.Debug.WriteLine("开始");
//                return Ok(new { code = -1, message = clsLogin.ShareString });
//            }
//            //Dictionary<string, object> result = new QTRK().select(clsLogin, "08", "1000104585", ref msg);
//            //bool UnVerifybool = new QTRK().UnVerify(clsLogin, "08", "1000104585", ref msg);
//            //bool Verifybool = new QTRK().Verify(clsLogin, "08", "1000104585", ref msg);
//            //bool Deletebool = new QTRK().Delete(clsLogin, "08", "1000104585", ref msg);
//            return Ok(new { code = 1, message = msg, data = data     });
//        }
//    }
//}
