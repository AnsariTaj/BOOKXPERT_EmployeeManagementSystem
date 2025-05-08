using System.ComponentModel.DataAnnotations;
using System;

namespace BookXpertEmployeeManagementSystem.Models
{
     
        public class EmployeeModel
        {
            public bool success { get; set; }
            public string message { get; set; }
            public Data[] data { get; set; }
        }

        public class Data
        {
            public int EmployeeId { get; set; }
            public string Name { get; set; }
            public string Designation { get; set; }
            public DateTime DateOfJoin { get; set; }
            public float Salary { get; set; }
            public string Gender { get; set; }
            public string State { get; set; }
            public DateTime DateOfBirth { get; set; }
            public DateTime CreatedAt { get; set; }
        }

    
}
