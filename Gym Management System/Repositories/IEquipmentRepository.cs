using Gym_Management_System.Entities;

namespace Gym_Management_System.Repositories
{
    public interface IEquipmentRepository
    {
        public IList<Equipment> GetById(long Id);
        public IList<Equipment> GetAll();
        public void Create(Equipment Equipments);
        public void Update(Equipment Equipments);
        public void Delete(long Id);
        public void Save();
    }
}
