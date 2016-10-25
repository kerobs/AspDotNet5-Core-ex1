using System;
using System.Data;
using System.Data.Common;

namespace website.Services
{
    internal class SqlDataAdapter
    {
        private DbCommand cmd;

        public SqlDataAdapter(DbCommand cmd)
        {
            this.cmd = cmd;
        }

        internal void Fill(DataTable dt)
        {
            throw new NotImplementedException();
        }
    }
}