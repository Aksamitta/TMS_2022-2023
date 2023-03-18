using Lab26_EFCore_Practice.Models;
using System.Data.Entity;

namespace Lab26_EFCore_Practice.Services
{
    public class AutoService
    {
        List <Auto> autos = new List<Auto> ();

        public List<Auto> ShowAutosInShop()

        {
            using (var context = new Lab26AutoContext())
            {
                var autos = context.Autos.Include(p => p.Magazines).ToList();
                return autos.ToList();
            }
        }

        public Auto AddAuto(Auto auto)
        {
            using (var context = new Lab26AutoContext())
            {
                //auto.AutoId = ReturnFreeId();
                context.Add(auto);
                context.SaveChanges();
                return (auto);
            }
            //public Auto AddAuto([FromForm] string model, [FromForm] int year, [FromForm] decimal price)
            //{
            //    using (var context = new Lab26AutoContext())
            //    {
            //        var auto = new Auto { AutoModel = model, Year = year, Price = price };
            //        context.Add(auto);
            //        context.SaveChanges();
            //        return auto;
            //    }
        }

        //public int ReturnFreeId()
        //{
        //    var id = from auto in autos
        //             orderby auto.AutoId
        //             select auto.AutoId;

        //    var result = Enumerable.Range(1, int.MaxValue).Except(id).First();
        //    return result;
        //}
    }
}
