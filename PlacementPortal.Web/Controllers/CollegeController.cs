﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Application.Services;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;
using PlacementPortal.Web.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Web.Http.Results;


namespace PlacementPortal.Web.Controllers
{
    public class CollegeController : BaseController
    {
        #region Variable Declaration
        private readonly ICollegeService _collegeService;
        private readonly IMapper _mapper; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collegeService"></param>
        /// <param name="mapper"></param>
        public CollegeController(ICollegeService collegeService, IMapper mapper)
        {
            _collegeService = collegeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Load all the College details
        /// </summary>
        /// <returns>All College Information</returns>
        [HttpGet]
        public async Task<IActionResult> College()
        {
            //List<CollegeModel> lstCollege = new List<CollegeModel>();
            //lstCollege = await GetAllCollege();

            return View();
        }

        [HttpGet]
        public JsonResult GetAllCollege()
        {
            StudentInfoModel student = new StudentInfoModel();
            var lstCollege = _collegeService.GetAll().Result;
            student.Colleges = lstCollege;
            return Json(new { data = student.Colleges });
        }

        /// <summary>
        /// Open new empry page for adding new College
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddCollege()
        {
            return View("AddCollege");
        }

        /// <summary>
        /// Save New college
        /// </summary>
        /// <param name="collegeData"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> AddCollege([FromBody]CollegeModel collegeData)
        {
            Response reponse = new Response();
            if (collegeData == null)
            {
                return Json(new EmptyResult());
            }

            var collegeInfo = _mapper.Map<CollegeModel>(collegeData);
            await _collegeService.Save(collegeInfo);

            if (collegeData != null)
            {
                reponse.Success = true;
                reponse.Message = "Data saved successfully!";
            }
            else
            {
                reponse.Success = false;
                reponse.Message = "Something went wrong. Please try again later!";
            }
            return Json(reponse);
        }
    }
}
