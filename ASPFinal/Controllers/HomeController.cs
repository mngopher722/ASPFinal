using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPFinal.Models;

namespace ASPFinal.Controllers
{
    public class HomeController : Controller
    {
        private HenrysBookStore db = new HenrysBookStore();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Inventory()
        {
            ViewBag.Message = "Your inventory page.";

            return View(db.BOOK);
        }
        public ActionResult Publisher(string pub_Code)
        {
            IEnumerable<PUBLISHER> publisherlist = db.PUBLISHER;
            List<SelectListItem> publishers = new List<SelectListItem>();
            foreach (PUBLISHER publisher in publisherlist)
            {
                publishers.Add(new SelectListItem
                {
                    Text = publisher.PUBLISHER_NAME,
                    Value = publisher.PUBLISHER_CODE
                });
            }
            ViewBag.Message = "your publisher page";
            var books = new List<BOOK>();
            if (pub_Code != null && pub_Code.Trim() != "")
            {
                publishers.First(p => p.Value == pub_Code).Selected = true;

                foreach (BOOK book in db.BOOK)
                {
                    if (book.PUBLISHER_CODE == pub_Code)
                    {
                        books.Add(book);
                    }
                }
                ViewBag.publishers = publishers;
                return View(books);
            }
            else
            {
                ViewBag.publishers = publishers;
                return View();
            }
        }
        public ActionResult Branch(int branchnum = -1)
        {
            IEnumerable<BRANCH> branchlist = db.BRANCH;
            List<SelectListItem> branches = new List<SelectListItem>();
            foreach (BRANCH branch in branchlist)
            {
                branches.Add(new SelectListItem
                {
                    Text = branch.BRANCH_NAME,
                    Value = branch.BRANCH_NUM.ToString()
                });
            }
            ViewBag.Message = "Your Branch page.";
            var books = new List<BOOK>();

            if (branchnum > 0)
            {
                branches.First(b => b.Value == branchnum.ToString()).Selected = true;

                foreach (BOOK book in db.BOOK)
                {
                    foreach (INVENTORY inventory in book.INVENTORY)
                    {
                        if (inventory.BRANCH_NUM == branchnum)
                        {
                            books.Add(book);
                        }
                    }
                }
            }
            ViewBag.branches = branches;
            if (branchnum > 0)
            {
                return View(branchlist.First(b => b.BRANCH_NUM == branchnum)); 
            }
            else
            {
                return View();
            }
        }
    public ActionResult Author(int id = -1)
    {
        IEnumerable<AUTHOR> authorlist = db.AUTHOR;
        List<SelectListItem> authors = new List<SelectListItem>();
        foreach (AUTHOR author in authorlist)
        {
            authors.Add(new SelectListItem
            {
                Text = author.AUTHOR_FIRST + " " +
                author.AUTHOR_LAST,
                Value = author.AUTHOR_NUM.ToString()
            });
        }
        ViewBag.Message = "Your Author page.";
        var books = new List<BOOK>();
        if (id > 0)
        {
            //foreach (SelectListItem author in authors)
            //{
            //    if (int.Parse(author.Value) == id)
            //    {
            //        author.Selected = true;
            //    }
            //}

            authors.First(a => a.Value == id.ToString()).Selected = true;

            foreach (BOOK book in db.BOOK)
            {
                foreach (WROTE wrote in book.WROTE)
                {
                    if (wrote.AUTHOR_NUM == id)
                    {
                        books.Add(book);
                    }
                }
            }
        }

        ViewBag.authors = authors;
        if (id > 0)
        {
            return View(books);
        }
        else
        {
            return View();
        }
    }
    public ActionResult Book(string bookcode)
    {
        ViewBag.Message = "Your details page.";

        return View(db.BOOK.FirstOrDefault(b => b.BOOK_CODE == bookcode));
    }
}
}
