﻿namespace ExpenseTrackApi.Exceptions
{
    public class AppExceptionBase : Exception
    {
        public string ObjectTypeName { get; set; }
        public string Keys { get; set; }
    }
}