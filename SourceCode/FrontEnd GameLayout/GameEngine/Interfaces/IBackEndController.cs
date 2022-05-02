using System.Xml.Linq;
using DataBase.Models;

namespace GameEngine.Interfaces;

public interface IBackEndController
{
    public Task<Save> GetSaveAsync(int id);
    public void PostSaveAsync(Save save);
}