//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyHearthStoneV2.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class HS_DataExchange :BaseEntity
    {
        public long ID { get; set; }
        public string URL { get; set; }
        public string QueryData { get; set; }
        public string ResultData { get; set; }
        public string IP { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public System.DateTime AddTime { get; set; }
        public int DataSource { get; set; }
    }
}
