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
    public void Test_LoginPassword_Right()
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
}