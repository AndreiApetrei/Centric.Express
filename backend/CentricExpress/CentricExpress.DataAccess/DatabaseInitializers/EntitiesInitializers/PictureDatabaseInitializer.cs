using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentricExpress.Business.Domain;
using CentricExpress.DataAccess.DatabaseInitializers.EnitiesIdentifiers;

namespace CentricExpress.DataAccess.DatabaseInitializers.EntitiesInitializers
{
    public class PictureDatabaseInitializer
    {
        internal static void Seed(AppDbContext context)
        {
            if (context.Pictures.Any())
            {
                return;
            }

            var pictures = new List<Picture>
            {
                new Picture(PictureId.Picture1)
                {
                    Content = Encoding.ASCII.GetBytes("Picture 1")
                },
                new Picture (PictureId.Picture2)
                {
                    Content = Encoding.ASCII.GetBytes("Picture 2")
                }
            };

            context.Pictures.AddRange(pictures);
            context.SaveChanges();
        }

    }
}