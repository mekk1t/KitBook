using System.ComponentModel.DataAnnotations;

namespace KK.Cookbook.Models.ViewData
{
    public class StageViewData
    {
        [Display(Name = "Порядок")]
        public int Index { get; set; }
        public string Description { get; set; }
    }
}
