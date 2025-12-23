using DAL.Entities;
using DAL.Repositories;
using System.Linq;
using Xunit;

public class EmployeeRepositoryTests
{
    [Fact]
    public void AddEmployee_AddsEmployeeToList()
    {
        // Arrange
        var repository = new EmployeeRepository();
        var employee = new Employee
        {
            Id = 1,
            Name = "Дар'я",
            Position = "Менеджер"
        };

        // Act
        repository.AddEmployee(employee);
        var result = repository.GetAllEmployees();

        // Assert
        Assert.Single(result);
        Assert.Equal("Дар'я", result.First().Name);
    }

    [Fact]
    public void GetEmployeeByName_ReturnsCorrectEmployee()
    {
        // Arrange
        var repository = new EmployeeRepository();
        repository.AddEmployee(new Employee
        {
            Id = 1,
            Name = "Дар'я",
            Position = "Менеджер"
        });

        // Act
        var employee = repository.GetEmployeeByName("Дар'я");

        // Assert
        Assert.NotNull(employee);
        Assert.Equal("Менеджер", employee.Position);
    }

    [Fact]
    public void GetAllPositions_ReturnsDistinctPositions()
    {
        // Arrange
        var repository = new EmployeeRepository();
        repository.AddEmployee(new Employee { Id = 1, Name = "A", Position = "Manager" });
        repository.AddEmployee(new Employee { Id = 2, Name = "B", Position = "Manager" });
        repository.AddEmployee(new Employee { Id = 3, Name = "C", Position = "QA" });

        // Act
        var positions = repository.GetAllPositions();

        // Assert
        Assert.Equal(2, positions.Count);
        Assert.Contains("Manager", positions);
        Assert.Contains("QA", positions);
    }

    [Fact]
    public void DeleteEmployee_RemovesEmployee()
    {
        // Arrange
        var repository = new EmployeeRepository();
        repository.AddEmployee(new Employee
        {
            Id = 1,
            Name = "Дар'я",
            Position = "Менеджер"
        });

        // Act
        repository.DeleteEmployee(1);

        // Assert
        Assert.Empty(repository.GetAllEmployees());
    }
}
