using ContosoUniversity.Domain.Entities.Base;
using ContosoUniversity.Domain.Interfaces;
using ContosoUniversity.Domain.Entities;

namespace ContosoUniversity.Infrastructure.Repositories{
    public class CrudRepository<T> : ICrudRepository<T> where T : BaseEntity{
        protected readonly DBLocalContosoUniversity _dbContext;
        protected IEnumerable<T>? _entities;

        private void SetEntity(Type T){
            if(typeof(T) == typeof(Person)){
                _entities = (IEnumerable<T>)_dbContext.Persons;
            }else if(typeof(T) == typeof(Course)){
                _entities = (IEnumerable<T>)_dbContext.Courses;
            }else if(typeof(T) == typeof(Department)){
                _entities = (IEnumerable<T>)_dbContext.Departments;
            }
        }

        public IEnumerable<T> GetAll(){
            return _entities!;
        }

        public T GetById(int id){
            return _entities!.Single<T>(x => x.Id == id);
        }

        public IEnumerable<T> FindBy(Func<T, bool> filters){
            return _entities!.Where<T>(filters);
        }

        public CrudRepository(){
            _dbContext = new DBLocalContosoUniversity();
            SetEntity(typeof(T));
        }
    }
}