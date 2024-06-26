﻿using COMMSFinalProject.Models;
using Microsoft.Extensions.Options;

namespace COMMSFinalProject.Services 
{
    public interface ILoan
    {
        public IQueryable<Loan> GetOwnLoans(int userId);
        public Task<Loan> AddLoan(AddLoan newLoan, int userId);
        public Task<Loan> UpdateOwnLoan(UpdatedLoan newLoan);
        public Task<Loan> DeleteOwnLoan(int loanId);
    }
    public class LoanLogic : ILoan
    {
        private UserContext _context;
        private readonly AppSettings _appSettings;
        public LoanLogic(UserContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public async Task<Loan> AddLoan(AddLoan loanModel, int userId)
        {
            var newLoan = new Loan();
            newLoan.UserId = userId;
            newLoan.LoanType = loanModel.LoanType;
            newLoan.Amount = loanModel.Amount;
            newLoan.Currency = loanModel.Currency;
            newLoan.LoanPeriod = loanModel.LoanPeriod;
            _context.Loans.Add(newLoan);
            await _context.SaveChangesAsync();
            return newLoan;

        }

        public IQueryable<Loan> GetOwnLoans(int userId)
        {
            return _context.Loans.Where(loan => loan.UserId == userId);
        }
        public async Task<Loan> DeleteOwnLoan(int id)
        {
            var deleted = _context.Loans.Find(id);
            _context.Loans.Remove(deleted);
            await _context.SaveChangesAsync();
            return deleted;
        }
        public async Task<Loan> UpdateOwnLoan(UpdatedLoan update)
        {
            var newLoan = new Loan() { Id = update.Id };
            if (update.LoanType != null) newLoan.LoanType = update.LoanType;
            if (update.Amount != 0) newLoan.Amount = update.Amount;
            if (update.Currency != null) newLoan.Currency = update.Currency;
            if (update.LoanPeriod != 0) newLoan.LoanPeriod = update.LoanPeriod;
            return newLoan;

        }
    }
}
