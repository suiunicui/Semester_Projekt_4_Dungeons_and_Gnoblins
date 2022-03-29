using Backend.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    internal class SaveGame
    {
        private DatabaseContext _context;

        public SaveGame()
        {
            _context = new DatabaseContext();
        }


    }
}

