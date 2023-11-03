﻿namespace Gym_Management_System.Entities
{
    public class Email :BaseDto<int>
    {
        public string To { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
    }
}
