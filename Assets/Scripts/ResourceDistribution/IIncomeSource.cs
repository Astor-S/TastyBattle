using System;

public interface IIncomeSource
{
    event Action<int> ResourceRecieved;
}