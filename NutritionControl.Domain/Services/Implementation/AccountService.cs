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

        public async Task<ResultDto> SaveProfile(ProfileDto profile, int userId)
        {
            var _profile = await _repository.GetSingle(x => x.UserId == userId);
            if (_profile == null)
            {
                await _repository.Create(new UserAdditionalInfo
                {
                    UserId = userId,
                    Age = profile.Age,
                    BMI = profile.BMI,
                    Gender = profile.Gender,
                    GoalWeight = profile.GoalWeight,
                    Height = profile.Height,
                    Name = profile.Name,
                    Surname = profile.Surname,
                    Weight = profile.Weight
                });
                return new ResultDto { IsSuccessful = true, Message = "Successfully added" };
            }

            _profile.Name = profile.Name;
            _profile.Age = profile.Age;
            _profile.BMI = profile.BMI;
            _profile.Gender = profile.Gender;
            _profile.GoalWeight = profile.GoalWeight;
            _profile.Height = profile.Height;
            _profile.Name = profile.Name;
            _profile.Surname = profile.Surname;
            _profile.Weight = profile.Weight;

            await _repository.Update(_profile);
            return new ResultDto { IsSuccessful = true, Message = "Successfully changed" };
        }
    }
}