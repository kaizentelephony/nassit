using nassit.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace nassit.Controllers
{
    public class HomeController : Controller
    {
        Logs _log = new Logs();
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;
        private EnrollContext _enrollContext;

        public string logtsts = string.Empty;

        public HomeController(ILogger<HomeController> logger, IConfiguration config, EnrollContext enrollContext)
        {
            _configuration = config;
            _logger = logger;
            _enrollContext = enrollContext;
        }
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Title = "Login";


            _log.lodwrite("*************** GET Login page ***************");
            _log.lodwrite("Login action started");

            return View();
        }

        [HttpPost]
        public IActionResult Login(string User_Name, string Password)
        {
            _log.lodwrite("*************** POST Login page ***************");

            HttpContext.Session.SetString(logtsts, "loged");

            try
            {
                //var user = _enrollContext.TBL_Registration.FirstOrDefault(u => u.User_Name == User_Name && u.Password == Password);

                if (true)
                {
                    HttpContext.Session.SetString("UsName", User_Name.ToUpper());
                    _log.lodwrite(" your user name is correct ");
                    //HttpContext.Session.SetString(logouts, "login");

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "User ID or password is incorrect";
                    _log.lodwrite(" user id or password incorrect");
                    return View();
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error :" + e.Message);
                return View();
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            _log.lodwrite("*************** POST Index page ***************");

            ViewBag.Name = HttpContext.Session.GetString(logtsts);

            ViewBag.UsName = HttpContext.Session.GetString("UsName") ?? "";
            try
            {
                if (ViewBag.UsName != "" && ViewBag.Name == "loged")
                {
                    //Enrollment success and failed table show here
                    var enrollcount_success = (from enroll in _enrollContext.TBL_ENROLLMENT where enroll.VAR_ENROLL_STATUS == "Success" select enroll).Count();
                    var enrollcount_failure = (from enroll in _enrollContext.TBL_ENROLLMENT where enroll.VAR_ENROLL_STATUS == "Failed" select enroll).Count();
                    ViewBag.E_success = enrollcount_success;
                    ViewBag.E_failed = enrollcount_failure;

                    TempData["esuccess_kes"] = enrollcount_success;
                    TempData["efailed_kes"] = enrollcount_failure;
                    _log.lodwrite("Enrollment success count " + enrollcount_success);
                    _log.lodwrite("Enrollment success count " + enrollcount_failure);


                    //Verification success and failed table show here
                    var verificount_success = (from verify in _enrollContext.TBL_VERIFICATION where verify.VAR_VERIFICATION_STATUS == "SUCCESS" select verify).Count();
                    var verificount_failed = (from verify in _enrollContext.TBL_VERIFICATION where verify.VAR_VERIFICATION_STATUS == "FAILED-1" select verify).Count();
                    ViewBag.V_success = verificount_success;
                    ViewBag.V_failed = verificount_failed;

                    TempData["vsuccess_kes"] = verificount_success;
                    TempData["vfailed_kes"] = verificount_failed;
                    _log.lodwrite("Verification success count " + verificount_success);
                    _log.lodwrite("Verification success count " + verificount_failed);


                    return View("Index");
                }
                else
                {
                    _log.lodwrite(" user name and login isn't same ");
                    return RedirectToAction("Login");
                }

            }
            catch (Exception ex)
            {
                _log.lodwrite("Error : " + ex.Message);
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public IActionResult Registration(TBL_Registration newUser)
        {
            _log.lodwrite("***************** POST Registration page ********************");

            try
            {
                _enrollContext.TBL_Registration.Add(newUser);
                _enrollContext.SaveChanges();

                TempData["Title"] = "Registration";
                _log.lodwrite("Registration Success");
                TempData["SuccessMessage"] = "Registration Successful";

                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                _log.lodwrite("Registration Failed " + ex.Message.ToString());
                TempData["ErrorMessage"] = "Registration Failed ";
                return RedirectToAction("Login");

            }
        }
        [HttpGet]
        public IActionResult EntrollmentTable()
        {
            //var data = _enrollContext.GetDataByDateRange(fromDate, toDate).ToList();
            //TBL_Entrollment.where(e => e.Date_Time >= fromDate && e.Date_Time <= toDate);
            //var enrollcount_success = (from enroll in _enrollContext.TBL_Entrollment where(e => e.Date_Time >= fromDate && e.Date_Time <= toDate));
            _logger.LogInformation("**************** GET Entrollmentable *********************");
            try
            {
                ViewBag.Name = HttpContext.Session.GetString(logtsts);
                ViewBag.UsName = HttpContext.Session.GetString("UsName") ?? "";

                if (ViewBag.UsName != "" && ViewBag.Name == "loged")
                {
                    var E_table = _enrollContext.TBL_ENROLLMENT.OrderByDescending(x => x.VAR_CALLED_DATE).ToList().Where(x=>x.VAR_ENROLL_STATUS is not  null);
                    _log.lodwrite(" Entrollment table list success");
                    return View(E_table);
                }

                //ViewBag.UsName = HttpContext.Session.GetString("UsName") ?? "";
                else
                {
                    _log.lodwrite(" user name or login incorrect ");
                    return RedirectToAction("Login");
                }
            }
            catch (Exception ex)
            {
                _log.lodwrite("Error" + ex.Message);
                return RedirectToAction("Login");

            }

        }



        [HttpGet]
        public IActionResult Entrollstatus()
        {
            try
            {

                ViewBag.Name = HttpContext.Session.GetString(logtsts);
                ViewBag.UsName = HttpContext.Session.GetString("UsName") ?? "";
                if (ViewBag.UsName != "" && ViewBag.Name == "loged")
                {
                    var E_status = _enrollContext.TBL_ENROLLMENT.OrderByDescending(x=>x.VAR_CALLED_DATE).Where(v => v.VAR_ENROLL_STATUS == "Success").ToList();
                    return View(E_status);

                }
                else
                {
                    return RedirectToAction("Login");

                }

            }
            catch(Exception ex)
            {
                _log.lodwrite("Error : " + ex);

                return RedirectToAction("Login");

            }
        }

        [HttpGet]
        public IActionResult EntrollFail()
        {
            try
            {
                ViewBag.Name = HttpContext.Session.GetString(logtsts);
                ViewBag.UsName = HttpContext.Session.GetString("UsName") ?? "";
                if (ViewBag.UsName != "" && ViewBag.Name == "loged")
                {
                    var E_status = _enrollContext.TBL_ENROLLMENT.OrderByDescending(x=>x.VAR_CALLED_DATE).Where(v => v.VAR_ENROLL_STATUS == "Failed").ToList();
                    return View(E_status);

                }
                else
                {
                    return RedirectToAction("Login");

                }

            }
            catch (Exception ex)
            {
                _log.lodwrite("Error : " + ex);

                return RedirectToAction("Login");

            }
        }

        [HttpGet]
        public IActionResult VerifySuccess()
        {
            try
            {
                ViewBag.Name = HttpContext.Session.GetString(logtsts);
                ViewBag.UsName = HttpContext.Session.GetString("UsName") ?? "";
                if (ViewBag.UsName != "" && ViewBag.Name == "loged")
                {
                    _log.lodwrite("Entring VerifySuccess");
                    var v_success = _enrollContext.TBL_VERIFICATION.OrderByDescending(x=>x.VAR_CALLED_DATE).Where(v => v.VAR_VERIFICATION_STATUS == "SUCCESS").ToList();
                    return View(v_success);

                }
                else
                {
                    return RedirectToAction("Login");

                }

            }
            catch (Exception ex)
            {
                _log.lodwrite("Error : " + ex);

                return RedirectToAction("Login");

            }
        }

        [HttpGet]
        public IActionResult VerifyFail()
        {
            try
            {
                ViewBag.Name = HttpContext.Session.GetString(logtsts);
                ViewBag.UsName = HttpContext.Session.GetString("UsName") ?? "";
                if (ViewBag.UsName != "" && ViewBag.Name == "loged")
                {
                    var v_fail = _enrollContext.TBL_VERIFICATION.OrderByDescending(x=>x.VAR_CALLED_DATE).Where(v => v.VAR_VERIFICATION_STATUS == "FAILED-1").ToList();
                    return View(v_fail);

                }
                else
                {
                    return RedirectToAction("Login");

                }

            }
            catch (Exception ex)
            {
                _log.lodwrite("Error : " + ex);

                return RedirectToAction("Login");

            }
        }



        [HttpPost]
        public IActionResult Searchdatetimeenroll(DateTime fromDate, DateTime toDate)
        {

            var fromDateWithoutTime = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day);
            var toDateWithoutTime = new DateTime(toDate.Year, toDate.Month, toDate.Day).AddDays(1).AddTicks(-1);

            var data = _enrollContext.TBL_ENROLLMENT.OrderByDescending(x => x.VAR_CALLED_DATE)
            .Where(e => e.VAR_CALLED_DATE >= fromDateWithoutTime && e.VAR_CALLED_DATE <= toDateWithoutTime).ToList();
            Console.WriteLine(data);

            return View("EntrollmentTable", data);
        }

        [HttpPost]
        public IActionResult Searchdatetimeverify(DateTime fromDate, DateTime toDate)
        {
            var fromDateWithoutTime = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day);
            var toDateWithoutTime = new DateTime(toDate.Year, toDate.Month, toDate.Day).AddDays(1).AddTicks(-1);

            var data = _enrollContext.TBL_VERIFICATION.OrderByDescending(x => x.VAR_CALLED_DATE)
                .Where(e => e.VAR_CALLED_DATE >= fromDateWithoutTime && e.VAR_CALLED_DATE <= toDateWithoutTime).ToList();

            return View("VerificationTable", data);
        }



        [HttpPost]
        public IActionResult SearchdatetimeTransfer(DateTime fromDate, DateTime toDate)
        {
            var fromDateWithoutTime = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day);
            var toDateWithoutTime = new DateTime(toDate.Year, toDate.Month, toDate.Day).AddDays(1).AddTicks(-1);

            var data = _enrollContext.TBL_CALL_TRANSFER
                                     .Where(e => e.VAR_CALLED_DATE >= fromDateWithoutTime &&
                                                 e.VAR_CALLED_DATE <= toDateWithoutTime)
                                     .OrderByDescending(x => x.VAR_CALLED_DATE)
                                     .ToList();

            return View("Calltrnsfer", data); // 👈 Make sure your View name matches
        }

        [HttpPost]
        public IActionResult SearchdatetimeDetails(DateTime fromDate, DateTime toDate)
        {
            var fromDateWithoutTime = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day);
            var toDateWithoutTime = new DateTime(toDate.Year, toDate.Month, toDate.Day).AddDays(1).AddTicks(-1);

            var data = _enrollContext.TBL_CALLDETAILS
                                     .Where(e => e.VAR_CALLED_DATE >= fromDateWithoutTime &&
                                                 e.VAR_CALLED_DATE <= toDateWithoutTime)
                                     .OrderByDescending(x => x.VAR_CALLED_DATE)
                                     .ToList();

            return View("CallDetails", data); // 👈 Make sure your View name matches
        }


        [HttpGet]
        public IActionResult VerificationTable()
        {
            _log.lodwrite("******************** GET Verification  ********************");

            ViewBag.Name = HttpContext.Session.GetString(logtsts);
            ViewBag.UsName = HttpContext.Session.GetString("UsName") ?? "";
            try
            {

                if (ViewBag.UsName != "" && ViewBag.Name == "loged")
                {
                    var V_table = _enrollContext.TBL_VERIFICATION.OrderByDescending(x => x.VAR_CALLED_DATE).Where(v =>v.VAR_VERIFICATION_STATUS != null && v.VAR_VERIFICATION_SCORE != null).ToList();
                    _log.lodwrite(" verification table list success ");
                    return View(V_table);
                }
                else
                {
                    _log.lodwrite("user name and login incorrect");
                    return RedirectToAction("Login");
                }
            }
            catch (Exception ex)
            {
                _log.lodwrite("Error :" + ex.Message);
                return RedirectToAction("Login");

            }
        }

        //balcklist//
        [HttpGet]
        public IActionResult BlacklistTable()
        {
            _log.lodwrite("******************** GET Verification  ********************");

            ViewBag.Name = HttpContext.Session.GetString(logtsts);
            ViewBag.UsName = HttpContext.Session.GetString("UsName") ?? "";
            try
            {

                if (ViewBag.UsName != "" && ViewBag.Name == "loged")
                {
                    var V_table = _enrollContext.TBL_BLACKLIST.ToList();

                    //var V_table = _enrollContext.TBL_BLACKLIST.OrderByDescending(x => x.var_called_date).ToList();
                    _log.lodwrite(" Blacklist table list success ");
                    return View(V_table);
                }
                else
                {
                    _log.lodwrite("user name and login incorrect");
                    return RedirectToAction("Login");
                }
            }
            catch (Exception ex)
            {
                _log.lodwrite("Error :" + ex.Message);
                return RedirectToAction("Login");

            }
        }




        [HttpGet]
        public IActionResult Calltrnsfer()
        {
            _log.lodwrite("******************** GET TransferTable ********************");

            ViewBag.Name = HttpContext.Session.GetString(logtsts);
            ViewBag.UsName = HttpContext.Session.GetString("UsName") ?? "";

            try
            {
                if (ViewBag.UsName != "" && ViewBag.Name == "loged")
                {
                    var transfers = _enrollContext.TBL_CALL_TRANSFER
                                                  .OrderByDescending(x => x.VAR_CALLED_DATE)
                                                  .ToList();

                    _log.lodwrite("Transfer table list success. Records: " + transfers.Count);
                    return View(transfers);
                }
                else
                {
                    _log.lodwrite("user name or login incorrect");
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                _log.lodwrite("Error in TransferTable: " + ex.Message);
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpGet]
        public IActionResult CallDetails()
        {
            _log.lodwrite("******************** GET CallDetailsTable ********************");

            ViewBag.Name = HttpContext.Session.GetString(logtsts);
            ViewBag.UsName = HttpContext.Session.GetString("UsName") ?? "";

            try
            {
                if (ViewBag.UsName != "" && ViewBag.Name == "loged")
                {
                    var details = _enrollContext.TBL_CALLDETAILS
                                                .OrderByDescending(x => x.VAR_CALLED_DATE)
                                                .ToList();

                    _log.lodwrite("CallDetails table list success. Records: " + details.Count);
                    return View(details);
                }
                else
                {
                    _log.lodwrite("user name or login incorrect");
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                _log.lodwrite("Error in CallDetailsTable: " + ex.Message);
                return RedirectToAction("Login", "Home");
            }
        }







        [HttpPost]
        public IActionResult Logout()
        {
            _log.lodwrite("**************** GET Logout ****************");

            HttpContext.Session.SetString(logtsts, "Logout");
            ViewBag.UsName = HttpContext.Session.GetString("UsName") ?? "";
            HttpContext.Session.Clear();

            //HttpContext.Session.Remove("UsName");
            _log.lodwrite("Logout successfully");
            return RedirectToAction("Login");

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
