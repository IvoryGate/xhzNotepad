using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using XhzNotepadAPI.DB;

namespace XhzNotepadAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class XhzNotepadController : ControllerBase
    {
        ////[HttpGet]
        ////public IActionResult Get()
        ////{
        ////    string data = "这是要返回的数据";
        ////    return Ok(data);
        ////}

        [HttpPost]
        public string Add([FromBody]DB.Task task)
        {
            using (var ctx = new XhzNotepadContext())
            {
                ctx.Tasks.Add(task);
                ctx.SaveChanges();
            }
            return "添加成功！快努力去完成任务吧😍😁";
        }

        [HttpDelete]
        public string Delete([FromQuery]int id )
        {

            //Console.WriteLine(id.GetType().Name);
            //Console.WriteLine(16.GetType().Name);
            using (var  db = new XhzNotepadContext())
            {
                try
                {
                    var task = db.Tasks.FirstOrDefault(x => x.Id.Equals(id));

                    db.Tasks.Remove(task);
                    db.SaveChanges();
                }catch (Exception ex)
                {   
                    
                    Console.WriteLine(ex.Message);
                }
            }
            return "ok";
        }

        [HttpDelete]
        public string DeleteAll()
        {
            using (var db = new XhzNotepadContext())
            {
                db.Tasks.RemoveRange(db.Tasks);
                db.SaveChanges();
            }
            return "OK";
        }

        [HttpGet]
        public List<DB.Task> Get() { 
            var list = new List<DB.Task>();
            using (var ctx = new XhzNotepadContext())
            {
                list.AddRange(ctx.Tasks);
            }

            return list;
        }
    }
}
