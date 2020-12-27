using Autofac;
using PriceGetter.PersistenceMongo.Tools;

namespace PriceGetter.Web.IoC
{
    /// <summary>
    /// Installs mongoDb related objects, not really used so far.
    /// </summary>
    public class PersistenceMongoInstaller : Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CollectionProvider>().As<ICollectionProvider>();
            builder.RegisterType<DbCleaner>().As<IDbCleaner>();
        }
    }
}
