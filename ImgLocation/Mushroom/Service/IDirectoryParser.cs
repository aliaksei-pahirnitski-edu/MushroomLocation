using ImgLocation.Mushroom.Category;
using ImgLocation.Mushroom.Dto;
using System.Threading.Tasks;

namespace ImgLocation.Mushroom.Service
{
    public interface IDirectoryParser
    {
        Task<MushroomDto[]> ProceedDrectory(EMushroomCategory category, string dirPath);
    }
}
