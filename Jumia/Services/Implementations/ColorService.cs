﻿using AutoMapper;
using Jumia.Models;
using Jumia.Repositories.Interfaces;
using Jumia.Services.IServices;

namespace Jumia.Services.Implementations
{
    public class ColorService(IColorRepository colorRepository , IMapper mapper) : IColorService
    {
        public async Task<List<Color>> GetColorByProductAndSize(int productId)
        {
            var Colors = await colorRepository.GetColorByProductAndSize(productId);
            return mapper.Map<List<Color>>(Colors);
        }

        public async Task<List<Color>> GetColorsBySize(int productId, int sizeId)
        {
            var Colors = await colorRepository.GetColorsBySize(productId, sizeId);
            return mapper.Map<List<Color>>(Colors);
        }
    }
}
