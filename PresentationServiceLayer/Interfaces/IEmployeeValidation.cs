namespace PresentationServiceLayer.Interfaces
{
    public interface IEmployeeValidation
    {
        string ValidateEmployeeId(string userInput);
        string ValidateEmail(string userInput);
        string ValidateName(string userInput);
        string ValidateLocation(string userInput);
        string ValidateDepartment(string userInput, string location);
        string ValidateManager(string userInput);
        string ValidateProject(string userInput);
        string ValidateRole(string userInput, string department, string location);
        string ValidateMobileNumber(string userInput);
        DateTime ValidateDate(bool isValidDate, DateTime date, DateTime currentDate);
        DateTime ValidateJoinDate(bool isValidDate, DateTime date, DateTime? currentDate);

    }
}
