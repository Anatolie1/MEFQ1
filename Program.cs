using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Questes1
{
    class Program
    {
        private Mef _host;

        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }
        private void Run()
        {
            _host = new Mef();
            HelloSayer helloSayer = _host.Container.GetExportedValue<HelloSayer>();
            helloSayer.SayHello();
        }
    }

    public class Mef
    {
        private CompositionContainer _container = null;

        public CompositionContainer Container
        {
            get
            {
                if (_container == null)
                {
                    var catalog = new DirectoryCatalog(".", "Questes1.*");

                    _container = new CompositionContainer(catalog);
                }

                return _container;
            }
        }
    }

    [Export]
    internal class HelloSayer
    {
        public void SayHello()
        {
            Console.WriteLine("Bonjour !");
        }
    }
}
