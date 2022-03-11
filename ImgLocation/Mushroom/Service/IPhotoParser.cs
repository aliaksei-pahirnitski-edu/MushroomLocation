using ImgLocation.Mushroom.Dto;

namespace ImgLocation.Mushroom.Service
{
    public interface IPhotoParser
    {
        MushroomDto Proceed(string imgPath);
    }
}
