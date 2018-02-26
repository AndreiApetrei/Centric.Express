using System;
using CentricExpress.Business.Domain;

namespace CentricExpress.Business.DTOs
{
    public class PictureDTO
    {   
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string PictureURL { get; set; }

        public string Content { get; set; }
        
        public static PictureDTO MapFromModel(Picture picture)
        {
            return picture != null
                ? new PictureDTO
                {
                    Id = picture.Id,
                    Content = Convert.ToBase64String(picture.Content),
                    Description = picture.Description,
                }
                : null;
        }

        public static Picture MapFromModel(PictureDTO picture)
        {
            return picture != null
                ? new Picture
                {
                    Id = picture.Id,
                    Content = Convert.FromBase64String(picture.Content),
                    Description = picture.Description
                }
                : null;
        }
    }
}