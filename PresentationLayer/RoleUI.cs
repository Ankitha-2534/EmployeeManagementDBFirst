﻿using BusinessLogicLayer.Interfaces;
using InfrastructureLayer;
using PresentationLayer.Interfaces;
using PresentationServiceLayer.Interfaces;

namespace PresentationLayer
{
    public class RoleUI : IRoleUI
    {
        private readonly IRoleOperation _roleoperation;
        private readonly IRoleValidation _roleValidation;
        private readonly IRenderOptionsOperation _renderOptionsOperation;

        public RoleUI(IRoleOperation roleoperation, IRoleValidation roleValidation, IRenderOptionsOperation dropDownOperation)
        {
            _roleoperation = roleoperation;
            _roleValidation = roleValidation;
            _renderOptionsOperation = dropDownOperation;
        }

        public void Add()
        {
            Utility.GetInput("Please Enter Role Name");
            string roleName = Console.ReadLine()!;
            roleName = _roleValidation.Validation(roleName, "Role Name");

            Utility.GetInput("Please Enter Location");
            var locations = _renderOptionsOperation.GetAllLocations();
            for (int i = 0; i < locations.Count; i++)
            {
                Console.WriteLine(locations[i].Name);
            }
            string location = Console.ReadLine()!;
            location = _roleValidation.ValidateLocation(location, "Location");

            Utility.GetInput("Please Enter Department");
            var departments = _renderOptionsOperation.GetAllDepartments(location);
            for (int i = 0; i < departments.Count; i++)
            {
                Console.WriteLine(departments[i].Name);
            }
            string department = Console.ReadLine()!;
            department = _roleValidation.ValidateDepartment(department, "Department", location);
            Utility.GetInput("Please Enter Role Description");
            string description = Console.ReadLine()!;

            
            _roleoperation.Add(_roleoperation.StoreData(roleName, department, description, location));
            Console.WriteLine("Successfully Added");
        }

        public void GetAllRoles()
        {
            var roles = _roleoperation.GetAllRoles();
            for (int i = 0; i < roles.Count; i++)
            {
                var currentRole = roles[i];
                Console.WriteLine("Role Name : " + currentRole.RoleName);
                var departmentList = _renderOptionsOperation?.GetDepartmentById((int)currentRole.DepartmentId!);
                Console.WriteLine("Department : " + departmentList?.Name);
                Console.WriteLine("Description : " + currentRole.Description);
                var locationList = _renderOptionsOperation?.GetLocationById((int)currentRole.LocationId!);
                Console.WriteLine("Location : " + locationList?.Name);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
