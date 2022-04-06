using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)] // transforma em link para o email
        public string Email { get; set; }

        [Display(Name = "Birth Date")] // customizando o que vai aparecer no display
        [DataType(DataType.Date)] // transformando data para tirar a necessidade da hora e minutos
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] // modificando formatação da data
        public DateTime BirthDate { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")] // formatando casas decimais do salário base
        public double BaseSalary { get; set; }
        public Department Department { get; set; }

        [Display(Name = "Department Id")]
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime inital, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= inital && sr.Date <= final).Sum(sr => sr.Amount); // cria uma nova lista a partir dos datetimes recebidos e resulta na soma das vendas
        }
    }
}
