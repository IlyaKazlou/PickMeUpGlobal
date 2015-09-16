using Quartz;
using Quartz.Impl;

namespace Jobs
{
  public class JobRunner
  {
    public void Run()
    {
      var sched = this.GetScheduler();
      sched.Start();

      IJobDetail testUserMovementJob = JobBuilder.Create<ChangeTestUsersCoordsJob>()
          .WithIdentity("testUserMovementJob", "group1")
          .Build();

      ITrigger testUserMovementJobTrigger = this.CreateDefaultTriggerWithInterval(20, "testUserMovementTrigger", "group1");

      IJobDetail moveCoordsJob = JobBuilder.Create<MovePointsToPermanentStorageJob>()
          .WithIdentity("moveCoordsJob", "group1")
          .Build();

      ITrigger moveCoordsTrigger = this.CreateDefaultTriggerWithInterval(1500, "moveCoordsTrigger", "group1");

      sched.ScheduleJob(testUserMovementJob, testUserMovementJobTrigger);
      sched.ScheduleJob(moveCoordsJob, moveCoordsTrigger);
    }

    private ITrigger CreateDefaultTriggerWithInterval(int seconds, string name, string group)
    {
      ITrigger trigger = TriggerBuilder.Create()
        .WithIdentity(name, group)
        .StartNow()
        .WithSimpleSchedule(x => x
            .WithIntervalInSeconds(seconds)
            .RepeatForever())
        .Build();

      return trigger;
    }

    private IScheduler GetScheduler()
    {
      ISchedulerFactory schedFact = new StdSchedulerFactory();
      IScheduler sched = schedFact.GetScheduler();
      return sched;
    }
  }
}