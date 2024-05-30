using BusinessLogicLayer.Interfaces;
using InfrastructureLayer;
using PresentationLayer.Interfaces;
using PresentationServiceLayer.Interfaces;


namespace PresentationLayer
{
    public class EmployeeUI : IEmployeeUI
    {
        private readonly IEmployeeValidation _employeeValidation;
        private readonly IEmployeeOperation _employeeOperation;
        private readonly IDropDownOperation _dropDownOperation;

        public EmployeeUI(IEmployeeValidation employeeValidation, IEmployeeOperation employeeOperation, IDropDownOperation dropDownOperation)
        {
            _employeeValidation = employeeValidation;
            _employeeOperation = employeeOperation;
            _dropDownOperation = dropDownOperation;
        }
        public void Add()
        {
            Utility.GetInput("Please Enter Employee Id(TZ0000) : ");
            string employeeId = Console.ReadLine()!;
            employeeId = _employeeValidation.ValidateEmployeeId(employeeId);

            Utility.GetInput("Please Enter Employee FirstName : ");
            string firstName = Console.ReadLine()!;
            firstName = _employeeValidation.ValidateName(firstName, "First Name");

            Utility.GetInput("Please Enter Employee LastName : ");
            string lastName = Console.ReadLine()!;
            lastName = _employeeValidation.ValidateName(lastName, "Last Name");

            Utility.GetInput("Please Enter Employee DateOfBirth : ");
            string dateOfBirthString = Console.ReadLine()!;
            DateTime currentDate = DateTime.Now;
            DateTime dateOfBirth;
            bool isValidDate = DateTime.TryParse(dateOfBirthString, out dateOfBirth);
            if (!string.IsNullOrEmpty(dateOfBirthString))
            {
                if (!isValidDate || currentDate < dateOfBirth)
                {
                    dateOfBirth = _employeeValidation.ValidateDate(isValidDate, dateOfBirth, currentDate);
                }
            }

            Utility.GetInput("Please Enter Employee Email : ");
            string email = Console.ReadLine()!;
            email = _employeeValidation.ValidateEmail(email);

            Utility.GetInput("Please Enter Employee Phone Number : ");
            string phone = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(phone))
            {
                phone = _employeeValidation.ValidateMobileNumber(phone);
            }

            Utility.GetInput("Please Enter Employee Join Date : ");
            string joinDateString = Console.ReadLine()!;
            DateTime joinDate;
            bool isValidJoinDate = DateTime.TryParse(joinDateString, out joinDate);
            if (!isValidJoinDate || dateOfBirth > joinDate)
            {
                joinDate = _employeeValidation.ValidateJoinDate(isValidJoinDate, joinDate, dateOfBirth);
            }

            Utility.GetInput("Please Enter Employee Location : ");
            var locations = _dropDownOperation.GetAllLocations();
            for (int i = 0; i < locations.Count; i++)
            {
                Console.WriteLine(locations[i].Name);
            }
            string location = Console.ReadLine()!;
            location = _employeeValidation.ValidateLocation(location, "Location");

            Utility.GetInput("Please Enter Employee Job Title : ");
            var roles = _dropDownOperation.GetAllRoles();
            for (int i = 0; i < roles.Count; i++)
            {
                Console.WriteLine($"{roles[i].RoleName}");
            }
            string jobTitle = Console.ReadLine()!;
            jobTitle = _employeeValidation.ValidateRole(jobTitle, "Job Title");

            Utility.GetInput("Please Enter Employee Department");
            var departments = _dropDownOperation.GetAllDepartments();
            for (int i = 0; i < departments.Count; i++)
            {
                Console.WriteLine(departments[i].Name);
            }
            string department = Console.ReadLine()!;
            department = _employeeValidation.ValidateDepartment(department, "Department");

            Utility.GetInput("Please Enter Employee Manager");
            var managers = _dropDownOperation.GetAllManagers();
            for (int i = 0; i < managers.Count; i++)
            {
                Console.WriteLine(managers[i].Name);
            }
            string manager = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(manager))
            {
                manager = _employeeValidation.ValidateManager(manager, "Manager");
            }

