using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentJoinApplication.Models;

namespace StudentJoinApplication.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            List<StudentDataDetailsModel> studentDetails = StudentDataModel.GetStudentData();
            List<StudentTranscationsDetailsModel> studentTranscationsDetails = StudentTransactionsModel.GetStudentTranscationData();
            List<DataAndTranscationsModel> studentJoinResult = (from data in studentDetails
                                                                join transcation in studentTranscationsDetails
                                                                on data.ID equals transcation.ID
                                                                select new DataAndTranscationsModel
                                                                {
                                                                    ID = data.ID,
                                                                    Name = data.Name,
                                                                    Fees = transcation.Fees,
                                                                    Class = data.Class,
                                                                    Date = transcation.Date,
                                                                    Age = data.Age
                                                                }
                            ).ToList();
            StudentJoinDetailsModel sendJoinResults = new StudentJoinDetailsModel();
            sendJoinResults.studentJoinResultSet = studentJoinResult;
            return View(sendJoinResults);
        }
        [HttpPost]
        public IActionResult Index(StudentSearchModel searchData)
        {
            StudentJoinSearchModel studentResult = new StudentJoinSearchModel();
            List<DataAndTranscationsModel> studentAllDetails = studentResult.SearchStudentData(searchData);
            return PartialView("_StudentPartialView", studentAllDetails);
        }
    }
}