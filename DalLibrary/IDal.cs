using System;
using System.Collections.Generic;
using ModelLibrary;

namespace DalLibrary
{
    public interface IDal<T>
    {
        IList<T> Read(String query);
        Boolean Save(IList<T> dataList);
    }
}