﻿using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Entities;
using Models.ViewModels;
using System;
namespace Services.Interfaces
{
	public interface IUserService
	{
		

			Task<UserListViewModel> BuildUserListViewModel(Sorting sorting, Paging paging);
			Task<UserListViewModel> BuildInitialUserListViewModel();
			Task<CreateUserViewModel> BuildCreateUserViewModel(CreateUserViewModel? viewModel = null);
			Task<ValidationResult> ValidateCreateUserViewModel(CreateUserViewModel viewModel);
		    Task<EditUserViewModel> BuildEditUserViewModel(Guid userId);
		    Task<ValidationResult> ValidateEditUserViewModel(EditUserViewModel viewModel);

			Task<ActionResult> AddUser(User user);
		    Task<bool> EditUser(User user);
            Task<bool> Delete(User user);


	}
}

