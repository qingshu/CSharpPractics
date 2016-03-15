using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.DesignPatterns
{
    internal class StatePattern:PatternBase
    {
        public override void Main()
        {
            Account xiaoMing = new Account("小明");
            xiaoMing.Withdraw(5000);
            xiaoMing.PayInterest();

            xiaoMing.Withdraw(200);
            xiaoMing.Deposit(5200);
            xiaoMing.Withdraw(5000);
            xiaoMing.Withdraw(5000);
            xiaoMing.Deposit(16000);
            xiaoMing.Withdraw(12000);
        }

        #region 状态模式
        public class Account
        {
            public State State { get; set; }
            public string szOwner { set; get; }
            public double Balance { get { return State.Balance; } }
            public Account(string szOwner)
            {
                this.szOwner = szOwner;
                this.State = new NormalState(0.0,this);
            }
            /// <summary>
            /// 存钱
            /// </summary>
            /// <param name="amount"></param>
            public void Deposit(double amount)
            {
                State.Deposit(amount);
                Console.WriteLine("当前账户：{0}", szOwner);
                Console.WriteLine("存款金额：{0:C}--", amount);
                Console.WriteLine("账户余额：{0:C}--", Balance);
                Console.WriteLine("账户状态：{0}--", State.szStateName);
                Console.WriteLine("------------------------------------------");
            }
            /// <summary>
            /// 取钱
            /// </summary>
            /// <param name="amount"></param>
            public void Withdraw(double amount)
            {
                Console.WriteLine("当前账户：{0}", szOwner);
                bool isCanWithdraw=State.Withdraw(amount);                
                if (isCanWithdraw)
                {
                    Console.WriteLine("取款金额：{0:C}--", amount);                    
                }
                Console.WriteLine("账户余额：{0:C}--", Balance);
                Console.WriteLine("账户状态：{0}--", State.szStateName);
                Console.WriteLine("------------------------------------------");
            }
            /// <summary>
            /// 获得利息
            /// </summary>
            public void PayInterest()
            {
                State.PayInterest();
            }
        }

        public abstract class State
        {
           public string szStateName { set; get; }
            //账户
           public Account account { set; get; }
            //余额
           public double Balance { set; get; }
            //利率
           public double Interest { set; get; }
            //上限
           public double UpperLimit { set; get; }
            //下限
           public double LowerLimit { set; get; }
            //存钱
           public void Deposit(double amount)
           {
               Balance += amount;
               StateChangeCheck();             
           }
           //取钱
           public bool Withdraw(double amount)
           {
               if (Balance-amount>-10000)
               {
                   //没有达到透支限额
                   Balance -= amount;
                   StateChangeCheck();
                   return true;
               }
               else
               {
                   Console.WriteLine("您所执行的操作将达到或已超过最大透支限额10000，请还款后再操作");
                   return false;
               }
           }
           public void PayInterest()
           {
               Console.WriteLine("当前利息：{0}", Balance * Interest);
               Console.WriteLine("------------------------------------------");
           }
           //检查并更改状态
           public abstract void StateChangeCheck();
        }

        /// <summary>
        /// 普通卡
        /// </summary>
        public class NormalState : State
        {
            public NormalState(double amount,Account account)
            {
                szStateName = "普卡";               
                this.account = account;
                this.Balance = amount;
                this.Interest = 0.0001;
                this.UpperLimit = 10000;
                this.LowerLimit = 0;
            }

            public override void StateChangeCheck()
            {
                if (Balance  > UpperLimit)
                {
                    account.State = new GoldState(account);
                }
                else if (Balance  < LowerLimit)
                {
                    account.State = new RedState(account);
                }
            }
        }

        public class GoldState : State
        {
            public GoldState(Account account)
            {
                szStateName = "金卡";
                this.account = account;
                this.Balance = account.Balance;               
                this.Interest = 0.001;
                this.LowerLimit =10000;
            }

            public override void StateChangeCheck()
            {
                if (Balance< LowerLimit)
                {
                    account.State = new NormalState(Balance,account);
                    if (Balance<account.State.LowerLimit)
                    {
                        account.State = new RedState(account);
                    }
                }
            }
        }

        public class RedState : State
        {
            public RedState(Account account)
            {
                szStateName = "透支";
                this.account = account;
                this.Balance = account.Balance;
                this.Interest = 0.001;
                this.UpperLimit = 0;
                this.LowerLimit = -10000;
            }

            public override void StateChangeCheck()
            {                
                if (Balance>=UpperLimit)
                {
                    account.State = new NormalState(Balance,account);
                    if (Balance>account.State.UpperLimit)
                    {
                        account.State = new GoldState(account);
                    }
                }
            }
        }
        #endregion
    }
}
