namespace DATN_ACV_DEV.Model_DTO.Property_DTO
{
    public class EditPropertyRequest
    {
        public List<Guid>? Id { get; set; }
        public bool? Active { get; set; }
        public string? Name { get; set; }
    }
}
