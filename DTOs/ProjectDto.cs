﻿namespace Project_Management_Api.DTOs
{
    public class ProjectDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Budget { get; set; }
    }
}
