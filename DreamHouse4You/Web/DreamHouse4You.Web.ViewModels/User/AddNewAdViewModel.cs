namespace DreamHouse4You.Web.ViewModels.User
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class AddNewAdViewModel
    {
        [Display(Name = "Ad heading:")]
        public string AdHeading { get; set; }

        [Display(Name = "Ad type:")]
        public Dictionary<string, List<string>> AdType { get; set; }

        [Display(Name = "Ad type selected:")]
        public Dictionary<string, string> AdTypeSelected { get; set; }

        [Display(Name = "Desctiption:")]
        public string Desctiption { get; set; }

        [Display(Name = "Price:")]
        public double Price { get; set; }

        [Display(Name = "Currency:")]
        public ICollection<string> Currency { get; set; }

        public string SelectedCurrency { get; set; }
    }
}
