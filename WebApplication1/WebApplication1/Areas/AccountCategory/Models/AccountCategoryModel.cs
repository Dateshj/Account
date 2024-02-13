namespace WebApplication1.Areas.AccountCategory.Models
{
    public class AccountCategoryModel
    {
        public int AccountCategoryID { get; set; }
        public string AccountCategoryName { get; set;}
        public string Remarks { get; set;}
        public string UserName { get; set;}
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int UserID { get; set; }
    }
}
