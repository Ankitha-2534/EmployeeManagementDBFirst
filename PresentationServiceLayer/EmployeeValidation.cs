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

        public string ValidateEmployeeId(string userInput)
        {
            string patternEmpNo = "^TZ\\d{4}$";
            var UIdList = _renderOptionsOperation.GetAllIds();
            bool isValid = true;
            int val = 0,check=0;
            for (int i = 0; i < UIdList.Count(); i++)
            {
                if (userInput == UIdList[i].Uid)
                {
                    isValid = true;
                    break;
                }
            }
            while (string.IsNullOrEmpty(userInput) || !Regex.IsMatch(userInput, patternEmpNo) || isValid==true)
            {
                for (int i = 0; i < UIdList.Count(); i++)
                {
                    if (userInput == UIdList[i].Uid)
                    {
                        Console.WriteLine("Please enter correct Employee Id  : ");
                        userInput = Console.ReadLine()!;
                        check++;
                    }
                }
                val++;
                if (val-check==1)
                {
                    isValid = false;
                    break;
                }
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
            var locations = _renderOptionsOperation.GetAllLocations();
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
            var managers = _renderOptionsOperation.GetAllManagers();
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
            var projects = _renderOptionsOperation.GetAllProjects();
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

        public string ValidateRole(string userInput, string field,string department,string location)
        {
            var roles = _renderOptionsOperation.GetAllRoles(department,location);
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


        public string ValidateDepartment(string userInput, string field,string location)
        {
            var departments = _renderOptionsOperation.GetAllDepartments(location);
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