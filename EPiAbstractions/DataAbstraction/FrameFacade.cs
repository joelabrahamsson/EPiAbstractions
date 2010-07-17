using System;
using EPiServer.DataAbstraction;

namespace EPiAbstractions.DataAbstraction 
{
	public class FrameFacade : IFrameFacade
	{
		public virtual EPiServer.DataAbstraction.Frame Load(System.Int32 id)
		{
			 return Frame.Load(id);
		}

		public virtual EPiServer.DataAbstraction.Frame Load(System.String name)
		{
			 return Frame.Load(name);
		}

		public virtual EPiServer.DataAbstraction.FrameCollection List()
		{
			 return Frame.List();
		}

		public virtual void Save(Frame frame)
		{
		    frame.Save();
		}

        public virtual void Delete(Frame frame)
        {
            frame.Delete();
        }

		private static FrameFacade _instance;

		public static FrameFacade Instance
		{
			get
			{
				if(_instance == null)
					_instance = new FrameFacade();

				return _instance;
			}

			set
			{
				_instance = value;
			}
		}

	}
}