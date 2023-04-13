using MongoDB.Bson.Serialization.Attributes;
using Prestadito.Investment.Domain.MainModule.Core;

namespace Prestadito.Investment.Domain.MainModule.Entities
{
    [BsonIgnoreExtraElements]
    public class FinancingEntity : AuditEntity
    {
        [BsonElement("dblInvestmentAmount")]
        public decimal DblInvestmentAmount { get; set; }
        [BsonElement("strLoanId")]
        public string StrLoanId { get; set; } = string.Empty;
        [BsonElement("dblInterestRate")]
        public decimal DblInterestRate { get; set; }
        [BsonElement("intLoanTerm")]
        public short IntLoanTerm { get; set; }
        [BsonElement("dteInvestment")]
        public DateTime dteInvestmentst { get; set; }
        [BsonElement("strBorrowerId")]
        public string StrBorrowerId { get; set; } = string.Empty;
        [BsonElement("strInvestmentAgreementDetails")]
        public string StrInvestmentAgreementDetails { get; set; } = string.Empty;
        [BsonElement("strInvestmentCode")]
        public string StrInvestmentCode { get; set; } = string.Empty;
        [BsonElement("dblLoanPercentage")]
        public decimal DblLoanPercentage { get; set; }
    }
}
