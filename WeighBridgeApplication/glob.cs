using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeighBridgeApplication
{
    class glob
    {
        public static string URL_TO_POST_LOGS = "";// "https://pcmc.bioenabletech.com/api/weighbridge-log.php";// "https://122.15.104.75/api/weighbridge-log.php";// "https://pcmc-swm.bioenabletech.com/api/weighbridge-log.php";// "http://apps.fingerprintkey.com/wfh_service.php";
        public static string URL_TO_POST_IMAGES = "";// "https://pcmc.bioenabletech.com/api/webservice.php"; // "https://122.15.104.75/api/webservice.php"; // "https://pcmc-swm.bioenabletech.com/api/webservice.php";// "http://apps.fingerprintkey.com/wfh_service.php";
        public static string CaptureInterval = "10";//sec

        public static string Image_post_interval = "20";
        public static bool trip_in = true;
        public static string DB_Config = "";

        public static string CurrentState = "";

        public static string AppMode = "Auto";

        public static string In_weighbridge_name = "";

        public static bool read_rfid_number = true;
    }
}
