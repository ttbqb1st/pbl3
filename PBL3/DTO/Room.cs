using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3.DTO
{
    internal class Room
    {   
        public int room_ID { get; set; }
        public string room_name { get; set; }
        public string hotel_name { get; set; }
        public string location { get; set; }
        public string room_type { get; set; }
        public int price { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string avatarImage { get; set; }
        public List<string> detailedImages { get; set; }


    }
}
