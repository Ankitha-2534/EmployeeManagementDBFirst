﻿namespace PresentationServiceLayer.Interfaces
{
    public interface IRoleValidation
    {
        string Validation(string text, string field);
        string ValidateDepartment(string userInput, string field);
        string ValidateLocation(string userInput, string field);
    }
}
