using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.DesignPatterns
{
    internal class MediatorPattern:PatternBase
    {
        public override void Main()
        {

        }

        #region 中介者模式（结合状态模式及观察者模式）
        //抽象牌友类
        public abstract class AbstractCardPartner
        {
            public int nMoneyCount { set; get; }
            public abstract void ChangeCount(int nCount,AbstractMediator mediator);
        }
        //抽象状态类
        public abstract class AbstractState
        {
            protected AbstractMediator mediator;
            public abstract void ChangeCount(int count);
        }
        //抽象中介者类
        public abstract class AbstractMediator
        {
            public List<AbstractCardPartner> listCardPartner = new List<AbstractCardPartner>();
            public AbstractState State { set; get; }

            public AbstractMediator(AbstractState state)
            {
                State = state;
            }
            //加入一个牌友
            public void JoinAPartner(AbstractCardPartner partner)
            {
                listCardPartner.Add(partner);
            }
            //离开一个牌友
            public void LeaveAPartner(AbstractCardPartner partner)
            {
                listCardPartner.Remove(partner);
            }
            //记分
            public void ChangeCount(int count)
            {
                State.ChangeCount(count);
            }
        }

        //牌友A
        public class PartnerA : AbstractCardPartner
        {
            public override void ChangeCount(int nCount, AbstractMediator mediator)
            {
                throw new NotImplementedException();
            }
        }
        
        #endregion
    }
}
