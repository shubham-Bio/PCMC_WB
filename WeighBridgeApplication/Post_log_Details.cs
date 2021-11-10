


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace WeighBridgeApplication
{
    class Post_log_Details
    {
        [JsonProperty("weight_slip_id")]
        public string weight_slip_id { get; set; }


        [JsonProperty("weighbridge_id")]
        public string weighbridge_id { get; set; }

        [JsonProperty("weigh_slip_number")]
        public string weigh_slip_number { get; set; }

        [JsonProperty("trans_type")]
        public string trans_type { get; set; }

        [JsonProperty("vehicle_by")]
        public string vehicle_by { get; set; }

        [JsonProperty("rfid")]
        public string rfid { get; set; }

        [JsonProperty("vehicle_no")]
        public string vehicle_no { get; set; }

        [JsonProperty("material_id")]
        public string material_id { get; set; }

        [JsonProperty("material_name")]
        public string material_name { get; set; }

        [JsonProperty("from_id")]
        public string from_id { get; set; }

        [JsonProperty("from_name")]
        public string from_name { get; set; }

        [JsonProperty("to_name")]
        public string to_name { get; set; }

        [JsonProperty("first_weight")]
        public string first_weight { get; set; }

        [JsonProperty("second_weight")]
        public string second_weight { get; set; }

        [JsonProperty("first_weight_datetime")]
        public string first_weight_datetime { get; set; }

        [JsonProperty("second_weight_datetime")]
        public string second_weight_datetime { get; set; }

        [JsonProperty("net_weight")]
        public string net_weight { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("slip_number")]
        public string slip_number { get; set; }

        [JsonProperty("is_deleted")]
        public string is_deleted { get; set; }

        [JsonProperty("shift_id")]
        public string shift_id { get; set; }

        [JsonProperty("updated_by")]
        public string updated_by { get; set; }

        [JsonProperty("image1")]
        public string image1 { get; set; }

        [JsonProperty("image2")]
        public string image2 { get; set; }

        [JsonProperty("image3")]
        public string image3 { get; set; }

        [JsonProperty("image4")]
        public string image4 { get; set; }

        [JsonProperty("image5")]
        public string image5 { get; set; }

        [JsonProperty("image6")]
        public string image6 { get; set; }


        [JsonProperty("IN_WB_Name")]
        public string IN_WB_Name { get; set; }

        [JsonProperty("Out_WB_Name")]
        public string Out_WB_Name { get; set; }
    }
}




