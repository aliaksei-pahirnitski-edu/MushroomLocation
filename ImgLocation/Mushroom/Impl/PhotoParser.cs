using ExifLib;
using ImgLocation.Mushroom.Dto;
using System;
using System.IO;

namespace ImgLocation.Mushroom.Service
{
    public class PhotoParser : IPhotoParser
    {
        public MushroomDto Proceed(string imgPath)
        {
            var result = new MushroomDto()
            {
                FileName = new FileInfo(imgPath).Name,
                FileHashMd5 = HashHelper.MakeHash(imgPath)
            };

            using (ExifReader reader = new ExifReader(imgPath))
            {
                // Extract the tag data using the ExifTags enumeration
                DateTime datePictureTaken;
                if (reader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized, out datePictureTaken))
                {
                    // result.PhotoDate = datePictureTaken;
                    result.SetDate(datePictureTaken);
                }

                // lon
                if (reader.GetTagValue(ExifTags.GPSLongitude, out double[] lon))
                {
                    // exif coord is 3-numbers array
                    result.Lon = ConvertCoord(lon);
                }

                // lat
                if (reader.GetTagValue(ExifTags.GPSLatitude, out double[] lat))
                {
                    result.Lat = ConvertCoord(lat);
                }

                if (reader.GetTagValue(ExifTags.GPSAltitude, out double alt))
                {
                    result.Altitude = (int)Math.Round(alt);
                }
            }

            return result;
        }

        private double ConvertCoord(double[] exifCoord)
        {
            return exifCoord[0] + exifCoord[1] / 60d + exifCoord[2] / 3600d;
        }
    }
}
