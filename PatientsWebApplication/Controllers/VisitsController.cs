using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PatientsWebApplication.Data;
using PatientsWebApplication.Models;

namespace PatientsWebApplication.Controllers
{
    public class VisitsController : Controller
    {
        private readonly PatientContext _context;
        private readonly List<Object> PatientsItemsList;
        private readonly List<Object> DoctorsItemsList;

        public VisitsController(PatientContext context)
        {
            _context = context;
            PatientsItemsList = new List<object>();
            foreach (var p in _context.Patients)
            {
                PatientsItemsList.Add(new { Text = p.FirstName + " " + p.LastName, Value = p.ID });
            }

            DoctorsItemsList = new List<object>();
            foreach (var p in _context.Doctors)
            {
                DoctorsItemsList.Add(new { Text = p.FirstName + " " + p.LastName, Value = p.DoctorID });
            }
        }

        // GET: Visits
        public async Task<IActionResult> Index()
        {
            var patientContext = _context.Visits.Include(v => v.Diagnosis).Include(v => v.Doctor).Include(v => v.Patient);
            return View(await patientContext.ToListAsync());
        }

        // GET: Visits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visit = await _context.Visits
                .Include(v => v.Diagnosis)
                .Include(v => v.Doctor)
                .Include(v => v.Patient)
                .FirstOrDefaultAsync(m => m.VisitID == id);
            if (visit == null)
            {
                return NotFound();
            }

            return View(visit);
        }

        // GET: Visits/Create
        public IActionResult Create()
        {
            ViewData["DiagnosisID"] = new SelectList(_context.Diagnoses, "DiagnosisID", "Name");
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "FirstName", "LastName");
            ViewData["PatientID"] = new SelectList(_context.Patients, "ID", "FirstName");
            ViewBag.PatientsItemsList = PatientsItemsList;
            ViewBag.DoctorsItemsList = DoctorsItemsList;
            return View();
        }

        // POST: Visits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VisitID,PatientID,DoctorID,VisitDateTime,DiagnosisID")] Visit visit)
        {
            visit.Doctor = _context.Doctors.ToList().Find(d => d.DoctorID == visit.DoctorID);
            visit.Patient = _context.Patients.ToList().Find(p => p.ID == visit.PatientID);
            visit.Diagnosis = _context.Diagnoses.ToList().Find(d => d.DiagnosisID == visit.PatientID);

            if (ModelState.IsValid)
            {
                _context.Add(visit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiagnosisID"] = new SelectList(_context.Diagnoses, "DiagnosisID", "Name", visit.DiagnosisID);
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "FirstName", visit.DoctorID);
            ViewData["PatientID"] = new SelectList(_context.Patients, "ID", "FirstName", visit.PatientID);
            ViewBag.PatientsItemsList = PatientsItemsList;
            ViewBag.DoctorsItemsList = DoctorsItemsList;
            return View(visit);
        }

        // GET: Visits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visit = await _context.Visits.FindAsync(id);
            if (visit == null)
            {
                return NotFound();
            }
            ViewData["DiagnosisID"] = new SelectList(_context.Diagnoses, "DiagnosisID", "Name", visit.DiagnosisID);
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "FirstName", visit.DoctorID);
            ViewData["PatientID"] = new SelectList(_context.Patients, "ID", "FirstName", visit.PatientID);
            ViewBag.PatientsItemsList = PatientsItemsList;
            ViewBag.DoctorsItemsList = DoctorsItemsList;
            return View(visit);
        }

        // POST: Visits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VisitID,PatientID,DoctorID,VisitDateTime,DiagnosisID")] Visit visit)
        {
            if (id != visit.VisitID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitExists(visit.VisitID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiagnosisID"] = new SelectList(_context.Diagnoses, "DiagnosisID", "Name", visit.DiagnosisID);
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "FirstName", visit.DoctorID);
            ViewData["PatientID"] = new SelectList(_context.Patients, "ID", "FirstName", visit.PatientID);
            ViewBag.PatientsItemsList = PatientsItemsList;
            ViewBag.DoctorsItemsList = DoctorsItemsList;
            return View(visit);
        }

        // GET: Visits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visit = await _context.Visits
                .Include(v => v.Diagnosis)
                .Include(v => v.Doctor)
                .Include(v => v.Patient)
                .FirstOrDefaultAsync(m => m.VisitID == id);
            if (visit == null)
            {
                return NotFound();
            }

            return View(visit);
        }

        // POST: Visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visit = await _context.Visits.FindAsync(id);
            _context.Visits.Remove(visit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitExists(int id)
        {
            return _context.Visits.Any(e => e.VisitID == id);
        }
    }
}
