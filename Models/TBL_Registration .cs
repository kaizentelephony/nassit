using System.ComponentModel.DataAnnotations;

namespace nassit.Models
{
    public class TBL_Registration
    {
        [Key]
        public int S_No { get; set; }

        public string? User_Name { get; set; }

        public string? Password { get; set; }

        public string? Confirm_Password { get; set; }
    }
}
