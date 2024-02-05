using System;
using System.ComponentModel.DataAnnotations;


namespace dotnetapp.Model
{

    public class ExpenseModel
    {
        public int ExpenseID { get; set; }

        [Required(ErrorMessage = "ExpenseDetails is required")]
        public string ExpenseDetails { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "PaymentMode is required")]
        public string PaymentMode { get; set; }

        [Required(ErrorMessage = "ExpenseDate is required")]
        public DateTime ExpenseDate { get; set; }
    }

}
