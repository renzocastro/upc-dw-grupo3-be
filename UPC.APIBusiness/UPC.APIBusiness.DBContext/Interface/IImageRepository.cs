using System;
using System.Collections.Generic;
using DBEntity;

namespace DBContext
{
    public interface IImageRepository
    {
        List<EntityImage> getImages(int id);
    }
}
