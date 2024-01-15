﻿namespace DATN_ACV_DEV.Model_DTO.Policy_DTO
{
    public class PolicyDTO
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? Type { get; set; }
        public string Image { get; set; }
    }
}
