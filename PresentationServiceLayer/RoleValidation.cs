using System.Text.RegularExpressions;
using BusinessLogicLayer.Interfaces;
using PresentationServiceLayer.Interfaces;

namespace PresentationServiceLayer
{
    public class RoleValidation:IRoleValidation
    {
        private readonly IDropDownOperation _dropDownOperation;

        public RoleValidation(IDropDownOperation dropDownOperation)
        {
            _dropDownOperation = dropDownOperation;
        }
        public string Validation(string text, string field)
        {
            string pattern = "^[a-zA-Z ]+$";
            while (text == "" || !Regex.IsMatch(text, pattern))
            {
                Console.WriteLine($"Please enter correct {field} : ");
                text = Console.ReadLine()!;
            }
            return text;
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
    }
}
