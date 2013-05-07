using CopyRename;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CopyRenameTests
{
    
    
    /// <summary>
    ///This is a test class for MainFormTest and is intended
    ///to contain all MainFormTest Unit Tests
    ///</summary>
	[TestClass()]
	public class MainFormTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion

		#region GetFileName
		[TestMethod()]
		public void GetFileNamePrefixFirstTest()
		{
			string prefix = "prefix"; // TODO: Initialize to an appropriate value
			int counter = 23; // TODO: Initialize to an appropriate value
			int digits = 5; // TODO: Initialize to an appropriate value
			string ext = ".jpg"; // TODO: Initialize to an appropriate value
			bool numberFirst = false; // TODO: Initialize to an appropriate value
			string expected = "prefix_00023.jpg"; // TODO: Initialize to an appropriate value
			string actual = MainForm.GetFileName(prefix, counter, digits, ext, numberFirst);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void GetFileNameNumberLastTest()
		{
			string prefix = "prefix"; // TODO: Initialize to an appropriate value
			int counter = 23; // TODO: Initialize to an appropriate value
			int digits = 5; // TODO: Initialize to an appropriate value
			string ext = ".jpg"; // TODO: Initialize to an appropriate value
			bool numberFirst = true; // TODO: Initialize to an appropriate value
			string expected = "00023_prefix.jpg"; // TODO: Initialize to an appropriate value
			string actual = MainForm.GetFileName(prefix, counter, digits, ext, numberFirst);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void GetFileNamePrefixFirstWithDirNameTest()
		{
			string prefix = "<directory name>"; // TODO: Initialize to an appropriate value
			int counter = 23; // TODO: Initialize to an appropriate value
			int digits = 5; // TODO: Initialize to an appropriate value
			string ext = ".jpg"; // TODO: Initialize to an appropriate value
			bool numberFirst = false; // TODO: Initialize to an appropriate value
			string expected = "<directory name>_00023.jpg"; // TODO: Initialize to an appropriate value
			string actual = MainForm.GetFileName(prefix, counter, digits, ext, numberFirst);
			Assert.AreEqual(expected, actual);
		}

		#endregion GetFileName




	}
}
