using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DATN_ACV_DEV.Entity
{
    public class TbOrderHistories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid OrderId { get; set; }

        public Guid? IdKhachHang { get; set; }

        public Guid? IdBoss { get; set; }

        public string? Message { get; set; }
        public DateTime LogTime { get; set; }

        public TbOrder Order { get; set; }

        public bool Type { get; set; }
    }
}
