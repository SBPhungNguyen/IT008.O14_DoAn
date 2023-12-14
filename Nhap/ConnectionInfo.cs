using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhap
{
    //THAY DOI SERVER CHO PHU HOP TRUOC KHI CHAY.
    internal class ConnectionInfo
    {
        public static String connString = "Data Source=LAPTOP-8KCG746L;Initial Catalog=MusicLogin;Integrated Security=True";
        public string ConnectionCommand() 
        { return @connString; }
    }
}
