using FitnessClub2.Model.Classes;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FitnessClub2.Model.Data
{
    class FcDAO
    {
        static FCContext context = new FCContext();

        public static IEnumerable<T> Get<T>() where T : BaseModel
        {
            try
            {
                var field = FindField(typeof(T));

                var value = (InternalDbSet<T>)field.GetValue(context);

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

        public static void Add<T>(BaseModel obj) where T : BaseModel
        {
            try
            {
                var field = FindField(typeof(T));

                var value = (InternalDbSet<T>)field.GetValue(context);

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
            //List<FieldInfo> fields = typeof(FCContext).GetFields(BindingFlags.Instance | BindingFlags.NonPublic).ToList();

            //foreach (var item in fields)
            //{
            //    var test = item.GetValue(context).GetType().GetGenericArguments()[0].Name;

            //    if (test == type.Name)
            //    {
            //        try
            //        {
            //            var value = (InternalDbSet<Client>)item.GetValue(context);


            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine($"Исключение: {ex.Message}");
            //            Console.WriteLine($"Метод: {ex.TargetSite}");
            //            Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
            //        }
            //    }
            //}
            //return null;

            //List<FieldInfo> fields = typeof(FCContext).GetFields(BindingFlags.Instance | BindingFlags.NonPublic).ToList();

            //FieldInfo field = fields.Where(x => x.GetValue(context).GetType().GetGenericArguments()[0].Name == type.Name).Single();

            return typeof(FCContext).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                   .ToList()
                   .Where(x => x.GetValue(context).GetType().GetGenericArguments()[0].Name == type.Name)
                   .Single();
        }
    }
}
