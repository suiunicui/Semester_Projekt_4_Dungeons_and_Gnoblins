using System.Xml.Linq;
using Backend_API.Models.DTO;

namespace GameEngine.Interfaces;

public interface IBackEndController
{
    public Task<SaveDTO> GetSaveAsync(int id);
    public void PostSaveAsync(SaveDTO save);
}