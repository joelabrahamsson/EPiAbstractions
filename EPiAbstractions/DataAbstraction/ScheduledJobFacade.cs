using System;
using EPiServer.DataAbstraction;

namespace EPiAbstractions.DataAbstraction
{
    public class ScheduledJobFacade : IScheduledJobFacade
    {
        private static ScheduledJobFacade _instance;

        public static ScheduledJobFacade Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ScheduledJobFacade();

                return _instance;
            }

            set { _instance = value; }
        }

        #region IScheduledJobFacade Members

        public virtual void SetServicePingDate()
        {
            ScheduledJob.SetServicePingDate();
        }

        public virtual ScheduledJob Load(Guid id)
        {
            return ScheduledJob.Load(id);
        }

        public virtual ScheduledJob Load(String method, String typeName, String assemblyName)
        {
            return ScheduledJob.Load(method, typeName, assemblyName);
        }

        public virtual ScheduledJob LoadNextScheduledJob()
        {
            return ScheduledJob.LoadNextScheduledJob();
        }

        public virtual ScheduledJobCollection List()
        {
            return ScheduledJob.List();
        }

        public virtual void Save(ScheduledJob scheduledJob)
        {
            scheduledJob.Save();
        }

        #endregion
    }
}