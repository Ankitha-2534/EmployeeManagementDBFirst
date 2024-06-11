using BusinessLogicLayer.Interfaces;
using DomainModelLayer.Models;
using InfrastructureLayer;
using PresentationLayer.Interfaces;
using PresentationServiceLayer.Interfaces;


namespace PresentationLayer
{
    public class EmployeeUI : IEmployeeUI
    {
        private readonly IEmployeeValidation _employeeValidation;
        private readonly IEmployeeOperation _employeeOperation;
        private readonly IRenderOptionsOperation _renderOptionsOperation;

        public EmployeeUI(IEmployeeValidation employeeValidation, IEmployeeOperation employeeOperation, IRenderOptionsOperation renderOptionsOperation)
        {
            _employeeValidation = employeeValidation;
            _employeeOperation = employeeOperation;
            _renderOptionsOperation = renderOptionsOperation;
        }
        public void Add()
        {
            //Employee Id
            Utility.GetInput("Please Enter Employee Id(TZ0000) : ");
            string employeeId = string.Empty;
            bool isValid = false;
            while (isValid == false)
            {
                try
                {
                    employeeId = Console.ReadLine()!;
                    employeeId = _employeeValidation.ValidateEmployeeId(employeeId);
                    isValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Data");
                    Console.WriteLine("Please Enter Valid Employee Id : ");
                }
            }
            
            //Employee FirstName
            Utility.GetInput("Please Enter Employee FirstName : ");
            string firstName = string.Empty;
            bool isFirstName = false;
            while(isFirstName == false)
            {
                try
                {
                    firstName = Console.ReadLine()!;
                    firstName = _employeeValidation.ValidateName(firstName);
                    isFirstName = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Data");
                    Console.WriteLine("Please Enter First Name that should contain only Alphabets : ");
                }
            }
            
            //Employee LastName
            Utility.GetInput("Please Enter Employee LastName : ");
            string lastName = string.Empty;
            bool isLastName = false;
            while (isLastName == false)
            {
                try
                {
                    lastName = Console.ReadLine()!;
                    lastName = _employeeValidation.ValidateName(lastName);
                    isLastName = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Data");
                    Console.WriteLine("Please Enter Last Name that should contain only Alphabets : ");
                }
            }

            //Employee DOB
            Utility.GetInput("Please Enter Employee DateOfBirth : ");
            bool isDateValid=false;
            string dateOfBirthString = string.Empty;
            DateTime currentDate = DateTime.Now;
            DateTime dateOfBirth = new DateTime(1900,01,01);
            while (isDateValid == false)
            {
                try
                {
                    dateOfBirthString = Console.ReadLine();
                    bool isValidDate = DateTime.TryParse(dateOfBirthString, out dateOfBirth);
                    if (!string.IsNullOrEmpty(dateOfBirthString))
                    {
                        if (!isValidDate || currentDate < dateOfBirth)
                        {
                            dateOfBirth = _employeeValidation.ValidateDate(isValidDate, dateOfBirth, currentDate);
                        }
                    }
                    isDateValid = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("InValid Date");
                    Console.WriteLine("Please Enter Valid Date : ");
                }
            }            
            
            //Employee Email
            Utility.GetInput("Please Enter Employee Email : ");
            string email = string.Empty;
            bool isEmailValid = false;
            while(isEmailValid == false)
            {
                try
                {
                    email = Console.ReadLine();
                    email = _employeeValidation.ValidateEmail(email);
                    isEmailValid = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Invalid Data");
                    Console.WriteLine("Please Enter Valid Email : ");
                }
            }

            //Employee MobileNumber
            Utility.GetInput("Please Enter Employee Phone Number : ");
            string phone = string.Empty;
            bool isMobileNumber = false;
            while(isMobileNumber == false)
            {
                try
                {
                    phone = Console.ReadLine()!;
                    if (!string.IsNullOrEmpty(phone))
                    {
                        phone = _employeeValidation.ValidateMobileNumber(phone);
                    }
                    isMobileNumber = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Invalid Data");
                    Console.WriteLine("Please Enter valid Mobile Number : ");
                }
            }

            //Employee Join Date
            Utility.GetInput("Please Enter Employee Join Date : ");
            string joinDateString = string.Empty;
            DateTime joinDate = DateTime.Now;
            bool isJoinDateValid = false;
            while (isJoinDateValid == false)
            {
                try
                {
                    joinDateString = Console.ReadLine()!;
                    bool isValidJoinDate = DateTime.TryParse(joinDateString, out joinDate);
                    if (!isValidJoinDate || dateOfBirth > joinDate)
                    {
                        joinDate = _employeeValidation.ValidateJoinDate(isValidJoinDate, joinDate, dateOfBirth);
                    }
                    isJoinDateValid = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Invalid Data");
                    Console.WriteLine("Please Enter Valid Join Date : ");
                }
            }

            //Employee Location
            Utility.GetInput("Please Enter Employee Location : ");
            var locations = _renderOptionsOperation.GetAllLocations();
            for (int i = 0; i < locations.Count; i++)
            {
                Console.WriteLine(locations[i].Name);
            }
            bool isLocation = false;
            string location = string.Empty;
            while (isLocation == false)
            {
                try
                {
                    location = Console.ReadLine()!;
                    location = _employeeValidation.ValidateLocation(location);
                    isLocation = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("InValid Data");
                    Console.WriteLine("Please Enter Location from given Options : ");
                }
            }
            
            //Employee Department
            Utility.GetInput("Please Enter Employee Department");
            var departments = _renderOptionsOperation.GetAllDepartments(location);
            for (int i = 0; i < departments.Count; i++)
            {
                Console.WriteLine(departments[i].Name);
            }
            bool isDepartment = false;
            string department = string.Empty;
            while (isDepartment == false)
            {
                try
                {
                    department = Console.ReadLine()!;
                    department = _employeeValidation.ValidateDepartment(department,location);
                    isDepartment = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("InValid Data");
                    Console.WriteLine("Please Enter Location from given Options : ");
                }
            }

            //Employee JobTitle
            Utility.GetInput("Please Enter Employee Job Title : ");
            var roles = _renderOptionsOperation.GetAllRoles(department,location);
            for (int i = 0; i < roles.Count; i++)
            {
                Console.WriteLine($"{roles[i].RoleName}");
            }
            bool isRole = false;
            string jobTitle = string.Empty;
            while(isRole == false)
            {
                try
                {
                    jobTitle = Console.ReadLine()!;
                    jobTitle = _employeeValidation.ValidateRole(jobTitle, department, location);
                    isRole = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Invalid Data");
                    Console.WriteLine("Please Enter Valid Role from given options : ");
                }
            }

            //Employee Manager
            Utility.GetInput("Please Enter Employee Manager");
            var managers = _renderOptionsOperation.GetAllManagers();
            for (int i = 0; i < managers.Count; i++)
            {
                Console.WriteLine(managers[i].Name);
            }           
            bool isManager = false;
            string manager = string.Empty;
            while (isManager == false)
            {
                try
                {
                    manager = Console.ReadLine()!;
                    if (!string.IsNullOrEmpty(manager))
                    {
                        manager = _employeeValidation.ValidateManager(manager);
                    }
                    isManager = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Data");
                    Console.WriteLine("Please Enter Valid Manager Name from given options : ");
                }
            }

            //Employee Project
            Utility.GetInput("Please Enter Employee Project");
            var projects = _renderOptionsOperation.GetAllProjects();
            for (int i = 0; i < projects.Count; i++)
            {
                Console.WriteLine(projects[i].Name);
            }
            bool isProject = false;
            string project = string.Empty;
            while (isProject == false)
            {
                try
                {
                    project = Console.ReadLine()!;
                    if (!string.IsNullOrEmpty(project))
                    {
                        project = _employeeValidation.ValidateProject(project);
                    }
                    isProject = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Data");
                    Console.WriteLine("Please Enter Valid Project Name from given options : ");
                }
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
                        selectedEmployee.FirstName = string.Empty;
                        bool isFirstName = false;
                        while (isFirstName == false)
                        {
                            try
                            {
                                selectedEmployee.FirstName = Console.ReadLine()!;
                                selectedEmployee.FirstName = _employeeValidation.ValidateName(selectedEmployee.FirstName);
                                isFirstName = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Invalid Data");
                                Console.WriteLine("Please Enter First Name that should contain only Alphabets : ");
                            }
                        }
                        break;
                    case EditFieldEnum.lastName:
                        Utility.GetInput("Last Name");
                        selectedEmployee.LastName = string.Empty;
                        bool isLastName = false;
                        while (isLastName == false)
                        {
                            try
                            {
                                selectedEmployee.LastName = Console.ReadLine()!;
                                selectedEmployee.LastName = _employeeValidation.ValidateName(selectedEmployee.LastName);
                                isLastName = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Invalid Data");
                                Console.WriteLine("Please Enter Last Name that should contain only Alphabets : ");
                            }
                        }
                        break;
                    case EditFieldEnum.dateOfBirth:
                        Utility.GetInput("Date Of Birth");
                        bool isDateValid = false;
                        string dateOfBirthString = string.Empty;
                        DateTime dateOfBirth = new DateTime(1900, 01, 01);
                        while (isDateValid == false)
                        {
                            try
                            {
                                dateOfBirthString = Console.ReadLine();
                                bool isValidDate = DateTime.TryParse(dateOfBirthString, out dateOfBirth);
                                if (!string.IsNullOrEmpty(dateOfBirthString))
                                {
                                    if (!isValidDate || currentDate < dateOfBirth)
                                    {
                                        dateOfBirth = _employeeValidation.ValidateDate(isValidDate, dateOfBirth, currentDate);
                                    }
                                }
                                isDateValid = true;
                                selectedEmployee.DateOfBirth = dateOfBirth;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("InValid Date");
                                Console.WriteLine("Please Enter Valid Date : ");
                            }
                        }
                        break;
                    case EditFieldEnum.email:
                        Utility.GetInput("Email");
                        selectedEmployee.Email = string.Empty;
                        bool isEmailValid = false;
                        while (isEmailValid == false)
                        {
                            try
                            {
                                selectedEmployee.Email = Console.ReadLine();
                                selectedEmployee.Email = _employeeValidation.ValidateEmail(selectedEmployee.Email);
                                isEmailValid = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Invalid Data");
                                Console.WriteLine("Please Enter Valid Email : ");
                            }
                        }
                        break;
                    case EditFieldEnum.phone:
                        Utility.GetInput("Phone Number");
                        selectedEmployee.MobileNumber = string.Empty;
                        bool isMobileNumber = false;
                        while (isMobileNumber == false)
                        {
                            try
                            {
                                selectedEmployee.MobileNumber = Console.ReadLine()!;
                                if (!string.IsNullOrEmpty(selectedEmployee.MobileNumber))
                                {
                                    selectedEmployee.MobileNumber = _employeeValidation.ValidateMobileNumber(selectedEmployee.MobileNumber);
                                }
                                isMobileNumber = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Invalid Data");
                                Console.WriteLine("Please Enter valid Mobile Number : ");
                            }
                        }
                        break;
                    case EditFieldEnum.joinDate:
                        Utility.GetInput("Joining Date");
                        string joinDateString = string.Empty;
                        DateTime joinDate = DateTime.Now;
                        bool isJoinDateValid = false;
                        while (isJoinDateValid == false)
                        {
                            try
                            {
                                joinDateString = Console.ReadLine()!;
                                bool isValidJoinDate = DateTime.TryParse(joinDateString, out joinDate);
                                if (!isValidJoinDate || selectedEmployee.DateOfBirth > joinDate)
                                {
                                    joinDate = _employeeValidation.ValidateJoinDate(isValidJoinDate, joinDate, selectedEmployee.DateOfBirth);
                                }
                                isJoinDateValid = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Invalid Data");
                                Console.WriteLine("Please Enter Valid Join Date : ");
                            }
                        }
                        selectedEmployee.JoinDate = joinDate;
                        break;
                    case EditFieldEnum.location:
                        Utility.GetInput("Location");
                        var locations = _renderOptionsOperation.GetAllLocations();
                        for (int i = 0; i < locations.Count; i++)
                        {
                            Console.WriteLine(locations[i].Name);
                        }
                        selectedEmployee.Location = string.Empty;
                        bool isLocation = false;
                        while (isLocation == false)
                        {
                            try
                            {
                                selectedEmployee.Location = Console.ReadLine()!;
                                selectedEmployee.Location = _employeeValidation.ValidateLocation(selectedEmployee.Location);
                                isLocation = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("InValid Data");
                                Console.WriteLine("Please Enter Location from given Options : ");
                            }
                        }
                        break;
                    case EditFieldEnum.department:
                        Utility.GetInput("Department");
                        var departments = _renderOptionsOperation.GetAllDepartments(selectedEmployee.Location);
                        for (int i = 0; i < departments.Count; i++)
                        {
                            Console.WriteLine(departments[i].Name);
                        }
                        selectedEmployee.Department = string.Empty;
                        bool isDepartment = false;
                        while (isDepartment == false)
                        {
                            try
                            {
                                selectedEmployee.Department = Console.ReadLine()!;
                                selectedEmployee.Department = _employeeValidation.ValidateDepartment(selectedEmployee.Department, selectedEmployee.Location);
                                isDepartment = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("InValid Data");
                                Console.WriteLine("Please Enter Location from given Options : ");
                            }
                        }
                        break;
                    case EditFieldEnum.jobTitle:
                        Utility.GetInput("Job Title");
                        var roles = _renderOptionsOperation.GetAllRoles(selectedEmployee.Department, selectedEmployee.Location);
                        for (int i = 0; i < roles.Count; i++)
                        {
                            Console.WriteLine($"{roles[i].RoleName}");
                        }
                        selectedEmployee.JobTitle = Console.ReadLine()!;
                        bool isRole = false;
                        while (isRole == false)
                        {
                            try
                            {
                                selectedEmployee.JobTitle = Console.ReadLine()!;
                                selectedEmployee.JobTitle = _employeeValidation.ValidateRole(selectedEmployee.JobTitle, selectedEmployee.Department, selectedEmployee.Location);
                                isRole = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Invalid Data");
                                Console.WriteLine("Please Enter Valid Role from given options : ");
                            }
                        }
                        break;                    
                    case EditFieldEnum.manager:
                        Utility.GetInput("Manager");
                        var managers = _renderOptionsOperation.GetAllManagers();
                        for (int i = 0; i < managers.Count; i++)
                        {
                            Console.WriteLine(managers[i].Name);
                        }
                        selectedEmployee.Manager = string.Empty;
                        bool isManager = false;
                        while (isManager == false)
                        {
                            try
                            {
                                selectedEmployee.Manager = Console.ReadLine()!;
                                if (!string.IsNullOrEmpty(selectedEmployee.Manager))
                                {
                                    selectedEmployee.Manager = _employeeValidation.ValidateManager(selectedEmployee.Manager);
                                }
                                isManager = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Invalid Data");
                                Console.WriteLine("Please Enter Valid Manager Name from given options : ");
                            }
                        }
                        break;
                    case EditFieldEnum.project:
                        Utility.GetInput("Project");
                        var projects = _renderOptionsOperation.GetAllProjects();
                        for (int i = 0; i < projects.Count; i++)
                        {
                            Console.WriteLine(projects[i].Name);
                        }
                        selectedEmployee.Project = string.Empty;
                        bool isProject = false;
                        while (isProject == false)
                        {
                            try
                            {
                                selectedEmployee.Project = Console.ReadLine()!;
                                if (!string.IsNullOrEmpty(selectedEmployee.Project))
                                {
                                    selectedEmployee.Project = _employeeValidation.ValidateProject(selectedEmployee.Project);
                                }
                                isProject = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Invalid Data");
                                Console.WriteLine("Please Enter Valid Project Name from given options : ");
                            }
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
