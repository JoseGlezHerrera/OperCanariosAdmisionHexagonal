using Oper.Admision.Domain;
using System.Transactions;

namespace Oper.Admision.Infrastructure
{
    public class GestionUOW : IGestionUOW, IDisposable
    {
        private GestionContext _context;

        public GestionUOW(GestionContext context)
        {
            this._context = context;
        }

        public int Save()
        {
            int rowsAffected = this._context.SaveChanges();

            this._context.DetachAllEntities();

            return rowsAffected;
        }

        public void BeginTransaction()
        {
            if (this._context.Database.CurrentTransaction != null)
                throw new TransactionException("No se puede iniciar otra transacción por que hay una en uso.");

            this._context.Database.BeginTransaction(); 
        }

        public void Commit()
        {
            if (this._context.Database.CurrentTransaction == null)
                throw new TransactionException("No se puede hacer commit ya que no existe transacción.");

            this._context.Database.CurrentTransaction.Commit();
        }

        public void RollBack()
        {
            if (this._context.Database.CurrentTransaction == null)
                throw new TransactionException("No se puede hacer rollback ya que no existe transacción.");

            this._context.Database.CurrentTransaction.Rollback();
        }

        public void Dispose()
        {
            if (this._context != null)
            {
     
                this._context.DisposeAsync();
            }
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}

