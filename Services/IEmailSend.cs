﻿using System.Threading.Tasks;

namespace DevWebsCourseProjectApp.Services
{
   public interface IEmailSend
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
