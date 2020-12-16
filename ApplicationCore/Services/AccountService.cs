using System;
using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWorkAccount _unitOfWork;
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWorkAccount unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public AccountDto GetAccount(int id)
        {
            var product = _unitOfWork.Accounts.GetBy(id);
            return _mapper.Map<Account, AccountDto>(product);
        }
        public AccountDto GetByUserName(string username)
        {
            var t =  _unitOfWork.Accounts.GetByUserName(username);
            if( t== null) return null;
            return _mapper.Map<Account, AccountDto>(t);
        }
        public IEnumerable<AccountDto> GetAccounts(int pageIndex, int pageSize, out int count)
        {
            AccountSpecification spec = new AccountSpecification(pageIndex, pageSize);
            AccountSpecification spec1 = new AccountSpecification();

            var product = _unitOfWork.Accounts.Find(spec);
            count = _unitOfWork.Accounts.Count(spec1);

            return _mapper.Map<IEnumerable<Account>, IEnumerable<AccountDto>>(product);
        }
        public IEnumerable<AccountDto> GetAll()
        {
            var pro = _unitOfWork.Accounts.GetAll();
            return _mapper.Map<IEnumerable<Account>, IEnumerable<AccountDto>>(pro);
        }
        public void CreateAccount(SaveAccountDto saveAccountDto)
        {
            var product = _mapper.Map<SaveAccountDto, Account>(saveAccountDto);
            var t  = GetByUserName(saveAccountDto.username);
            if(t != null) return;
            _unitOfWork.Accounts.Add(product);
            _unitOfWork.Complete();
        }
        public void UpdateAccount(SaveAccountDto saveAccountDto)
        {
            var product = _unitOfWork.Accounts.GetBy(saveAccountDto.id);
            if (product == null) return;
            _mapper.Map<SaveAccountDto, Account>(saveAccountDto, product);
            _unitOfWork.Complete();
        }
        public void DeleteAccount(int id)
        {
            var product = _unitOfWork.Accounts.GetBy(id);
            if (product != null)
            {
                _unitOfWork.Accounts.Remove(product);
                _unitOfWork.Complete();
            }
        }
    }
}