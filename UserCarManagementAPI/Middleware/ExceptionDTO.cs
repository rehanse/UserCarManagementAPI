﻿namespace UserCarManagementAPI.Middleware
{
    public class ExceptionDTO
    {
        public string? Api_id { get; set; }
        public int? Response_code { get; set; }
        public string? Response_message { get; set; }
        public DateTime? dateTime { get; set; }
    }
}
