using System;
using SQLite;

namespace ShoppingApp.Model
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();

    }
}
