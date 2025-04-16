using AttackSystem;
using StructureElements;
using System;

namespace ResourceDistribution
{
    public class Wallet : IActivatable
    {
        private int _resourceCount;
        private readonly IIncomeSource _mine;

        public Wallet(int startResourceCount, IIncomeSource mine)
        {
            _resourceCount = startResourceCount;
            _mine = mine;
        }

        public event Action ResourceSpend;
        public event Action ResourceRecieved;

        public int ResourceCount => _resourceCount;

        public void Enable()
        {
            _mine.ResourceRecieved += GetResource;
        }

        public void Disable()
        {
            _mine.ResourceRecieved -= GetResource;
        }

        public void AddUnitAsIncomeSource(IIncomeSource unit)
        {
            unit.ResourceRecieved += GetResource;
        }

        public void SpendResource(int count)
        {
            if (_resourceCount - count < 0)
                throw new InvalidOperationException("Not enough resources.");

            _resourceCount -= count;

            ResourceSpend?.Invoke();
        }

        private void GetResource(int count, IIncomeSource incomeSource)
        {
            _resourceCount += count;

            ResourceRecieved?.Invoke();

            if (incomeSource is DamagableTarget)
                incomeSource.ResourceRecieved -= GetResource;
        }
    }
}
