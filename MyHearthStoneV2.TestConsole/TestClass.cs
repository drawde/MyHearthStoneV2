using System.Collections.Generic;

namespace MyHearthStoneV2.TestConsole
{
    //[PropertyChangedNotification]
    public class TestClass
    {
        public List<NoClass> lstNoClass { get; set; } = new List<NoClass>();

        [TestMonitor]
        public void ddada()
        {

        }
    }
}
