using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DIContainer
{
    /// <summary>
    /// Класс контейнер
    /// </summary>
    public class Container
    {
        [Description ("Делегат Creator")]
        public delegate object Creator(Container container);

        [Description("Словарь конфигураций")]
        private readonly Dictionary<string, object> _configuration
                       = new Dictionary<string, object>();

        [Description("Словарь типов")]
        private readonly Dictionary<string,ContainerObj> _typeToCreator
                       = new Dictionary<string, ContainerObj>();

        [Description("Словарь типов публичный")]
        public Dictionary<string, object> Configuration
        {
            get { return _configuration; }
        }

        /// <summary>
        /// Регистрация типа
        /// </summary>
        /// <Param name="name">Имя идентификатора для типа</Param>
        /// <Param name="creator">Делегат Creator</Param>
        /// <returns>void</returns>
        public void Register<T>(string name,Creator creator)
        {
            _typeToCreator.Add(name,new ContainerObj( typeof(T), creator));
        }

        /// <summary>
        /// Создание типа
        /// </summary>
        /// <Param name="name">Имя идентификатора для типа</Param>
        /// <returns>T</returns>
        public T Create<T>(string name)
        {
            return (T)_typeToCreator[name].CreatorDelegate(this);
        }

        /// <summary>
        /// Создание типа
        /// </summary>
        /// <Param name="name">Имя идентификатора для параметра</Param>
        /// <returns>T</returns>
        public T GetConfiguration<T>(string name)
        {
            return (T)_configuration[name];
        }

        /// <summary>
        /// Класс объекта контейнера контейнер
        /// </summary>
        private class ContainerObj
        {
            /// <Param name="type">Регестрируемый тип</Param>
            /// <Param name="creatorDelegate">Делегат Creator</Param>
            public ContainerObj(Type type,Creator creatorDelegate)
            {
                this.Type= type;
                this.CreatorDelegate = creatorDelegate;
            }

            [Description("Тип")]
            public Type Type { get; private set; }

            [Description("Делегат Creator")]
            public Creator CreatorDelegate { get; private set; }
        }
    }
  


}
