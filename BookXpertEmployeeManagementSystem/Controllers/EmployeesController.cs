using BookXpertEmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookXpertEmployeeManagementSystem.Controllers
{
    public class EmployeesController : Controller
    {
        HttpClient httpClient = new HttpClient();
       
        public  async Task<IActionResult> Create()
        {
            var employeeData =await  GetEmployeeDetails(); // This gets the employee data
            var stateData =await  GetState(); // This gets the state data
            //Combine both data into a ViewModel
            var viewModel = new EmployeeViewModel
            {
                Employees = employeeData,
                States = stateData
            };

            return View(viewModel);
        }
        public IActionResult CreateEmployee(Data Employeedata)
        {
            try
            {
                var data = JsonConvert.SerializeObject(Employeedata);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync(AppSetting.Url + "Employee/CreateEmployee", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["AlertMessage"] = "Data saved successfully!";
                    return RedirectToAction("Create");
                }
                else
                {
                    TempData["AlertMessage"] = "Failed to save data.!";
                    return RedirectToAction("Create");
                }
            }
            catch (Exception ex)
            {

                throw;
            }           
        }
        [HttpGet("GetStateEmployee")]
        public async Task<List<Data>> GetEmployeeDetails()
        {
            List<Data> states = new List<Data>();
            try
            {
                HttpResponseMessage response =await httpClient.GetAsync(AppSetting.Url + "Employee");
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var rootobject = JsonConvert.DeserializeObject<EmployeeModel>(result);
                    if (rootobject != null)
                    {
                        states = rootobject.data.ToList();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return states;
        }
        [HttpGet("GetState")]
        public async Task<List<States>> GetState()
        {
            List<States> states = new List<States>();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(AppSetting.Url + "Employee/states");
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    var rootobject = JsonConvert.DeserializeObject<Rootobject>(result);
                    if (rootobject != null)
                    {
                        states = rootobject.data.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                // Optional: Log or handle the exception
                throw;
            }

            return states;
        }
        public IActionResult Save()
        {
            // your logic here

            TempData["AlertMessage"] = "Data saved successfully!";
            return RedirectToAction("Create");
        }
        [HttpGet("DeleteEmloyee")]
        public IActionResult DeleteEmloyee(int Id)
        {
            try
            {
                HttpResponseMessage response = httpClient.DeleteAsync(AppSetting.Url+ "Employee/" + Id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["AlertMessage"] = $"Employee Id {Id} Deleted Successlly!!";
                    return RedirectToAction("Create");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return View();
        }

    }
}

