using System.ComponentModel.DataAnnotations;

namespace nassit.Models
{
    public class VAR_VERIFICATION
    {
        [Key]
        public DateTime? var_Date { get; set; }
        public string? var_Cust_Mob { get; set; }

         public string? var_Uniqueid { get; set; }

        public string? score { get; set; }

        public string? Verification_status { get; set; }

        public string? File_path { get; set; }

        public DateTime? VAR_END_TIME {  get; set; }

        public String? message { get; set; }

        public String? VAR_LANGUAGE { get; set; }
    }
}
