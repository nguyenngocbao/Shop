using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Shop.Common;

namespace Shop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]  //hàm đăng nhập
        public ActionResult Login(Models.LoginModel model)
        {
            if (ModelState.IsValid)
            //nếu form ko có lỗi
            {
                var dao = new UserDao();
                //gán kết quả biến result bằng cách gọi hàm đăng nhập của lớp UserDao
                //nhận vào tên và mật khẩu mã hóa từ dối tượng loginmodel được gán khi form submit
                var result = dao.Login(model.UserName, model.Password);
                if (result == 1)
                //nếu đúng thì chuyển qua trang chủ
                {
                    Session.Add("Username", model.UserName);
                    return RedirectToAction("Index", "Home");
                }  //nếu không tồn tại
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tai khoan khong ton tai");
                }// nếu bị khóa
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tai khoan dang bi khoa");
                }// nếu sai mật khẩu
                else if (result == -2)
                {
                    ModelState.AddModelError("", "mat khau ko dung");
                }
            }
            return View("Index");
        }
        [HttpGet] //hàm đăng xuất
        public ActionResult Logout()   //nếu chon logout thì  gán session Username == rỗng và trở về trang chủ
        {
            Session["Username"] = null;
            return RedirectToAction("Index", "Home");
        }


    }
}