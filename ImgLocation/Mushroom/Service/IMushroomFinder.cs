using ImgLocation.Mushroom.Dto;

namespace ImgLocation.Mushroom.Service
{
    public interface IMushroomFinder
    {
        MushroomDto[] Find(MushroomsFilter filter);
    }
}
