namespace DreamHouse4You.Web.ViewModels.Administration.Category
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamHouse4You.Web.ViewModels.CommonResorces;

    public class AddedCategoriesViewModel
    {
        public AddedCategoriesViewModel()
        {
            this.Categories = new List<CategoryViewModel>();
            this.SortMethods = new List<string>();
            this.SortMethods.Add("Име а-я");
            this.SortMethods.Add("Име я-а");
            this.SortMethodId = this.SortMethods[0];

            this.CountCategoriesOfPageList = new List<int>();
            this.CountCategoriesOfPageList.Add(10);
            this.CountCategoriesOfPageList.Add(15);
            this.CountCategoriesOfPageList.Add(20);

            this.SortMethodId = this.SortMethods[0];
            this.CurrentPage = 1;
            this.SearchCategory = new CategoryViewModel();
            this.CountCategoriesOfPage = this.CountCategoriesOfPageList[0];
        }

        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public CategoryViewModel SearchCategory { get; set; }

        public string SortMethodId { get; set; }

        public List<string> SortMethods { get; set; }

        public int CurrentPage { get; set; }

        public int MaxCountPage { get; set; }

        public int CountCategoriesOfPage { get; set; }

        public List<int> CountCategoriesOfPageList { get; set; }
    }
}
