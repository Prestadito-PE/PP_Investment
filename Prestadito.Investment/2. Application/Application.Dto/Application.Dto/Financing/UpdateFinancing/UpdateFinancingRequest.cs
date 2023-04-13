namespace Prestadito.Investment.Application.Dto.Financing.UpdateFinancing
{
    public class UpdateFinancingRequest
    {
        public string StrId { get; set; } = string.Empty;
        public decimal DblInvestmentAmount { get; set; }
        public string StrLoanId { get; set; } = string.Empty;
        public decimal DblInterestRate { get; set; }
        public short IntLoanTerm { get; set; }
        public DateTime dteInvestmentst { get; set; }
        public string StrBorrowerId { get; set; } = string.Empty;
        public string StrInvestmentAgreementDetails { get; set; } = string.Empty;
        public string StrInvestmentCode { get; set; } = string.Empty;
        public decimal DblLoanPercentage { get; set; }
        public bool BlnActive { get; set; }
    }
}
