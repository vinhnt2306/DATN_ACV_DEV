﻿using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DATN_ACV_DEV.Model_DTO.GHN_DTO
{
    public class GHNServiceResponse
    {
        public int code { get; set; }
        public string code_message_value { get; set; }
        public List<GHNServiceDTO> data { get; set; }
        public string message { get; set; }
    }
    public class GHNServiceDTO
    {
        public int service_id { get; set; }
        public string short_name { get; set; }
        public int service_type_id { get; set; }
        public string config_fee_id { get; set; }
        public string extra_cost_id { get; set; }
        public string standard_config_fee_id { get; set; }
        public string standard_extra_cost_id { get; set; }
    }
}
