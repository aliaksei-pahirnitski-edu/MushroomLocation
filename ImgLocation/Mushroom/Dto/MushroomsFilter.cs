using ImgLocation.Mushroom.Category;

namespace ImgLocation.Mushroom.Dto
{
    public class MushroomsFilter
    {
        public int[] Years { get; set; }

        /// <summary> To search in prev year starting from current Day of year - DaysBefore  /// </summary>
        public int DaysBefore { get; set; } = 0; // 0 means no filter

        /// <summary> To search in prev year starting from current Day of year + DaysAfter  /// </summary>
        public int DaysAfter { get; set; } = 0; // 0 means no filter

        public EMushroomCategory Category { get; set; } // see EMushroomCategory
    }
}
