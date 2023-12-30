using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhap
{
    //THAY DOI SERVER CHO PHU HOP TRUOC KHI CHAY.
    // user: test _ pass: 123
    // Phuc: THIENPHUCLAPTOP
    // Phung: LAPTOP-8KCG746L
    // Suong: F
    internal class ConnectionInfo
    {
        public static String connString = "Data Source=F;Initial Catalog=MusicLogin;Integrated Security=True";
        public string ConnectionCommand() 
        { return @connString; }
    }
}
