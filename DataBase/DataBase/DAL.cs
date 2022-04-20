using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Models;

namespace DataBase
{
    public class DAL
    {
        public static void SaveGame(Save save)
        {
            var context = new MyDbContext();

            context.Add(save);

            context.SaveChanges();

        }


        public static Save GetSaveByID(int SaveId)
        {
            var Context = new MyDbContext();

            var saves = Context.Saves.Where(s => s.ID == SaveId);

            foreach (var save in saves)
            {
                if (save.ID == SaveId)
                    return save;
            }

            return null;

        }
    }
}
