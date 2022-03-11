using System;
using System.IO;
using Newtonsoft.Json;

using ExifLib;
using ImgLocation.Mushroom.Service;
using ImgLocation.Mushroom.Category;
using System.Text;
using ImgLocation.Mushroom.Dto;

namespace ImgLocation
{
    class Program
    {
        private static MushroomDto[] ParseDir(string dir)
        {
            var dirService = new DirectoryParser(new PhotoParser());
            var listTask = dirService.ProceedDrectory(EMushroomCategory.Borovik, dir);
            return listTask.Result;
        }

        static void Main(string[] args)
        {
            var dir = "C:\\Грибы2020\\Боровики";
            var list = ParseDir(dir);
            var listJson = JsonConvert.SerializeObject(list);
            var output = "d:\\borovik.json";
            using (var writer = new StreamWriter(output))
            {
                writer.WriteLine(listJson);
            }
            return;

            const string imgPath = "D:\\Test_Borovik.jpg";
            var exists = File.Exists(imgPath);

            var x = new PhotoParser().Proceed(imgPath);
            var json = JsonConvert.SerializeObject(x);
            Console.WriteLine($"json={json }");

            
            var fi = new FileInfo(imgPath);
            //// var fsi = new FileSystemInfo(imgPath);

            // System.Drawing.G

            // ?? Exif
            using (ExifReader reader = new ExifReader(imgPath))
            {
                // Extract the tag data using the ExifTags enumeration
                DateTime datePictureTaken;
                if (reader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized, out datePictureTaken))
                {
                    // Do whatever is required with the extracted information
                    Console.WriteLine(string.Format("The picture was taken on {0}", datePictureTaken));
                }


                // lon
                if (reader.GetTagValue(ExifTags.GPSLongitude, out double[] lon))
                {
                    // Do whatever is required with the extracted information
                    Console.WriteLine($"The picture GPSLongitude {lon}");
                    Console.WriteLine($"The picture GPSLongitude SIZE {lon.Length} ");
                    Console.WriteLine($"The picture GPSLongitude Join: {string.Join(';', lon)} ");
                }
                if (reader.GetTagValue(ExifTags.GPSLongitudeRef, out string lonRef))
                {
                    // Do whatever is required with the extracted information
                    Console.WriteLine($"The picture GPSLongitudeRef {lonRef}");
                }

                if (reader.GetTagValue(ExifTags.GPSLatitude, out double[] lat))
                {
                    // Do whatever is required with the extracted information
                    Console.WriteLine($"The picture GPSLatitude {lat}");
                    Console.WriteLine($"The picture GPSLatitude SIZE {lat.Length} ");
                    Console.WriteLine($"The picture GPSLatitude Join: {string.Join(';', lat)} ");
                }
                if (reader.GetTagValue(ExifTags.GPSLatitudeRef, out string latRef))
                {
                    // Do whatever is required with the extracted information
                    Console.WriteLine($"The picture GPSLatitudeRef {latRef}");
                }

                if (reader.GetTagValue(ExifTags.GPSAltitude, out double _GPSAltitude))
                {
                    // Do whatever is required with the extracted information
                    Console.WriteLine($"The picture GPSAltitude {_GPSAltitude}");
                }
                if (reader.GetTagValue(ExifTags.GPSAltitudeRef, out byte _GPSAltitudeRef))
                {
                    // ??? 0 
                    Console.WriteLine($"The picture _GPSAltitudeRef {_GPSAltitudeRef}");
                }
                if (reader.GetTagValue(ExifTags.GPSSatellites, out string _GPSSatellites))
                {
                    // Do whatever is required with the extracted information
                    Console.WriteLine($"The picture GPSSatellites {_GPSSatellites}");
                }

                if (reader.GetTagValue(ExifTags.GPSDestLatitude, out string destlat))
                {
                    // Do whatever is required with the extracted information
                    Console.WriteLine($"The picture GPSDestLatitude {destlat}");
                }
                if (reader.GetTagValue(ExifTags.GPSDestLatitudeRef, out string destlatRef))
                {
                    // Do whatever is required with the extracted information
                    Console.WriteLine($"The picture GPSDestLatitudeRef {destlatRef}");
                }
            }
        }
    }
}
