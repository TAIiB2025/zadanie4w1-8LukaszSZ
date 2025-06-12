using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IKsiazkaService
    {
        List<KsiazkaDTO> Get();
        KsiazkaDTO GetById(int id);
        void Delete(int id);
        void Put(int id, KsiazkaBodyDTO body);
        void Post(KsiazkaBodyDTO body);
    }
}
