using System.Collections;
using System.Collections.Generic;
using CentricExpress.Business.DTOs;

namespace CentricExpress.Business.Services
{
    public interface IPictureService
    {
        PictureDTO Get(string id);

        IEnumerable<PictureDTO> Get();

        void Insert(PictureDTO picture);

        void Delete();
    }
}