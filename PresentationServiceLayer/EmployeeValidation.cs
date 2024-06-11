using System.Text.RegularExpressions;
using BusinessLogicLayer.Interfaces;
using PresentationServiceLayer.Interfaces;

namespace PresentationServiceLayer
{
    public class EmployeeValidation : IEmployeeValidation
    {
        private readonly IRenderOptionsOperation _renderOptionsOperation;
        public EmployeeValidation(IRenderOptionsOperation renderOptionsOperation)
        {
            _renderOptionsOperation = renderOptionsOperation;
        }

        //Employee Id
        public string ValidateEmployeeId(string userInput)
        {
            string patternEmpNo = "^TZ\\d{4}$";
            var UIdList = _renderOptionsOperation.GetAllIds();
            bool isValid = false;
            for (int i = 0; i < UIdList.Count(); i++)
            {
                if (userInput == UIdList[i].Uid)
                {
                    throw new InvalidDataException("Invalid data Unique Value Exception!");
                }
            }
            if (string.IsNullOrEmpty(userInput) || !Regex.IsMatch(userInput, patternEmpNo) || isValid==true)
            {
                throw new InvalidDataException("Invalid data Exception!");
            }
            
            return userInput;
        }

        //Email
        public string ValidateEmail(string userInput)
        {
            string patternMail = "^[a-zA-Z0-9]+@[a-zA-Z]+\\.[a-zA-Z]+$";
            if (string.IsNullOrEmpty(userInput) || !Regex.IsMatch(userInput, patternMail))
            {
                throw new InvalidDataException("Invalid Data");
            }
            return userInput;
        }

        //Name
        public string ValidateName(string userInput)
        {
            string patternName = "^(?! )[A-Za-z ]+$";
            if (userInput == string.Empty || !Regex.IsMatch(userInput, patternName))
            {
                throw new InvalidDataException("Invalid Data");
            }
            return userInput;
        }

        //Location
        public string ValidateLocation(string userInput)
        {
            var locations = _renderOptionsOperation.GetAllLocations();
            if (!locations.Any(location => location.Name.Equals(userInput)))
            {
                throw new InvalidDataException("InValid Data Location");
            }
            else
            {
                return userInput;
            }            
        }

        //Manager
        public string ValidateManager(string userInput)
        {
            var managers = _renderOptionsOperation.GetAllManagers();
            if (!managers.Any(manager => manager.Name.Equals(userInput)))
            {
                throw new InvalidDataException("Invalid Data");
            }
            return userInput;
        }

        //Project
        public string ValidateProject(string userInput)
        {
            var projects = _renderOptionsOperation.GetAllProjects();
            if (!projects.Any(project => project.Name.Equals(userInput)))
            {
                throw new InvalidDataException("InValid Data");
            }
            return userInput;
        }

        //Role
        public string ValidateRole(string userInput,string department,string location)
        {
            var roles = _renderOptionsOperation.GetAllRoles(department,location);
            if (!roles.Any(role => role.RoleName.Equals(userInput)))
            {
                throw new InvalidDataException("Invalid Data");
            }
            return userInput;
        }

        //Department
        public string ValidateDepartment(string userInput,string location)
        {
            var departments = _renderOptionsOperation.GetAllDepartments(location);
            if (!departments.Any(department => department.Name.Equals(userInput)))
            {
                throw new InvalidDataException("InValid Data");
            }
            return userInput;
        }

        //MobileNumber
        public string ValidateMobileNumber(string userInput)
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                if (userInput.Length != 10)
                {
                    throw new InvalidDataException("InValid Data");
                }
            }
            return userInput;
        }

        //Date
        public DateTime ValidateDate(bool isValidDate, DateTime date, DateTime currentDate)
        {
            if (currentDate < date)
            {
                throw new InvalidDataException("Date of Birth Should be prior to current date");

            }
            else if (!isValidDate)
            {
                throw new InvalidDataException($"Please enter correct Date Of Birth : ");
            }
            throw new InvalidDataException("Date is not in Correct Format");
            return date;
        }

        //JoinDate
        public DateTime ValidateJoinDate(bool isValidDate, DateTime date, DateTime? currentDate)
        {
            if (currentDate > date)
            {
                throw new InvalidDataException("The join date should follow the date of birth");
            }
            else if(!isValidDate)
            {
                throw new InvalidDataException($"Please enter correct Join Date : ");
            }
            throw new InvalidDataException("Date is not in Correct Format");
            return date;
        }
    }
}