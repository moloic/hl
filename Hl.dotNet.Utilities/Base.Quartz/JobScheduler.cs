
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Quartz;
//using Quartz.Impl;
//namespace Hl.dotNet.Utilities
//{
//  public  class JobScheduler
//    {
//        public static void Start()
//        { /*
//           无配置形式：
//           Quartz.Net一个最简单任务至少包括三部分实现：job(作业),trigger(触发器)以及scheduler(调度器)。
//           其中job 是你需要在一个定时任务中具体执行的业务逻辑，trigger则规定job何时并按照何种规则执行，
//           最终job和trigger会被注册到 scheduler(调度器)中，scheduler负责协调job和trigger的运行。
//           */

//            //第一中写法
//            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();//创建调度器
//            // scheduler.Start();//启动任务调度器
//            IJobDetail job = JobBuilder.Create<ReportJob>().Build();  //创建任务实例绑定要执行的业务
//            ITrigger trigger = TriggerBuilder.Create()  //创建一个触发器
//              .WithIdentity("triggerName", "groupName") //配置触发器的名字和分组
//              .WithSimpleSchedule(t =>
//               t.WithIntervalInSeconds(5)   //每5秒执行一次
//               .RepeatForever())
//               .Build();

//            scheduler.ScheduleJob(job, trigger);//把触发器注册到调度中进行任务执行
//            scheduler.Start();//启动任务调度器
//        }
//    }
//}
