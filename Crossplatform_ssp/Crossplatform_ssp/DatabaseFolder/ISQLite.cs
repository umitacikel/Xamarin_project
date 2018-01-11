using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crossplatform_ssp.DatabaseFolder
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
