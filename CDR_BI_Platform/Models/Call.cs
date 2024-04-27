using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDR_BI_Platform.Models
{
    public class Call: IEntityDb
    {
        public int Id { get; set; }
        public string CallPhone { get; set; }
        public string RecipientPhone { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime? Date { get; set; }

        [Column(TypeName = "TIME")]
        public DateTime? EndTime { get; set; }
        public int? Duration { get; set; }
        public decimal? Cost { get; set; }
        public string Reference { get; set; }

        [StringLength(3)]
        public string Currency { get; set; }

        #region navigation
        
        #endregion
    }
}
