using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.WindowItems;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        TestStack.White.Application app = null;

        [TestInitialize]
        public void InitializeTest()
        {
            app = TestStack.White.Application.Launch(@"C:\Users\abatchvarov\Documents\Visual Studio 2017\MVPSample\MVPSample\bin\Debug\MVPSample.exe");
        }

        [TestCleanup]
        public void FinalizeTest()
        {
            app.Close();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Window window = app.GetWindow("Form1");
            TextBox txtLength = window.Get<TextBox>("txtLength");
            txtLength.SetValue("2");
            TextBox txtBreadth = window.Get<TextBox>("txtBreadth");
            txtBreadth.SetValue("4");
            Button btnCalculateArea = window.Get<Button>("btnCalculateArea");
            btnCalculateArea.Click();
            Label lblArea = window.Get<Label>("lblArea");
            Assert.AreEqual("8 Sq CM", lblArea.Text, "Wrong area calculation");
            Table dataGrid = window.Get<Table>("dataGridView1");
            Assert.AreEqual(1, dataGrid.Rows.Count);
            dataGrid.Rows[0].Cells[0].Value = "123.45";
            dataGrid.Rows[0].Cells[1].Value = "678.90";
            dataGrid.Rows[0].Cells[1].KeyIn(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.RETURN);
            dataGrid.Refresh();
            Assert.AreEqual(2, dataGrid.Rows.Count);
            dataGrid.Enter("1111"); dataGrid.KeyIn(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.RETURN);
            dataGrid.Refresh();
            dataGrid.Rows[2].Cells[0].Value = "123.45";
            dataGrid.Rows[2].Cells[1].Value = "678.90";
            dataGrid.Rows[2].Cells[1].KeyIn(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.RETURN);
            Assert.AreEqual(3, dataGrid.Rows.Count);
            dataGrid.Refresh();
            Assert.AreEqual(4, dataGrid.Rows.Count);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Window window = app.GetWindow("Form1");
            TextBox txtLength = window.Get<TextBox>("txtLength");
            txtLength.SetValue("2");
            TextBox txtBreadth = window.Get<TextBox>("txtBreadth");
            txtBreadth.SetValue("4");
            Button btnCalculateArea = window.Get<Button>("btnCalculateArea");
            btnCalculateArea.Click();
            Label lblArea = window.Get<Label>("lblArea");
            Assert.AreEqual("8 Sq CM", lblArea.Text, "Wrong area calculation");
            Table dataGrid = window.Get<Table>("dataGridView1");
            dataGrid.Rows[0].Cells[0].Value = "123.45";
        }
    }
}
