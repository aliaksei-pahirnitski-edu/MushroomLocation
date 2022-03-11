using ImgLocation.Mushroom.Category;
using System;

namespace ImgLocation.Mushroom.Dto
{
    public class MushroomDto
    {
        private static readonly DateTime ZeroDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public DateTime PhotoDate { get; set; }

        // build by date - as seconds from 
        public long Id { get; set; }
        public int Year { get; set; }

        // EMushroomCategory
        public int Category { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public int? Altitude { get; set; }
        public string FileName { get; set; }
        public string FileHashMd5 { get; set; }

        public MushroomDto EnrichWithCategory(EMushroomCategory category)
        {
            Category = (int)category;
            return this;
        }

        public void SetDate(DateTime utcDate)
        {
            PhotoDate = utcDate;
            Id = (long)(utcDate - ZeroDate).TotalSeconds;
            Year = utcDate.Year;
        }
    }
}
