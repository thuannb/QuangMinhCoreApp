using System;
using System.Collections.Generic;
using System.Text;

namespace KBStarCoreApp.Infrastructure.SharedKernel
{
    public abstract class DomainEntity<T>
    {
        /// <summary>
        /// Dùng để tạo ra cột Id dùng chung.
        /// </summary>
        public T Id { get; set; }

        /// <summary>
        /// True if domain entity has an identity
        /// </summary>
        /// <returns></returns>
        public bool IsTransient()
        {
            return Id.Equals(default(T));
        }
    }
}
