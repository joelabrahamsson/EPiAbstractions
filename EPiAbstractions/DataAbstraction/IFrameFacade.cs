using System;
using EPiServer.DataAbstraction;

namespace EPiAbstractions.DataAbstraction 
{
	interface IFrameFacade
	{
		EPiServer.DataAbstraction.Frame Load(System.Int32 id);

		EPiServer.DataAbstraction.Frame Load(System.String name);

		EPiServer.DataAbstraction.FrameCollection List();

        void Save(Frame frame);

        void Delete(Frame frame);
	}
}