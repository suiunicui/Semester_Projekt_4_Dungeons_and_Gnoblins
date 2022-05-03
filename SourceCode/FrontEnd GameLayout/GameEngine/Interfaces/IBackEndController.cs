using Backend_API.Models.DTO;
using System.Xml.Linq;

namespace GameEngine.Interfaces;

public interface IBackEndController
{
    public Task<SaveDTO> GetSaveAsync(int id);
    public void PostSaveAsync(SaveDTO save);
}