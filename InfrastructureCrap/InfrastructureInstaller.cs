using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using InfrastructureCrap.Persistence;

namespace InfrastructureCrap
{
    public class InfrastructureInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                                   .For<IWindsorContainer>()
                                   .Instance(container),
                               Component
                                   .For<IStore>()
                                   .ImplementedBy<InMemoryStore>());
        }
    }
}