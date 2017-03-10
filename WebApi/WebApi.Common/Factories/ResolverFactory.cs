namespace WebApi.Common.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public static class ResolverFactory
    {
 
        //public static T GetService<T>()
        //   where T : class
        //{
        //    return (T)_kernel.GetService(typeof(T));
        //}

        public static T CreateInstance<T>(string typeName)
            where T : class
        {

            Type type = Type.GetType(typeName);

            T instance = (T)Activator.CreateInstance(type);

            return instance;
        }

        public static T CreateInstance<T>(string typeName, params object[] args)
            where T : class
        {

            Type type = Type.GetType(typeName);

            T instance = (T)Activator.CreateInstance(type, args);

            return instance;
        }

        public static T GetPropValue<T>(this object src, string propName)
        {
            return (T)src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}
