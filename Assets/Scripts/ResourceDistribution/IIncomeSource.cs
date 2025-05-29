using System;

namespace ResourceDistribution
{
    public interface IIncomeSource
    {
        event Action<int, IIncomeSource> ResourceRecieved;
    }
}