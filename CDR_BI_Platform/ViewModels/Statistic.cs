using System.Collections.Generic;
using CDR_BI_Platform.Models;

namespace CDR_BI_Platform.ViewModels
{
    public class StatisticViewModel
    {
        public List<AVGCostResponeModel> AVGCost { get; set; }
        public LinkedEntity TheLongestCall { get; set; }
        public int CallsCount { get; set; }
    }
}
