using System.Collections.Generic;

namespace MyHearthStoneV2.TestConsole
{
    //[PropertyChangedNotification]
    public class TestClass
    {
        public List<NoClass> lstNoClass { get; set; } = new List<NoClass>();

        public string str { get; set; }

        [TestMonitor]
        public void ddada()
        {

        }
    }
}
