﻿using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using PayrollManagementSys.Data.UnitOfWorks;
using PayrollManagementSys.Entity.DTOs.Departmans;
using PayrollManagementSys.Entity.Entities;
using PayrollManagementSys.Service.Services.Abstract;

namespace PayrollManagementSys.Web.Controllers
{
    public class DeparmanController : Controller
    {
        private readonly IDepartmanService departmanService;
        private readonly IValidator<Departman> validator;
        private readonly IMapper mapper;

        public DeparmanController(IDepartmanService departmanService,IValidator<Departman> validator,IMapper mapper)
        {
            this.departmanService = departmanService;
            this.validator = validator;
            this.mapper = mapper;
        }
        public async Task<IActionResult> DepartmanPage()
        {
            var departmans = await departmanService.GetAllDepartmanAsync();
            return View(departmans);
        }
        [HttpGet]
        public async Task<IActionResult> DepartmanAdd()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DepartmanAdd(DepartmanDto departmanDto)
        {
            var map = mapper.Map<Departman>(departmanDto);
            var result = await validator.ValidateAsync(map);
            if(result.IsValid)
            {
                await departmanService.DepartmanAddAsync(departmanDto);
                return RedirectToAction("DepartmanPage", "Deparman");
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }
                return View();

        }

        [HttpGet]
        public async Task<IActionResult> DepartmanUpdate(int departmanId)
        {
            var departman = await departmanService.GetDepartmanById(departmanId);
            return View(departman);
        }
        [HttpPost]
        public async Task<IActionResult> DepartmanUpdate(DepartmanDto departmanDto)
        {
            var departman = await departmanService.GetDepartmanById(departmanDto.Id);
            var map = mapper.Map<Departman>(departmanDto);
            var result = await validator.ValidateAsync(map);
            if (result.IsValid)
            {
                await departmanService.DepartmanUpdateAsync(departmanDto);
                return RedirectToAction("DepartmanPage", "Deparman");
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }
            return View(departman);
        }
        public async Task<IActionResult> DepartmanDelete(int departmanId)
        {
            await departmanService.DepartmanSafeDeleteAsync(departmanId);
            return RedirectToAction("DepartmanPage","Deparman");
        }




    }
}
