using System;
using System.Collections.Generic;
using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
    public interface IPromotionService
    {
        PromotionDto GetPromotion(int id);
        IEnumerable<PromotionDto> GetPromotions(string name, int discountFrom, int discountTo, DateTime start, DateTime end, int pageIndex, int pageSize, out int count);
        PromotionDto GetProByCode(string code);
        IEnumerable<PromotionDto> GetAll();
        IEnumerable<string> GetListPromotions();    
        void CreatePromotion(SavePromotionDto productDto);
        void UpdatePromotion(SavePromotionDto productDto);
        void DeletePromotion(int id);
    }
}