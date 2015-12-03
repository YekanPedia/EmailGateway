namespace YekanPedia.EmailGateway.Domain.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Info.AboutUs")]
    public class AboutUs
    {
        [Key]
        public int AboutUsId { get; set; }

        [MaxLength(30)]
        public string CompanyName { get; set; }

        [MaxLength(20)]
        public string Telphone { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(150)]
        public string Address { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        [StringLength(20)]
        public string Latitude { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        [StringLength(20)]
        public string Longitude { get; set; }

        [MaxLength(90)]
        [StringLength(90)]
        [Column(TypeName = "varchar")]
        public string Twitter { get; set; }

        [MaxLength(90)]
        [StringLength(90)]
        [Column(TypeName = "varchar")]
        public string Facebook { get; set; }

        [MaxLength(90)]
        [StringLength(90)]
        [Column(TypeName = "varchar")]
        public string GooglePlus { get; set; }

        [MaxLength(90)]
        [StringLength(90)]
        [Column(TypeName = "varchar")]
        public string LinkedIn { get; set; }

        [MaxLength(90)]
        [StringLength(90)]
        [Column(TypeName = "varchar")]
        public string Telegram { get; set; }
    }
}
