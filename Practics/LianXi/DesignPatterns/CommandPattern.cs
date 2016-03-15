using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.DesignPatterns
{
    internal class CommandPattern:PatternBase
    {
        public override void Main()
        {
            Receiver receiver = new Receiver();
            Command command = new RunCommand(receiver);
            Invoker invoke = new Invoker(command);
            invoke.ExecuteCommand();
        }

        #region 命令模式
        /// <summary>
        /// 命令抽象类
        /// </summary>
        public abstract class Command
        {
            protected Receiver m_Receiver;
            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="receiver"></param>
            public Command(Receiver receiver)
            {
                m_Receiver = receiver;
            }

            public abstract void Action();
        }

        /// <summary>
        /// 具体命令角色
        /// </summary>
        public class RunCommand:Command
        {
            public RunCommand(Receiver receiver)
                : base(receiver)
            {
            
            }
            public override void Action()
            {
                m_Receiver.Run100Meter();
            }
        }

        /// <summary>
        /// 命令接收者角色
        /// </summary>
        public class Receiver
        {
            public void Run100Meter()
            {
                Console.WriteLine("跑100米");
            }
        }

        /// <summary>
        /// 发布命令角色
        /// </summary>
        public class Invoker
        {
            public Command m_command;
            public Invoker(Command command)
            {
                m_command = command;
            }
            public void ExecuteCommand()
            {
                m_command.Action();
            }
        }
        #endregion
    }
}
