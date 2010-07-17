using System;
using EPiServer.DataAbstraction;

namespace EPiAbstractions.DataAbstraction
{
    public interface IScheduledJobFacade
    {
        void SetServicePingDate();

        ScheduledJob Load(Guid id);

        ScheduledJob Load(String method, String typeName, String assemblyName);

        ScheduledJob LoadNextScheduledJob();

        ScheduledJobCollection List();

        void Save(ScheduledJob scheduledJob);
    }
}