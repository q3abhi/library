using System;
using System.Collections.Generic;
using ModelLibrary;
using NHibernate;

namespace DalLibrary
{
    public interface IDal<T>
    {
        IList<T> Read(String query);
        Boolean Save(IList<T> dataList);
        IList<T> Search(ICriteria criteriaQuery);
        NHibernate.ISession GetSession();

    }
}