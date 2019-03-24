using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotnetWeb.Models;

namespace DotnetWeb.Controllers
{
    public class MemesController : Controller
    {
        private readonly DotnetWebContext context;

        public MemesController(DotnetWebContext context){
            this.context = context;
        }

        [Route("Memes/GetTitle")]
        public ActionResult<List<Memes>> GetTitle(){
            return this.context.Memes.ToList();
        }

        [Route("Memes")]
        [Route("Memes/GetOK")]
        public ActionResult GetOK(){
            // for testing
            return this.StatusCode(200);
        }
    }
}
