using System.Text.RegularExpressions;
using BusinessLogicLayer.Interfaces;
using PresentationServiceLayer.Interfaces;

namespace PresentationServiceLayer
{
    public class RoleValidation:IRoleValidation
    {
        private readonly IRenderOptionsOperation _renderOptionsOperation;

        public RoleValidation(IRenderOptionsOperation dropDownOperation)
        {
            _renderOptionsOperation = dropDownOperation;
        }
        public string Validation(string text)
        {
            string pattern = "^[a-zA-Z ]+$";
            if (text == "" || !Regex.IsMatch(text, pattern))
            {
                throw new InvalidDataException($"InValid Data");
            }
            return text;
        }

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

        public string ValidateDepartment(string userInput, string location)
        {
            var departments = _renderOptionsOperation.GetAllDepartments(location);
            if (!departments.Any(department => department.Name.Equals(userInput)))
            {
                throw new InvalidDataException("InValid Data");
            }
            return userInput;
        }
    }
}
