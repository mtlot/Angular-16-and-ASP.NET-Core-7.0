using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TransactionAPI.Models
{
    public class TransactionDetail
    {
        [Key]
        public int TransactionDetailId { get; set; }

        [Required]
        [Column(TypeName = "bigint")]
        public long ALLOC_TXN_ID { get; set; } = 0;  // Change the type to long for C#

        [Required]
        [Column(TypeName = "nvarchar(11)")]
        public string DEED_INO { get; set; } = "";

        [Required]
        [Column(TypeName = "datetime2(7)")]  // Use datetime2 for better precision and range
        public DateTime LOG_CREATED_TS { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string CONV_DEED_ABBREVIATION { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string SOURCE_REF_ABBREVIATION { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string CONV_STATUS { get; set; } = "";

        [Required]
        [Column(TypeName = "int")]  // Just int for LOT_NO
        public int LOT_NO { get; set; } = 0;

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string DEED_STATUS { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string DEED_TYPE { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string DEED_OWNER_NAME { get; set; } = "";

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string PRINT_STATUS { get; set; } = "";
    }
}
