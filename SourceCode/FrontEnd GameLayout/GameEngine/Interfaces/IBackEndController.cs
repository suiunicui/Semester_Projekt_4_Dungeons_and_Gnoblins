using GameEngine.Models.DTO;
using System.Xml.Linq;

namespace GameEngine.Interfaces;

public interface IBackEndController
{
    public Task<SaveDTO> GetSaveAsync(int id);
    public Task PostSaveAsync(SaveDTO save);

    public Task PostRegisterAsync(UserDTO user);

    public Task PostLoginAsync(UserDTO user);
}