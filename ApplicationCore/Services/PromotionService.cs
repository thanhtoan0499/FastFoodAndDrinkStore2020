using System;
using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IUnitOfWorkPromotion _unitOfWork;
        private readonly IMapper _mapper;
        public PromotionService(IUnitOfWorkPromotion unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public PromotionDto GetPromotion(int id)
        {
            var product = _unitOfWork.Promotions.GetBy(id);
            return _mapper.Map<Promotion, PromotionDto>(product);
        }
        public IEnumerable<PromotionDto> GetPromotions(string name, int discountFrom, int discountTo, DateTime start, DateTime end, int pageIndex, int pageSize, out int count)
        {
            PromotionSpecification spec = new PromotionSpecification(name, discountFrom, discountTo, start, end, pageIndex, pageSize);
            PromotionSpecification spec1 = new PromotionSpecification(name, discountFrom, discountTo, start, end);

            var product = _unitOfWork.Promotions.Find(spec);
            count = _unitOfWork.Promotions.Count(spec1);

            return _mapper.Map<IEnumerable<Promotion>, IEnumerable<PromotionDto>>(product);
        }
        public IEnumerable<PromotionDto> GetAll()
        {
            var pro = _unitOfWork.Promotions.GetAll();
            return _mapper.Map<IEnumerable<Promotion>, IEnumerable<PromotionDto>>(pro);
        }
        public IEnumerable<string> GetListPromotions()
        {
            return _unitOfWork.Promotions.GetListPromotions();
        }
        public PromotionDto GetProByCode(string code)
        {
            var Pro = _unitOfWork.Promotions.GetProByCode(code);
            return _mapper.Map<Promotion, PromotionDto>(Pro);
        }
        public void CreatePromotion(SavePromotionDto savePromotionDto)
        {
            var product = _mapper.Map<SavePromotionDto, Promotion>(savePromotionDto);
            _unitOfWork.Promotions.Add(product);
            _unitOfWork.Complete();
        }
        public void UpdatePromotion(SavePromotionDto savePromotionDto)
        {
            var product = _unitOfWork.Promotions.GetBy(savePromotionDto.id);
            if (product == null) return;
            _mapper.Map<SavePromotionDto, Promotion>(savePromotionDto, product);
            _unitOfWork.Complete();
        }
        public void DeletePromotion(int id)
        {
            var product = _unitOfWork.Promotions.GetBy(id);
            if (product != null)
            {
                _unitOfWork.Promotions.Remove(product);
                _unitOfWork.Complete();
            }
        }
    }
}