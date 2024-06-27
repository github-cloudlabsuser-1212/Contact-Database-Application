using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index()
        {
            return View(userlist);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken] // Added to prevent CSRF attacks
        public ActionResult Create([Bind(Include = "Id,Name,Email")] User user) // Added model binding
        {
            try
            {
                if (ModelState.IsValid) // Check if model state is valid
                {
                    userlist.Add(user);
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken] // Added to prevent CSRF attacks
        public ActionResult Edit(int id, [Bind(Include = "Id,Name,Email")] User user) // Added model binding
        {
            try
            {
                if (ModelState.IsValid) // Check if model state is valid
                {
                    var existingUser = userlist.FirstOrDefault(u => u.Id == id);
                    if (existingUser == null)
                    {
                        return HttpNotFound();
                    }
                    existingUser.Name = user.Name;
                    existingUser.Email = user.Email;
                    // Update other fields as necessary

                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch
            {
                return View(user);
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] // Added to prevent CSRF attacks
        public ActionResult DeleteConfirmed(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                userlist.Remove(user);
            }
            return RedirectToAction("Index");
        }
    }
}
