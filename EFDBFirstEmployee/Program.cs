﻿using InfrastructureLayer;
using PresentationLayer;
using BusinessLogicLayer;
using PresentationServiceLayer;
using DataAccessLayer;
using DomainModelLayer.Models;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using PresentationLayer.Interfaces;
using PresentationServiceLayer.Interfaces;

namespace EFDBFirstEmployee
{
    public static class Program
    {
        private static readonly IDropDownOperation _dropDownOperation;
        private static readonly IDropDown _dropDown;
        private static readonly IDataHandler _dataHandler;
        private static readonly EmployeeManagementContext _context;
        private static readonly IEmployeeRepository _employeeRepo;
        private static readonly IRoleRepository _roleRepository;
        private static readonly IEmployeeOperation _employeeOperation;
        private static readonly IEmployeeValidation _employeeValidation;
        private static readonly IEmployeeUI _employeeUi;
        private static readonly IRoleOperation _roleOperation;
        private static readonly IRoleValidation _roleValidation;
        private static readonly IRoleUI _roleUi;

        static Program()
        {
            _context = new EmployeeManagementContext();
            _dropDown = new DropDown(_context);
            _dropDownOperation = new DropDownOperation(_dropDown);
            _dataHandler = new DataHandler(_dropDown);
            _employeeRepo = new EmployeeRepository(_dataHandler,_dropDown);
            _employeeValidation = new EmployeeValidation(_dropDownOperation);
            _employeeOperation = new EmployeeOperation(_employeeRepo);
            _roleValidation = new RoleValidation(_dropDownOperation);
            _employeeUi = new EmployeeUI(_employeeValidation,_employeeOperation, _dropDownOperation);
            _roleRepository = new RoleRepository(_context);
            _roleOperation = new RoleOperation(_roleRepository,_dropDown);
            _roleUi = new RoleUI(_roleOperation!, _roleValidation!,_dropDownOperation); 
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please choose an option from given below options by entering value");
            Console.WriteLine("1.Employee Management\n2.Role Management\n3.Exit\n");
            string userInput = Console.ReadLine()!;
            if (int.TryParse(userInput, out _))
            {
                while (userInput == "1" || userInput == "2")
                {
                    if (userInput == "1")
                    {
                        Console.WriteLine("Welcome to Employee Management");
                        Console.WriteLine("Please choose an option from given below by entering value");
                        Console.WriteLine("1.Add Employee\n2.Display all\n3.Display one\n4.Edit employee\n5.Delete employee\n6.Go Back\n");
                        var option = (ChooseFieldEmployeeEnum)int.Parse(Console.ReadLine()!);
                        switch (option)
                        {
                            case ChooseFieldEmployeeEnum.addDetails:
                                _employeeUi.Add();
                                break;
                            case ChooseFieldEmployeeEnum.displayAllEmp:
                                _employeeUi.GetAllEmployees();
                                break;
                            case ChooseFieldEmployeeEnum.displaySearch:
                                _employeeUi.GetEmployee();
                                break;
                            case ChooseFieldEmployeeEnum.editEmployee:
                                _employeeUi.Update();
                                break;
                            case ChooseFieldEmployeeEnum.removeEmployee:
                                _employeeUi.Delete();
                                break;
                            case ChooseFieldEmployeeEnum.goBack:
                                userInput = "0";
                                break;
                            default:
                                Console.WriteLine("Please choose right option");
                                break;
                        }
                    }
                    else if (userInput == "2")
                    {
                        Console.WriteLine("Welcome to Role Management\nPlease choose an option from given below by entering value");
                        Console.WriteLine("1.Add Role\n2.Display all\n3.Go Back\n");
                        var option = (ChooseFieldRoleEnum)int.Parse(Console.ReadLine()!);
                        switch (option)
                        {
                            case ChooseFieldRoleEnum.addRole:
                                _roleUi.Add();
                                break;
                            case ChooseFieldRoleEnum.roleData:
                                _roleUi.GetAllRoles();
                                break;
                            case ChooseFieldRoleEnum.goBack:
                                userInput = "0";
                                break;
                            default:
                                Console.WriteLine("Please choose right option");
                                break;

                        }
                    }
                }
                if (userInput == "3")
                {
                    Console.WriteLine("You are exited");
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                }
                if (int.Parse(userInput) >= 4 || userInput == "0")
                {
                    Console.WriteLine("Please choose correct option");
                    Main(args);
                }
            }
            else
            {
                Console.WriteLine("Please enter a integer value");
                Main(args);
            }
            return;
        }
    }
}

