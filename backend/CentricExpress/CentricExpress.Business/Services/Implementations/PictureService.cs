using System;
using System.Collections.Generic;
using System.Linq;
using CentricExpress.Business.Domain;
using CentricExpress.Business.DTOs;
using CentricExpress.Business.Repositories;

namespace CentricExpress.Business.Services.Implementations
{
    public class PictureService : IPictureService
    {
        private readonly IRepository<Picture> pictureRepository;

        public PictureService(IRepository<Picture> pictureRepository)
        {
            this.pictureRepository = pictureRepository;
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Insert(PictureDTO picture)
        {
            picture.Id = Guid.NewGuid();
            
            pictureRepository.Insert(PictureDTO.MapFromModel(picture));

            pictureRepository.SaveChanges();
        }

        public PictureDTO Get(string id)
        {
            var guid = Guid.Parse(id);

            var picture = pictureRepository.GetById(guid);

            return PictureDTO.MapFromModel(picture);

        }

        public IEnumerable<PictureDTO> Get()
        {
            return pictureRepository.Get().Select(PictureDTO.MapFromModel).ToList();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}