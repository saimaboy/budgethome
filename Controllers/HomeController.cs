using BudgetHomeDesign.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BudgetHomeDesign.Controllers
{
    public class HomeController : Controller
    {
        private DbModel db = new DbModel();

        public ActionResult Index()
        {
            var allPlans = db.Plans.ToList();
            return View(allPlans);
        }

        public ActionResult Plans()
        {
            //var categorizedPlans = db.Plans.GroupBy(plan => plan.Steps).ToList();
            //ViewBag.CategorizedPlans = categorizedPlans;
            ViewBag.MaterialModerns = db.MaterialModerns.ToList();
            ViewBag.MaterialClassics = db.MaterialClassics.ToList();
            ViewBag.FirstFloorClassic = db.FirstFloorclassicals.ToList();
            ViewBag.FirstFloorModern = db.FirstFloorModerns.ToList();
            ViewBag.FoundationOnly = db.FoundationOnlies.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult FilterResults(int? Price, int? People, decimal? Size, int? Floors)
        {

            ViewBag.People = People;
            ViewBag.Size = Size;
            ViewBag.Floors = Floors;
            ViewBag.Price = Price;

            ViewBag.MaterialModerns = db.MaterialModerns.ToList();
            ViewBag.MaterialClassics = db.MaterialClassics.ToList();
            ViewBag.FirstFloorClassic = db.FirstFloorclassicals.ToList();
            ViewBag.FirstFloorModern = db.FirstFloorModerns.ToList();
            ViewBag.FoundationOnly = db.FoundationOnlies.ToList();

            var query = db.Plans.AsQueryable();

           // var query2 = db.FirstFloorclassicals.AsQueryable();

            if (Price.HasValue)
            {
                switch (Price.Value)
                {
                    case 1:
                        query = query.Where(plan => plan.Price > 5 && plan.Price <= 12);
                        break;
                    case 2:
                        query = query.Where(plan => plan.Price > 12 && plan.Price <= 18);
                        break;
                    case 3:
                        query = query.Where(plan => plan.Price > 18 && plan.Price <= 25);
                        break;
                    case 4:
                        query = query.Where(plan => plan.Price > 25 && plan.Price <= 35);
                        break;
                    case 5:
                        query = query.Where(plan => plan.Price > 35);
                        break;

                }
            }

               // query = query.Where(plan => plan.Price >= MinPrice.Value);
            //if (MaxPrice.HasValue)
            //    query = query.Where(plan => plan.Price <= MaxPrice.Value);
            if (People.HasValue)
                query = query.Where(plan => plan.People + 3 >= People.Value && plan.People - 3 <= People.Value);
            if (Size.HasValue)
                query = query.Where(plan => plan.Size + 20 >= Size.Value && plan.Size - 20 <= Size.Value);
            if (Floors.HasValue)
                query = query.Where(plan => plan.Floors == Floors.Value);

            var filteredPlans = query.ToList();

            //var categorizedPlans = db.Plans.GroupBy(plan => plan.Steps).ToList();
            //ViewBag.CategorizedPlans = categorizedPlans;

            //ViewBag.filteredCount = filteredPlans.Count.ToString() ?? "0";
            //return View("Plans", filteredPlans);

            var filteredPlanIds = filteredPlans.Select(plan => plan.Id); 
            var allPlans = db.Plans.ToList(); 

            var categorizedPlanGroups = allPlans
                .Where(plan => filteredPlanIds.Contains(plan.Id))
                .GroupBy(plan => plan.Steps)
                .Select(group => new CategorizedPlanGroup
                {
                    StepName = GetStepName(group.Key),
                    Plans = group.ToList()
                })
                .ToList();

            ViewBag.filteredCount = filteredPlans.Count.ToString() ?? "0";
            return View("Plans", categorizedPlanGroups);
        }

        [HttpGet] 
        public ActionResult FilterResultsEdit(int? Price, int? People, int? Size, int? Floors, int? Steps)
        {
            var query = db.Plans.AsQueryable();

            ViewBag.People = People;
            ViewBag.Size = Size;
            ViewBag.Floors = Floors;
            ViewBag.Price = Price;
            ViewBag.Steps = Steps;

            ViewBag.MaterialModerns = db.MaterialModerns.ToList();
            ViewBag.MaterialClassics = db.MaterialClassics.ToList();
            ViewBag.FirstFloorClassic = db.FirstFloorclassicals.ToList();
            ViewBag.FirstFloorModern = db.FirstFloorModerns.ToList();
            ViewBag.FoundationOnly = db.FoundationOnlies.ToList();

            if (Price.HasValue)
            {
                switch (Price.Value)
                {
                    case 1:
                        query = query.Where(plan => plan.Price > 5 && plan.Price <= 12);
                        break;
                    case 2:
                        query = query.Where(plan => plan.Price > 12 && plan.Price <= 18);
                        break;
                    case 3:
                        query = query.Where(plan => plan.Price > 18 && plan.Price <= 25);
                        break;
                    case 4:
                        query = query.Where(plan => plan.Price > 25 && plan.Price <= 35);
                        break;
                    case 5:
                        query = query.Where(plan => plan.Price > 35);
                        break;

                }
            }
            if (People.HasValue)
                query = query.Where(plan => plan.People + 3 >= People.Value && plan.People - 3 <= People.Value);
            if (Size.HasValue)
                query = query.Where(plan => plan.Size + 20 >= Size.Value && plan.Size - 20 <= Size.Value);
            if(Floors.HasValue)
                query = query.Where(plan => plan.Floors == Floors.Value);
            if (Steps.HasValue)
                query = query.Where(plan => plan.Steps == Steps.Value);

            var filteredPlans = query.ToList();
            var filteredPlanIds = filteredPlans.Select(plan => plan.Id);
            var allPlans = db.Plans.ToList();

            var categorizedPlanGroups = allPlans
                .Where(plan => filteredPlanIds.Contains(plan.Id))
                .GroupBy(plan => plan.Steps)
                .Select(group => new CategorizedPlanGroup
                {
                    StepName = GetStepName(group.Key),
                    Plans = group.ToList()
                })
                .ToList();

            ViewBag.filteredCount = filteredPlans.Count.ToString() ?? "0";
            return View("Plans", categorizedPlanGroups);
        }

        private string GetStepName(int? stepValue)
        {
            switch (stepValue)
            {
                case 1: return "Classic Design";
                case 2: return "Modern Design";
                case 3: return "First Floor Only (Classical)";
                case 4: return "First Floor Only (Modern)";
                case 5: return "Foundation Only";
                default: return "Unknown Step";
            }
        }
    }
}
