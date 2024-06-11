namespace PresentationServiceLayer.Interfaces
{
    public interface IEmployeeValidation
    {
        string ValidateEmployeeId(string userInput);
        string ValidateEmail(string userInput);
        string ValidateName(string userInput, string field);
        string ValidateLocation(string userInput, string field);
        string ValidateDepartment(string userInput, string field, string location);
        string ValidateManager(string userInput, string field);
        string ValidateProject(string userInput, string field);
        string ValidateRole(string userInput, string field,string department, string location);
        string ValidateMobileNumber(string userInput);
        DateTime ValidateDate(bool isValidDate, DateTime date, DateTime currentDate);
        DateTime ValidateJoinDate(bool isValidDate, DateTime date, DateTime? currentDate);

    }
}
