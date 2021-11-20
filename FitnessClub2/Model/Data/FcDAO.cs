using FitnessClub2.Model.Classes;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FitnessClub2.Model.Data
{
    public static class FcDAO
    {
        static FCContext context = new FCContext();

        public static List<T> Get<T>() where T : BaseModel
        {            
            try
            {
                FieldInfo field = FindField(typeof(T));

                InternalDbSet<T> value = (InternalDbSet<T>)field.GetValue(context);

                return value.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
                Console.WriteLine($"Метод: {ex.TargetSite}");
                Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
                return null;
            }
        }

        public static List<T> Get<T>(int count) where T : BaseModel
        {            
            try
            {
                FieldInfo field = FindField(typeof(T));

                InternalDbSet<T> value = (InternalDbSet<T>)field.GetValue(context);

                int length = value.Count();

                if (length <= count)
                {
                    return value.ToList();
                }
                else
                {
                    return value.ToList().GetRange(length - count, count);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
                Console.WriteLine($"Метод: {ex.TargetSite}");
                Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
                return null;
            }
        }

        public static void Add<T>(BaseModel obj) where T : BaseModel
        {
            try
            {
                FieldInfo field = FindField(typeof(T));

                InternalDbSet<T> value = (InternalDbSet<T>)field.GetValue(context);

                value.Add((T)obj);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
                Console.WriteLine($"Метод: {ex.TargetSite}");
                Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
            }
        }

        public static void AddRange<T>(BaseModel[] obj) where T : BaseModel
        {
            try
            {
                var field = FindField(typeof(T));

                var value = (InternalDbSet<T>)field.GetValue(context);

                value.AddRange((T[])obj);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
                Console.WriteLine($"Метод: {ex.TargetSite}");
                Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
            }
        }

        private static FieldInfo FindField(Type type)
        {
            return typeof(FCContext).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                   .ToList()
                   .Where(x => x.GetValue(context).GetType().GetGenericArguments()[0].Name == type.Name)
                   .Single();
        }
    }
}
