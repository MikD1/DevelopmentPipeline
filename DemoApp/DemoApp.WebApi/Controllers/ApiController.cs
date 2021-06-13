using System;
using System.Collections.Generic;
using DemoApp.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.WebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        public static List<ContactDto> Contacts = new()
        {
            new()
            {
                FirstName = "Mikhail",
                SecondName = "Ivanov",
                Phone = "+79621112233"
            },

            new()
            {
                FirstName = "Anna",
                SecondName = "Petrova",
                Phone = "+79169998877"
            },
        };

        public static Guid Id = System.Guid.NewGuid();

        [HttpGet("contacts")]
        public ActionResult<List<ContactDto>> GetContacts()
        {
            return Ok(Contacts);
        }

        [HttpGet("healthy")]
        public ActionResult Healthy()
        {
            return Ok("OK");
        }
        
        [HttpGet("guid")]
        public ActionResult Guid()
        {
            return Ok(Id);
        }
    }
}
