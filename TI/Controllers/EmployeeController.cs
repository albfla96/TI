using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TI.DB;
using TI.Models;
using TI.Service;

namespace TI.Content
{
    public class EmployeeController : Controller
    {

        DataContext dataContext = new DataContext();
        private EmployeeService employeeService = new EmployeeService();

        // GET: Employee
        public ActionResult Index()
        {
            return View(employeeService.getEmployees());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Utilizator utilizator)
        {
            employeeService.addEmployee(utilizator);

            return RedirectToAction("Create");
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            DataContext dataContext = new DataContext();

            Utilizator employee = dataContext.Angajati.Find(id);
            
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            
            Utilizator employee = dataContext.Angajati.Find(id);

            UpdateModel(employee);
            employeeService.calculateReadOnlyAttribs(employee);

            dataContext.SaveChanges();
           
            return RedirectToAction("Index", new { id = employee.NrCrt });
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            Utilizator employee = dataContext.Angajati.Find(id);

            if (employee == null)
            {
                return View("NotFound");
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            Utilizator employee = dataContext.Angajati.Find(id);

            if(employee == null)
            {
                return View("NotFound");
            }

            dataContext.Angajati.Remove(employee);
            dataContext.SaveChanges();

            return RedirectToAction("Index", new { id = employee.NrCrt });
        }

        public ActionResult Search(string name)
        {
            return View(employeeService.searchEmployees(name));
        }

        public ActionResult CreateStatDePlata()
        {
            StatDePlata reportDocument = new StatDePlata();
            List<Utilizator> employees = employeeService.getEmployees();

            var employee = (from empl in employees select empl).ToList();

            reportDocument.Load("StatDePlata.rpt");
            reportDocument.SetDataSource(employee);

            reportDocument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            reportDocument.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5,5,5,5));
            reportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA3;

            Stream stream = reportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            return File(stream, "application/pdf", "StatDePlata.pdf");
        }

        public ActionResult CreateFluturas()
        {
            Fluturas reportDocument = new Fluturas();
            List<Utilizator> employees = employeeService.getEmployees();

            var employee = (from empl in employees select empl).ToList();

            reportDocument.Load("Fluturas.rpt");
            reportDocument.SetDataSource(employee);

            reportDocument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            reportDocument.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            reportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA3;

            Stream stream = reportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            return File(stream, "application/pdf", "Fluturas.pdf");
        }
    }
}
