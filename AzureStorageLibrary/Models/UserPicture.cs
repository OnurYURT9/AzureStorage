using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageLibrary.Models
{
    public class UserPicture:TableEntity
    {
        public string RawPaths { get; set; } //bloblara kaydedilen dosya isimleri
        [IgnoreProperty]
        public List<string> Paths { 
            get=>RawPaths==null ?null : JsonConvert.DeserializeObject<List<string>>(RawPaths);
            set => RawPaths = JsonConvert.SerializeObject(value);
        }

        public string WatermarkRawPaths { get; set; }
        public List<string> WatermarkPaths
        {
            get =>WatermarkPaths==null?null: JsonConvert.DeserializeObject<List<string>>(WatermarkRawPaths);
            set => WatermarkRawPaths = JsonConvert.SerializeObject(value);
        }
    }
}
