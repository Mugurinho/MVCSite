using StructureMap;
using MVCSite.Models.Data;
namespace MVCSite {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<MVCSiteDataContext>().Use(new MVCSiteDataContext());
                        });
            return ObjectFactory.Container;
        }
    }
}