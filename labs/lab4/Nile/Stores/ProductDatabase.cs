/*
 * ITSE 1430
 */
using System.Reflection.Metadata.Ecma335;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <inheritdoc />
        public Product Add ( Product product )
        {

            if (product == null)
                throw new ArgumentNullException(nameof(product));

            

            var existing = Get(product.Id);
            if (existing != null)
                throw new InvalidOperationException("Id must be unique");

            ObjectValidator.Validate(product);

            //Emulate database by storing copy
            return AddCore(product);
        }

        /// <inheritdoc />
        public Product Get ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            return GetCore(id);
        }

        /// <inheritdoc />
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }

        /// <inheritdoc />
        public void Remove ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");


            RemoveCore(id);
        }

        /// <inheritdoc />
        public Product Update ( Product product )
        {
            if (product.Id <= 0)
                throw new ArgumentOutOfRangeException(nameof(product.Id), "Id must be > 0.");

            if (product == null)
                throw new ArgumentNullException(nameof(product));


            ObjectValidator.Validate(product);

            //Get existing product
            var existing = GetCore(product.Id);

            return UpdateCore(existing, product);
        }

        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );
        #endregion
    }
}
