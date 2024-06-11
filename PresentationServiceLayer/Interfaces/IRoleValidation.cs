namespace PresentationServiceLayer.Interfaces
{
    public interface IRoleValidation
    {
        string Validation(string text);
        string ValidateDepartment(string userInput, string location);
        string ValidateLocation(string userInput);
    }
}
