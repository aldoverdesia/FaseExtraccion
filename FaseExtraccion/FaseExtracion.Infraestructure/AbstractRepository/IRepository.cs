using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FaseExtracion.Infraestructure.AbstractRepository
{
  
        public interface IRepository<T> where T : class, new()
        {
            /// <summary>
            ///  Adiciona un objeto
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            Task<T> AddAsync(T entity);

            /// <summary>
            /// Actualiza un objeto
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            Task<T> UpdateAsync(T entity);

            /// <summary>
            /// Elimina un objeto
            /// </summary>
            /// <param name="entity"></param>
            /// <returns></returns>
            Task DeleteAsync(T entity);

            /// <summary>
            /// Elimina un objeto segun una condicion
            /// </summary>
            /// <param name="predicate"></param>
            /// <returns></returns>
            Task DeleteByPredicateAsync(Expression<Func<T, bool>> predicate);

            /// <summary>
            ///  Obtiene un objeto dado el identificador
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            Task<T> GetByIdAsync(int id);

            /// <summary>
            /// Obtiene una colección de objetos dado un predicado
            /// </summary>
            /// <param name="predicate"></param>
            /// <returns></returns>
            IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate = null);

            /// <summary>
            /// Obtiene una colección de objetos dado un predicado
            /// </summary>
            /// <param name="predicate"></param>
            /// <returns></returns>
            IEnumerable<T> GetAllByPredicate(Expression<Func<T, bool>> predicate);

            /// <summary>
            /// Obtiene una colección de objetos dado un predicado y los parametros para paginar
            /// </summary>
            /// <param name="predicate"></param>
            /// <param name="page"></param>
            /// <param name="pageSize"></param>
            /// <returns></returns>

            /// <summary>
            /// Retorna el número de elementos que coinciden con un predicado dado
            /// </summary>
            /// <param name="predicate"></param>
            /// <returns></returns>
            int Count(Expression<Func<T, bool>> predicate = null);

            Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

            bool Any(Expression<Func<T, bool>> predicate);

        }
    }

