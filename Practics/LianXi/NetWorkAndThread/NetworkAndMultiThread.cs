using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practics.LianXi.NetWorkAndThread
{
    public class NetworkAndMultiThread : KnowledgeTestBase
    {
        public override void Test(int nTestID)
        {
            RemoteServer remote = new RemoteServer();
            LocalClient local = new LocalClient();
            Thread thread1 = new Thread(new ThreadStart(remote.Main));
            Thread thread2 = new Thread(new ThreadStart(local.Main));
            thread1.Start();
            thread2.Start();
        }
    }
}
