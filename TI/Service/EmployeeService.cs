using TI.DB;
using TI.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TI.Service
{
    public class EmployeeService
    {
        private DataContext dataContext = new DataContext();

        public void addEmployee(Utilizator utilizator)
        {
            calculateReadOnlyAttribs(utilizator);
            dataContext.Angajati.Add(utilizator);
            dataContext.SaveChanges();
        }

        public List<Utilizator> getEmployees()
        {
            List<Utilizator> employees = dataContext.Angajati
                                                    .ToList<Utilizator>();
            return employees;
        }

        public List<Utilizator> searchEmployees(string name) => dataContext.Angajati.Where(empl => empl.Nume.Contains(name) || 
                                                                                                                     empl.Prenume.Contains(name) ||
                                                                                                                     name.Contains(empl.Nume) ||
                                                                                                                     name.Contains(empl.Prenume)).ToList<Utilizator>();

        public void calculateReadOnlyAttribs(Utilizator utilizator)
        {
            utilizator.TotalBrut = utilizator.SalarBaza * (1 + utilizator.Spor / 100) + utilizator.PremiiBrute;

            utilizator.CAS = utilizator.TotalBrut * getProcentualVariableByName("CAS");
            utilizator.CASS = utilizator.TotalBrut * getProcentualVariableByName("CASS");
            utilizator.BrutImpozitabil = utilizator.TotalBrut - utilizator.CAS - utilizator.CASS;
            utilizator.Impozit = utilizator.BrutImpozitabil * getProcentualVariableByName("IMPOZIT");

            utilizator.Virat = utilizator.TotalBrut - utilizator.Impozit - utilizator.CAS - utilizator.CASS - utilizator.Retineri;
        }

        private double getProcentualVariableByName(string name) => Convert.ToDouble((from impozit in dataContext.Impozite
                                                                                    where impozit.NumeVariabila == name
                                                                                    select impozit.ProcentProp).FirstOrDefault());
    }
}