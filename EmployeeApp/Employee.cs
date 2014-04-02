using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace EmployeeApp
{
    public class Employee
    {
        public string Name { get; set; }
        public double basicsalary { get; set; }
        public virtual double salary { get; set; }

        public override string ToString()
        {
            return "Employees";
        }
    }
    public class Boss : Employee
    {
        public override double salary { get { return basicsalary * 2.5; } set { } }

        public override string ToString()
        {
            return "Boss";
        }
    }

    public class Manager : Employee
    {
        public override double salary { get { return basicsalary * 1.5; } set { } }
        public override string ToString()
        {
            return "Manager";
        }
    }
    public class storekeeper : Employee
    {
        public override double salary { get { return basicsalary * 0.5; } set { } }
        public override string ToString()
        {
            return "StoreKeeper Here";
        }
    }

    public static class VType
    {
        public static List<Type> GetDerivedTypes(Type baseType, Assembly assembly)
        {
            // Get all types from the given assembly
            Type[] types = assembly.GetTypes();
            List<Type> derivedTypes = new List<Type>();

            for (int i = 0, count = types.Length; i < count; i++)
            {
                Type type = types[i];
                if (VType.IsSubclassOf(type, baseType))
                {
                    // The current type is derived from the base type,
                    // so add it to the list
                    derivedTypes.Add(type);
                }
            }

            return derivedTypes;
        }

        public static bool IsSubclassOf(Type type, Type baseType)
        {
            if (type == null || baseType == null || type == baseType)
                return false;

            if (baseType.IsGenericType == false)
            {
                if (type.IsGenericType == false)
                    return type.IsSubclassOf(baseType);
            }
            else
            {
                baseType = baseType.GetGenericTypeDefinition();
            }

            type = type.BaseType;
            Type objectType = typeof(object);

            while (type != objectType && type != null)
            {
                Type curentType = type.IsGenericType ?
                    type.GetGenericTypeDefinition() : type;
                if (curentType == baseType)
                    return true;

                type = type.BaseType;
            }

            return false;
        }
    }



    public class AnimalTypeDescriptionProvider : TypeDescriptionProvider
    {
        public AnimalTypeDescriptionProvider(): base(TypeDescriptor.GetProvider(typeof(Employee)))
        {

        }
        public override Type GetReflectionType(Type objectType, object instance)
        {
            return base.GetReflectionType(typeof(Employee), instance);
        }
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            return base.GetTypeDescriptor(typeof(Employee), instance);
        }
        public static void Register()
        {
            TypeDescriptor.AddProvider(new AnimalTypeDescriptionProvider(), typeof(Employee));
        }

    }


}


