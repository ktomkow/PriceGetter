using Autofac;
using PriceGetter.PersistenceMongo.Tools;

namespace PriceGetter.Web.IoC
{
    public class PersistenceMongoInstaller : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CollectionProvider>().As<ICollectionProvider>();
            builder.RegisterType<DbCleaner>().As<IDbCleaner>();
        }
    }
}
