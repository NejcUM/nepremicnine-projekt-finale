using NepremicnineProjekt;

[TestClass]
public sealed class Tests
{
    [TestMethod]
    public void Test_UsernameExist_Exist()
    {
        bool exist = Program.db_manager.UsernameExist("kiki");
        Assert.IsTrue(exist);
    }
    
    [TestMethod]
    public void Test_UsernameExist_NotExist()
    {
        bool exist = Program.db_manager.UsernameExist("marko");
        Assert.IsFalse(exist);
    }
    
    [TestMethod]
    public void Test_ValidEmail_Valid()
    {
        bool valid = Program.db_manager.ValidEmail("marko@gmail.com");
        Assert.IsTrue(valid);
    }
    
    [TestMethod]
    public void Test_ValidEmail_Invalid()
    {
        bool valid = Program.db_manager.ValidEmail("marko.com");
        Assert.IsFalse(valid);
    }
    
    [TestMethod]
    public void Test_EmailExist_Exist()
    {
        bool exist = Program.db_manager.EmailExist("kiki.vinko@gmail.com");
        Assert.IsTrue(exist);
    }
    
    [TestMethod]
    public void Test_EmailExist_NotExist()
    {
        bool exist = Program.db_manager.EmailExist("marko2020@gmail.com");
        Assert.IsFalse(exist);
    }
    
    [TestMethod]
    public void Test_LoginPassword_Correct()
    {
        bool success = Program.db_manager.LoginCheck("kiki","1234");
        Assert.IsTrue(success);
    }
    
    [TestMethod]
    public void Test_LoginPassword_Wrong()
    {
        bool success = Program.db_manager.LoginCheck("kiki","aaaa");
        Assert.IsFalse(success);
    }
    
    [TestMethod]
    public void Test_IsValueNumber_Correct()
    {
        bool is_a_number = Program.db_manager.IsValueNumber("1000");
        Assert.IsTrue(is_a_number);
    }
    
    [TestMethod]
    public void Test_IsValueNumber_Wrong()
    {
        bool is_a_number = Program.db_manager.IsValueNumber("1000abc");
        Assert.IsFalse(is_a_number);
    }
    
    [TestMethod]
    public void Test_IsImageUrlValid_Valid()
    {
        bool valid = Program.db_manager.IsImageUrlValid("https://www.google.com/img.png");
        Assert.IsTrue(valid);
    }
    
    [TestMethod]
    public void Test_IsImageUrlValid_Invalid()
    {
        bool valid = Program.db_manager.IsImageUrlValid("google.com/img.png");
        Assert.IsFalse(valid);
    }
}