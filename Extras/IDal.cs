using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;

namespace DalLibrary
{
    public interface IDal
    {
        int Create(String query);
        Object[] Read(String query);
    }
}