namespace src.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string TokenId { get; set; }
        public double Value { get; set; }
        public bool Paid { get; set; }
        public int PersonId { get; set; }

        public Contract()
        {
            this.CreationDate = DateTime.Now;
            this.TokenId = string.Empty;
            this.Value = 0;
            this.Paid = false;
        }

        public Contract(string tokenId, double value, bool paid = false)
        {
            CreationDate = DateTime.Now;
            Value = value;
            TokenId = tokenId;
            Paid = paid;

        }
    }
}