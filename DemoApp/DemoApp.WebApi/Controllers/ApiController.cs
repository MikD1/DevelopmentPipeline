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
            
            new()
            {
                FirstName = "Denis",
                SecondName = "Samsonov",
                Phone = "+79100001122"
            },
            
            new()
            {
                FirstName = "Maxim",
                SecondName = "Andreev",
                Phone = "+79990011"
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
