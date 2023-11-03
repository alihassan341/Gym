using Gym_Management_System.Data;
using Gym_Management_System.Entities;

namespace Gym_Management_System.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private Context _context;
        public EquipmentRepository(Context context)
        {
                this._context = context;
        }
        public void Create(Equipment Equipments)
        {
            _context.Equipments.Add(Equipments);
        }
        public void Delete(long Id)
        {
            var equipments = _context.Equipments.Find(Id);
            _context.Equipments.Remove(equipments);
        }
        public IList<Equipment> GetAll()
        {
            return _context.Equipments.ToList();
        }
        public IList<Equipment> GetById(long Id)
        {
            return _context.Equipments.Where(p=>p.Id == Id).ToList();
        }
        public void Save()
        {
         _context.SaveChanges();
        }
        public void Update(Equipment equipments)
        {
            _context.Equipments.Update(equipments);
        }
    }
}
