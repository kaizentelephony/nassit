using System.ComponentModel.DataAnnotations;

namespace nassit.Models
{
    public class TBL_BLACKLIST
    {
        [Key]
        public int SNO { get; set; }   // Primary Key

        public string? VAR_MOBILE_NUMBER { get; set; }

        public string? VAR_CALLERID { get; set; }

        public DateTime? VAR_DATETIME { get; set; }

        public string? VAR_BLACKLIST_ID { get; set; }
    }
}
