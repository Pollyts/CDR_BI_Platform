using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CDR_BI_Platform.Models;

namespace CDR_BI_Platform.ViewModels
{
    public class CallRequestViewModel
    {
        public int Id { get; set; }
        public string CallPhone { get; set; }
        public string RecipientPhone { get; set; }
        public DateTime Date { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public decimal Cost { get; set; }
        public string Reference { get; set; }
        public string Currency { get; set; }

    }

    public class CallResponseViewModel
    {
        public int Id { get; set; }
        public string CallPhone { get; set; }
        public string RecipientPhone { get; set; }
        public string Date { get; set; }
        public string EndTime { get; set; }
        public int Duration { get; set; }
        public decimal Cost { get; set; }
        public string Reference { get; set; }

        [StringLength(3)]
        public string Currency { get; set; }
    }
}
