using NutritionControl.DataAccess.Entities;
using NutritionControl.DataAccess.Interfaces;
using NutritionControl.Domain.Services.Interfaces;
using NutritionControl.DTO.DtoResults;
using NutritionControl.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionControl.Domain.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IGenericRepository<UserAdditionalInfo> _repository;
        public AccountService(IGenericRepository<UserAdditionalInfo> repository)
        {
            _repository = repository;
        }

        public async Task<ResultDto> GetProfile(int userId)
        {
            //Change when repository will be recreated
            var users = await _repository.GetAllInclude(x => x.User);
            var profile = users.FirstOrDefault(x => x.UserId == userId);

            if (profile != null)
            {
                return new SingleResultDto<ProfileDto>
                {
                    IsSuccessful = true,
                    Message = "",
                    Data = new ProfileDto
                    {
                        Age = profile.Age,
                        BMI = profile.BMI,
                        Email = profile.User.Email,
                        Gender = profile.Gender,
                        GoalWeight = profile.GoalWeight,
                        Height = profile.Height,
                        Name = profile.Name,
                        Surname = profile.Surname,
                        Weight = profile.Weight
                    }
                };
            }
            else
            {
                return new ResultDto { IsSuccessful = false, Message = "User Dont Have Profile" };
            }

        }
    }
}