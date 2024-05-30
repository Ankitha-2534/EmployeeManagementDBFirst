using System.Text.RegularExpressions;
using BusinessLogicLayer.Interfaces;
using PresentationServiceLayer.Interfaces;

namespace PresentationServiceLayer
{
    public class EmployeeValidation : IEmployeeValidation
    {
        private readonly IDropDownOperation _dropDownOperation;
        public EmployeeValidation(IDropDownOperation dropDownOperation)
        {
            _dropDownOperation = dropDownOperation;
        }

        public string ValidateEmployeeId(string userInput)
        {
            string patternEmpNo = "^TZ\\d{4}$";
            while (string.IsNullOrEmpty(userInput) || !Regex.IsMatch(userInput, patternEmpNo))
            {
                Console.WriteLine("Please enter correct Employee Id  : ");
                userInput = Console.ReadLine()!;
            }
            return userInput;
        }

        public string ValidateEmail(string userInput)
        {
            string patternMail = "^[a-zA-Z0-9]+@[a-zA-Z]+\\.[a-zA-Z]+$";
            while (string.IsNullOrEmpty(userInput) || !Regex.IsMatch(userInput, patternMail))
            {
                Console.WriteLine($"Please enter correct Employee Email : ");
                userInput = Console.ReadLine()!;
            }
            return userInput;
        }

        public string ValidateName(string userInput, string field)
        {
            string patternName = "^(?! )[A-Za-z ]+$";
            while (userInput == string.Empty || !Regex.IsMatch(userInput, patternName))
            {
                Console.WriteLine($"Please enter correct {field} : ");
                userInput = Console.ReadLine()!;
            }
            return userInput;
        }

        public string ValidateLocation(string userInput, string field)
        {
            var locations = _dropDownOperation.GetAllLocations();
            bool userInputLocation = false;
            while (userInputLocation == false)
            {
                if (locations.Any(location => location.Name.Equals(userInput)))
                {
                    userInputLocation = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter correct Location from given options : ");
                    userInput = Console.ReadLine()!;
                }
            }
            return userInput;
        }
        public string ValidateManager(string userInput, string field)
        {
            var managers = _dropDownOperation.GetAllManagers();
            bool userInputManager = false;
            while (userInputManager == false)
            {
                if (managers.Any(manager => manager.Name.Equals(userInput)))
                {
                    userInputManager = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter correct Manager from given options : ");
                    userInput = Console.ReadLine()!;
                }
            }
            return userInput;
        }

        public string ValidateProject(string userInput, string field)
        {
            var projects = _dropDownOperation.GetAllProjects();
            bool userInputProject = false;
            while (userInputProject == false)
            {
                if (projects.Any(project => project.Name.Equals(userInput)))
                {
                    userInputProject = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter correct Project from given options : ");
                    userInput = Console.ReadLine()!;
                }
            }
            return userInput;
        }

        public string ValidateRole(string userInput, string field)
        {
            var roles = _dropDownOperation.GetAllRoles();
            bool userInputRole = false;
            while (userInputRole == false)
            {
                if (roles.Any(role => role.RoleName.Equals(userInput)))
                {
                    userInputRole = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter correct Role from given options : ");
                    userInput = Console.ReadLine()!;
                }
            }
            return userInput;
        }


        public string ValidateDepartment(string userInput, string field)
        {
            var departments = _dropDownOperation.GetAllDepartments();
            bool userInputDepartment = false;
            while (userInputDepartment == false)
            {
                if (departments.Any(department => department.Name.Equals(userInput)))
                {
                    userInputDepartment = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter correct Department from given options : ");
                    userInput = Console.ReadLine()!;
                }
            }
            return userInput;
        }
        public string ValidateMobileNumber(string userInput)
        {
            if (!string.IsNullOrEmpty(userInput))
            {
                while (userInput.Length != 10)
                {
                    Console.WriteLine("Phone Number should contain atleast 10 digits : ");
                    userInput = Console.ReadLine()!;
                }
            }
            return userInput;
        }

        public DateTime ValidateDate(bool isValidDate, DateTime date, DateTime currentDate)
        {
            while (!isValidDate || currentDate < date)
            {
                if (currentDate < date)
                {
                    Console.WriteLine("Date of Birth Should be prior to current date");

                }
                else
                {
                    Console.WriteLine($"Please enter correct Date Of Birth : ");
                }
                string dateString = Console.ReadLine()!;
                isValidDate = DateTime.TryParse(dateString, out date);
                if (string.IsNullOrEmpty(dateString))
                {
                    break;
                }

            }
            return date;
        }

        public DateTime ValidateJoinDate(bool isValidDate, DateTime date, DateTime? currentDate)
        {
            while (!isValidDate || currentDate > date)
            {
                if (currentDate > date)
                {
                    Console.WriteLine("The join date should follow the date of birth");

                }
                else
                {
                    Console.WriteLine($"Please enter correct Join Date : ");
                }
                string dateString = Console.ReadLine()!;
                isValidDate = DateTime.TryParse(dateString, out date);

            }
            return date;
        }
    }
}