            Utility.GetInput("Please Enter Employee Project");
            var projects = _dropDownOperation.GetAllProjects();
            for (int i = 0; i < projects.Count; i++)
            {
                Console.WriteLine(projects[i].Name);
            }
            string project = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(project))
            {
                project = _employeeValidation.ValidateProject(project, "Project");
            }

            _employeeOperation.Add(_employeeOperation.StoreData(employeeId, firstName, lastName, dateOfBirth, email, joinDate, location, jobTitle, department, manager, project));
            Console.WriteLine("Successfully Added");
            Console.WriteLine();
        }

        public void GetAllEmployees()
        {
            var displayData = _employeeOperation.GetAllEmployees();
            for (int i = 0; i < displayData.Count; i++)
            {
                var currentEmployee = displayData[i];
                Console.WriteLine("EmpNo : " + currentEmployee.Uid);
                Console.WriteLine("FullName : " + currentEmployee.FirstName + " " + currentEmployee.LastName);
                Console.WriteLine("JobTitle : " + currentEmployee.JobTitle);
                Console.WriteLine("Department : " + currentEmployee.Department);
                Console.WriteLine("Location : " + currentEmployee.Location);
                Console.WriteLine("JoinDate : " + currentEmployee.JoinDate);
                Console.WriteLine("Manager : " + currentEmployee.Manager);
                Console.WriteLine("Project : " + currentEmployee.Project);
                Console.WriteLine();
            }
        }
        public void GetEmployee()
        {
            Utility.GetInput("Please Enter Employee Id : ");
            string empId = Console.ReadLine()!;

            var displayData = _employeeOperation.GetEmployee(empId);
            int employeeIndex = -1;
            if (displayData.Count == 0)
            {
                Console.WriteLine("No data found in the file.");
            }
            else
            {
                for (int i = 0; i < displayData.Count; i++)
                {
                    if (empId.ToLower() == displayData[i].Uid.ToLower())
                    {
                        employeeIndex = i;
                        break;
                    }
                }
                if (employeeIndex > -1)
                {
                    Console.WriteLine("EmpNo : " + displayData[employeeIndex].Uid);
                    Console.WriteLine("FullName : " + displayData[employeeIndex].FirstName + " " + displayData[employeeIndex].LastName);
                    Console.WriteLine("JobTitle : " + displayData[employeeIndex].JobTitle);
                    Console.WriteLine("Department : " + displayData[employeeIndex].Department);
                    Console.WriteLine("Location : " + displayData[employeeIndex].Location);
                    Console.WriteLine("JoinDate : " + displayData[employeeIndex].JoinDate);
                    Console.WriteLine("Manager : " + displayData[employeeIndex].Manager);
                    Console.WriteLine("Project : " + displayData[employeeIndex].Project);
                    Console.WriteLine();
                }
                else if (employeeIndex == -1)
                {
                    Console.WriteLine("Please Enter Valid Employee Id : ");
                }
            }
        }

        public void Update()
        {
            Utility.GetInput("Please Enter Employee Id: ");
            string empId = Console.ReadLine()!;
            var employees = _employeeOperation.GetEmployee(empId);
            int validEmployee = 0;
            if (employees.Any())
            {
                while (validEmployee == 0)
                {
                    for (int i = 0; i < employees.Count; i++)
                    {
                        if (empId.ToLower() == employees[i].Uid.ToLower())
                        {
                            int employeeIndex = i;

                            validEmployee = 1;
                            break;
                        }
                    }
                    if (validEmployee == 0)
                    {
                        Console.WriteLine("Please enter a valid employee id : ");
                        empId = Console.ReadLine()!;
                        Console.WriteLine();
                    }
                }

                var selectedEmployee = employees.SingleOrDefault();
                Console.WriteLine("FullName : " + selectedEmployee.FirstName + " " + selectedEmployee.LastName);
                Console.WriteLine("JobTitle : " + selectedEmployee.JobTitle);
                Console.WriteLine("Department : " + selectedEmployee.Department);
                Console.WriteLine("Location : " + selectedEmployee.Location);
                Console.WriteLine("JoinDate : " + selectedEmployee.JoinDate);
                Console.WriteLine("Manager : " + selectedEmployee.Manager);
                Console.WriteLine("Project : " + selectedEmployee.Project);
                DateTime currentDate = DateTime.Now;
                Console.WriteLine("Which of the following field you want to edit : ");
                Console.WriteLine("1.First Name\n2.Last Name\n3.Date Of Birth\n4.Email\n5.Phone Number\n6.Joining Date\n7.Location\n8.Job Title\n9.Department\n10.Manager\n11.Project\n12.Go Back\n");
                var chooseField = (EditFieldEnum)int.Parse(Console.ReadLine()!);
                switch (chooseField)
                {
                    case EditFieldEnum.firstName:
                        Utility.GetInput("FirstName");
                        selectedEmployee.FirstName = Console.ReadLine()!;
                        selectedEmployee.FirstName = _employeeValidation.ValidateName(selectedEmployee.FirstName, "First Name");
                        break;
                    case EditFieldEnum.lastName:
                        Utility.GetInput("Last Name");
                        selectedEmployee.LastName = Console.ReadLine()!;
                        selectedEmployee.LastName = _employeeValidation.ValidateName(selectedEmployee.LastName, "Last Name");
                        break;
                    case EditFieldEnum.dateOfBirth:
                        Utility.GetInput("Date Of Birth");
                        string dateOfBirthString = Console.ReadLine()!;
                        DateTime dateOfBirth;
                        bool isValidDate = DateTime.TryParse(dateOfBirthString, out dateOfBirth);
                        if (!string.IsNullOrEmpty(dateOfBirthString))
                        {
                            if (!isValidDate || currentDate < dateOfBirth)
                            {
                                dateOfBirth = _employeeValidation.ValidateDate(isValidDate, dateOfBirth, currentDate);
                            }
                        }
                        selectedEmployee.DateOfBirth = dateOfBirth;
                        break;
                    case EditFieldEnum.email:
                        Utility.GetInput("Email");
                        selectedEmployee.Email = Console.ReadLine()!;
                        selectedEmployee.Email = _employeeValidation.ValidateEmail(selectedEmployee.Email);
                        break;
                    case EditFieldEnum.phone:
                        Utility.GetInput("Phone Number");
                        selectedEmployee.MobileNumber = Console.ReadLine()!;
                        if (!string.IsNullOrEmpty(selectedEmployee.MobileNumber))
                        {
                            selectedEmployee.MobileNumber = _employeeValidation.ValidateMobileNumber(selectedEmployee.MobileNumber);
                        }
                        break;
                    case EditFieldEnum.joinDate:
                        Utility.GetInput("Joining Date");
                        string joinDateString = Console.ReadLine()!;
                        DateTime joinDate;
                        bool isValidJoinDate = DateTime.TryParse(joinDateString, out joinDate);
                        if (!isValidJoinDate || selectedEmployee.DateOfBirth > joinDate)
                        {
                            joinDate = _employeeValidation.ValidateJoinDate(isValidJoinDate, joinDate, selectedEmployee.DateOfBirth);
                        }
                        selectedEmployee.JoinDate = joinDate;
                        break;
                    case EditFieldEnum.location:
                        Utility.GetInput("Location");
                        selectedEmployee.Location = Console.ReadLine()!;
                        selectedEmployee.Location = _employeeValidation.ValidateLocation(selectedEmployee.Location, "Location");
                        break;
                    case EditFieldEnum.jobTitle:
                        Utility.GetInput("Job Title");
                        selectedEmployee.JobTitle = Console.ReadLine()!;
                        selectedEmployee.JobTitle = _employeeValidation.ValidateRole(selectedEmployee.JobTitle, "Job Title");
                        break;
                    case EditFieldEnum.department:
                        Utility.GetInput("Department");
                        selectedEmployee.Department = Console.ReadLine()!;
                        selectedEmployee.Department = _employeeValidation.ValidateDepartment(selectedEmployee.Department, "Department");
                        break;
                    case EditFieldEnum.manager:
                        Utility.GetInput("Manager");
                        selectedEmployee.Manager = Console.ReadLine()!;
                        if (!string.IsNullOrEmpty(selectedEmployee.Manager))
                        {
                            selectedEmployee.Manager = _employeeValidation.ValidateManager(selectedEmployee.Manager, "Manager");
                        }
                        break;
                    case EditFieldEnum.project:
                        Utility.GetInput("Project");
                        selectedEmployee.Project = Console.ReadLine()!;
                        if (!string.IsNullOrEmpty(selectedEmployee.Project))
                        {
                            selectedEmployee.Project = _employeeValidation.ValidateProject(selectedEmployee.Project, "Project");
                        }
                        break;
                    case EditFieldEnum.goBack:
                        break;
                    default:
                        Console.WriteLine("Please choose right option...");
                        break;
                }
                _employeeOperation.Update(selectedEmployee);
            }
        }

        public void Delete()
        {
            Utility.GetInput("Please Enter Employee Id : ");
            var empId = Console.ReadLine()!;
            _employeeOperation.Delete(empId);
        }
    }
}
