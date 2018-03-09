using System;
using System.Collections.Generic;
using System.Net;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentricExpress.WebApi.Controllers
{
    [Route("api/Pictures")]
    public class PicturesController : Controller
    {
        private readonly IPictureService pictureService;

        public PicturesController(IPictureService pictureService)
        {
            this.pictureService = pictureService;
        }
        
        [HttpGet("{id}", Name = "GetPicture")]
        public IActionResult Get(string id)
        {
            var picture = pictureService.Get(id);

            if (picture == null)
            {
                return NotFound();
            }

            return Ok(picture);
        }


        [HttpGet]
        public IEnumerable<PictureDTO> Get()
        {
            return pictureService.Get();
        }



        [HttpPost]
        public IActionResult Post([FromBody]PictureDTO picture)
        {
            if (string.IsNullOrEmpty(picture.PictureURL))
            {
                return BadRequest();
            }

            var webClient = new WebClient();

            var imageBytes = webClient.DownloadData(picture.PictureURL);

            picture.Content = Convert.ToBase64String(imageBytes);

            pictureService.Insert(picture);

            var insert = picture.Content.Insert(0, "data:image/png;base64,");

            picture.Content = insert;

            return Created("GetPicture", picture);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}