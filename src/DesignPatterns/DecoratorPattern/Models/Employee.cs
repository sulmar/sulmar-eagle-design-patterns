using System;

namespace DecoratorPattern
{

    // Abstract Component
    public abstract class Employee
    {
        public TimeSpan OvertimeSalary { get; set; }
        public int NumberOfProjects { get; set; }
        public abstract decimal GetSalary();
    }

    // Abstract Decorator
    public abstract class EmployeeDecorator : Employee // Abstract Component
    {
        protected Employee employee;

        protected EmployeeDecorator(Employee employee)
        {
            this.employee = employee;

            NumberOfProjects = this.employee.NumberOfProjects;
            OvertimeSalary = this.employee.OvertimeSalary;
        }

        public override decimal GetSalary()
        {
            return employee?.GetSalary() ?? decimal.Zero;
        }
    }

    // Concrete Decorator
    public class OverTimeEmployeeDecorator : EmployeeDecorator
    {
        private readonly decimal amountPerHour;


        public OverTimeEmployeeDecorator(Employee employee, decimal amountPerHour) : base(employee)
        {
            this.amountPerHour = amountPerHour;            
        }

        public override decimal GetSalary()
        {
            return employee.GetSalary() + (decimal)employee.OvertimeSalary.TotalHours * amountPerHour;
        }
    }

    public class ProjectsEmployeeDecorator : EmployeeDecorator
    {
        private readonly decimal bonusPerProject;

        public ProjectsEmployeeDecorator(Employee employee, decimal bonusPerProject) : base(employee)
        {
            this.bonusPerProject = bonusPerProject;
        }

        public override decimal GetSalary()
        {
            return employee.GetSalary() + employee.NumberOfProjects * bonusPerProject;
        }
    }
}
