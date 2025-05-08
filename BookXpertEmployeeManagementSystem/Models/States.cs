namespace BookXpertEmployeeManagementSystem.Models
{
    public class Rootobject
    {
        public bool success { get; set; }
        public string message { get; set; }
        public States[] data { get; set; }
    }

    public class States
    {
        public int id { get; set; }
        public string stateName { get; set; }
    }

}

