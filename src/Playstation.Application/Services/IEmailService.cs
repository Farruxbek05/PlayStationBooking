﻿namespace Playstation.Application.Services;

public interface IEmailService
{
    Task<bool> SendEmailAsync(string email, string subject);
}
