namespace DATN_ACV_DEV.Model_DTO.Image_DTO
{
    public class CreateImageRequest
    {
        public string Url { get; set; }
        public string Type { get; set; }
        public Guid? ProductId { get; set; }

    }
}
