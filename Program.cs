using System;

namespace DIContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Container _container = new Container();
            _container.Register<IA>("Aclass", delegate
            {
                return new A();
            });
            int _val1 = 1992;
            string _val2 = "Hello Wprld";
            _container.Configuration["Bparam1"] = _val1;
            _container.Configuration["Bparam2"] = _val2;
            _container.Configuration["Bparam3"] = false;
            _container.Register<IB>("Bclass", delegate
            {
                return new B(_container.GetConfiguration<int>("Bparam1"), _container.GetConfiguration<string>("Bparam2"));
            });
            _container.Register<IB>("BclassConstr", delegate
            {
                return new B(_container.GetConfiguration<int>("Bparam1")+2, _container.GetConfiguration<string>("Bparam2")+"...", _container.GetConfiguration<bool>("Bparam3"));
            });
            var result = _container.Create<IB>("Bclass");
            var result2 = _container.Create<IB>("BclassConstr");
            Console.WriteLine("Reference equals between two container objects:{0}", object.ReferenceEquals(_container.Create<IB>("BclassConstr"), _container.Create<IB>("BclassConstr")));
            Console.WriteLine("Bparam1=={0}, Bparam2=={1}", result.Bval1 == _val1, result.GetVal2() == _val2);
            Console.WriteLine("Bparam2=={0}, Bparam2=={1}, Bparam2=={2}", result2.GetVal1() == _val1+2, result2.GetVal2() == _val2 + "...", result2.GetVal3()==false);
        }
    }
}
