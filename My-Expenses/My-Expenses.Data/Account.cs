namespace My_Expenses.Data
{
    public class Account
    {
        public int Id { get; set; }
        public int MainAccount { get; set; }
        public int SavingsAccount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}