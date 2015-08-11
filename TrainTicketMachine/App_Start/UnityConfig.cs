using Microsoft.Practices.Unity;
using System.Web.Http;
using TrainTicketMachine.Bll;
using TrainTicketMachine.Bll.DataStructures;
using TrainTicketMachine.Bll.Interfaces;
using TrainTicketMachine.Bll.Repository;
using Unity.WebApi;

namespace TrainTicketMachine
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here

            container.RegisterType<IStationRepository, StationRepository>();
            container.RegisterType<IPrefixTree, PrefixTree>();
            container.RegisterType<IStationFinderBll, StationFinderBll>(new ContainerControlledLifetimeManager());
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}