using System;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace PatternsExamples.GoF.Creational.FabricMethod.Common {
    public class Start
    {
        public Start()
        {
            var product = ProductFactory.Create<ConcreteProduct>();
        }
    }

    public abstract class Product {
        protected internal abstract void PostConstruction();
    }

    public class ConcreteProduct : Product {
        // Внутренний конструктор не позволит клиентам иерархии
        // создавать объекты напрямую.
        public ConcreteProduct() {
        }

        protected internal override void PostConstruction() {
            Console.WriteLine("ConcreteProduct: post construction");
        }
    }

    // Единственно законный способ создания объектов семейства Product
    public static class ProductFactory {
        public static T Create<T>() where T : Product, new() {
            try {
                var t = new T();

                // Вызываем постобработку
                t.PostConstruction();
                return t;
            }
            catch (TargetInvocationException e) {
                // «разворачиваем» исключение и бросаем исходное
                var edi = ExceptionDispatchInfo.Capture(e.InnerException);
                edi.Throw();
                // эта точка недостижима, но компилятор об этом не знает!
                return default(T);
            }
        }
    }
}