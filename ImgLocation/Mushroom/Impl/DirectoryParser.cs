using System.IO;
using System.Linq;
using System.Threading.Tasks;

using ImgLocation.Mushroom.Category;
using ImgLocation.Mushroom.Dto;

namespace ImgLocation.Mushroom.Service
{
    public class DirectoryParser : IDirectoryParser
    {
        private readonly IPhotoParser _photoParser;

        public DirectoryParser(IPhotoParser photoParser)
        {
            _photoParser = photoParser;
        }

        public async Task<MushroomDto[]> ProceedDrectory(EMushroomCategory category, string dirPath)
        {
            var list = Directory.EnumerateFiles(dirPath)
                .Select(_photoParser.Proceed)
                .Select(x => x.EnrichWithCategory(category))
                .ToArray();
            return list;
        }
    }
}
