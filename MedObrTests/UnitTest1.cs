using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MedObr.MainPages;
using MedObr.Data;
using MedObr;

namespace MedObrTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Check_user()
        {
           Assert.AreEqual(true, PageLogin.getUser("1","1"));
        }
        [TestMethod]
        public void Check_bd()
        {
            Assert.AreEqual(true, MainWindow.Connect_bd());
        }
        [TestMethod]
        public void Check_captcha()
        {
            Assert.AreEqual(true, Captcha.Check_captcha("asds","asds"));
        }
        [TestMethod]
        public void Check_add_oborudovanie()
        {
            Assert.AreEqual(true,MedObr.AddPages.AddObor.Add_obor("Нож", 1,2,1,"Штык нож",3,1200));
        }
        [TestMethod]
        public void Check_add_order()
        {
            Assert.AreEqual(true, MedObr.AddPages.Buy.Add_order(2,500,3));
        }
        [TestMethod]
        public void Check_add_user()
        {
            Assert.AreEqual(true, MedObr.AddPages.AddUser.Add_user("Пен","Гриша","Фейхуа","Альбертович","87652948726",Convert.ToDateTime("29-11-2002"),"djasld@mail.ru","123123123"));
        }
        [TestMethod]
        public void Check_find_obor()
        {
            Assert.AreEqual(true, MedObr.TablePages.AdminOborudPage.find_obor("Ультрасоник"));
        }
        [TestMethod]
        public void Check_find_user()
        {
            Assert.AreEqual(true, MedObr.TablePages.AdminUserPage.find_user("1"));
        }

    }
}
