using AutoMapper;
using Data;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Entities;
using Models.ViewModels;
using Services.Interfaces;
using System;
using System.Net;


namespace Services.Implementation
{
    public class UserService : BaseService, IUserService
    {
        private readonly IValidator<CreateUserViewModel> _validator;
        private readonly IValidator<EditUserViewModel> _validator1;
        private readonly IMapper _mapper;

        public UserService(SchoolContext schoolContext, IValidator<CreateUserViewModel> validator, IValidator<EditUserViewModel> validator1,IMapper mapper ) : base(schoolContext)
        {
            _validator = validator;
            _validator1 = validator1;
            _mapper = mapper;
        }


        public async Task<UserListViewModel> BuildInitialUserListViewModel()
        {

            var viewModel = new UserListViewModel
            {
                UserResults = await GetInitialUserResults()
            };

            return viewModel;

        }

        public async Task<UserListViewModel> BuildUserListViewModel(Sorting sorting, Paging paging)
        {

            var viewModel = new UserListViewModel
            {
                UserResults = await GetUserResults(sorting, paging)
            };

            return viewModel;

        }


        private async Task<UserResults> GetInitialUserResults()
        {
            var recordCount = await _schoolContext.User.CountAsync();
            var sorting = new Sorting
            {
                SortColumn = 1,
                SortDirection = "asc"
            };

            Paging paging = new Paging
            {
                RecordsToSkip = 0,
                RecordsToSelect = 10,
                RecordCount = recordCount,
                NumberOfPages = (recordCount / 1),
                CurrentPage = 1

            };

            UserResults userResults = new UserResults
            {

                Users = await SortUserResults(sorting, paging),
                Sorting = sorting,
                Paging = paging

            };
            return userResults;
        }


        private async Task<int> CalculateRecordsToSkip(int recordsToSelect, int currentPage)
        {
            if (currentPage == 1)
            {
                return 0;
            }
            else
            {
                return (currentPage - 1) * recordsToSelect;
            }

        }
        private async Task<UserResults> GetUserResults(Sorting? sorting = null, Paging? paging = null)
        {
            if (sorting == null)
            {
                sorting.SortColumn = 1;
                sorting.SortDirection = "asc";
            }
            if (paging.CurrentPage == 0)
            {
                paging.CurrentPage = 1;
            }

            var recordCount = await _schoolContext.User.CountAsync();
            paging.RecordsToSelect = 10;
            paging.RecordCount = recordCount;
            paging.NumberOfPages = (recordCount / 1);
            // paging.CurrentPage = paging.CurrentPage;
            paging.RecordsToSkip = await CalculateRecordsToSkip(1, paging.CurrentPage);

            UserResults userResults = new UserResults
            {
                Users = await SortUserResults(sorting, paging),
                Paging = paging,
                Sorting = sorting
            };
            return userResults;
        }


        private async Task<List<User>> SortUserResults(Sorting sorting, Paging paging)
        {
            var users = new List<User>();

            if (sorting.SortDirection == "asc")
            {
                switch (sorting.SortColumn)
                {
                    case 1:
                        users = await _schoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.UserSchools).ThenInclude(a => a.School).OrderBy(a => a.FirstName).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                    case 2:
                        users = await _schoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.UserSchools).ThenInclude(a => a.School).OrderBy(a => a.LastName).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                    case 3:
                        users = await _schoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.UserSchools).ThenInclude(a => a.School).OrderBy(a => a.UserSchools.FirstOrDefault().School.Name).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                    case 4:
                        users = await _schoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.UserSchools).ThenInclude(a => a.School).OrderBy(a => a.YearGroup.Name).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                    default:
                        users = await _schoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.UserSchools).ThenInclude(a => a.School).OrderBy(a => a.FirstName).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                }
            }
            else
            {
                switch (sorting.SortColumn)
                {
                    case 1:
                        users = await _schoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.UserSchools).ThenInclude(a => a.School).OrderByDescending(a => a.FirstName).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                    case 2:
                        users = await _schoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.UserSchools).ThenInclude(a => a.School).OrderByDescending(a => a.LastName).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                    case 3:
                        users = await _schoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.UserSchools).ThenInclude(a => a.School).OrderByDescending(a => a.UserSchools.FirstOrDefault().School.Name).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                    case 4:
                        users = await _schoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.UserSchools).ThenInclude(a => a.School).OrderByDescending(a => a.YearGroup.Name).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                    default:
                        users = await _schoolContext.User.Include(a => a.UserType).Include(a => a.YearGroup).Include(a => a.UserSchools).ThenInclude(a => a.School).OrderByDescending(a => a.FirstName).Skip(paging.RecordsToSkip).Take(paging.RecordsToSelect).ToListAsync();
                        break;
                }
            }


            return users;
        }



        public async Task<CreateUserViewModel> BuildCreateUserViewModel(CreateUserViewModel? viewModel = null)
        {
            if (viewModel == null)
            {
                viewModel = new CreateUserViewModel { User = new User() };
            }

            viewModel.SchoolList = await _schoolContext.School.ToListAsync();
            viewModel.UserTypeList = await _schoolContext.UserType.ToListAsync();
            viewModel.YearGroupList = await _schoolContext.YearGroup.ToListAsync();

            return viewModel;
        }

        public async Task<ValidationResult> ValidateCreateUserViewModel(CreateUserViewModel viewModel)
        {
            ValidationResult result = await _validator.ValidateAsync(viewModel);
            return result;
        }

        public async Task<EditUserViewModel> BuildEditUserViewModel(Guid userId)
        {
           
           var viewModel = new EditUserViewModel { User = new User() };
           
            viewModel.User = await _schoolContext.User.Where(a => a.UserId == userId).FirstOrDefaultAsync();

            viewModel.SchoolList = await _schoolContext.School.ToListAsync();
            viewModel.UserTypeList = await _schoolContext.UserType.ToListAsync();
            viewModel.YearGroupList = await _schoolContext.YearGroup.ToListAsync();

            return viewModel;
        }

        public async Task<ValidationResult> ValidateEditUserViewModel(EditUserViewModel viewModel)
        {
            ValidationResult result = await _validator1.ValidateAsync(viewModel);
            return result;
        }



        public async Task<ActionResult> AddUser(User user)
        {
            await _schoolContext.User.AddAsync(user);
            await _schoolContext.SaveChangesAsync();


            return new OkResult();
        }

        public async Task<bool> EditUser(User user)
        { 
            if(await _schoolContext.User.AnyAsync(a => a.UserId ==  user.UserId))
            {
                var userToUpdate = await _schoolContext.User.SingleAsync(a => a.UserId == user.UserId);
                userToUpdate = _mapper.Map(user, userToUpdate);
                await _schoolContext.SaveChangesAsync();

                return true;

            }

            return false;
        }

        public async Task<bool> Delete(User user)
        {
            if (await _schoolContext.User.AnyAsync(a => a.UserId == user.UserId))
            {

                var userToDelete = await _schoolContext.User.SingleAsync(a => a.UserId == user.UserId);
                _schoolContext.User.Remove(userToDelete);
                await _schoolContext.SaveChangesAsync();
                return true;
            }


            return false;
        }

        
    }
}


