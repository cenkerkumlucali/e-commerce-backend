using Core.Entities;

namespace Entities.DTOs
{
    public class CustomerPaymentDetailDto:IDto
    {
        public int CardId { get; set; }
        public int UserId { get; set; }
        public string NameOnTheCard { get; set; }
        public string CardNumber { get; set; }
        public string CardCvv { get; set; }
        public string expirationDate { get; set; }
    }
}