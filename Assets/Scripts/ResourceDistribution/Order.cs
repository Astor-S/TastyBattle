namespace ResourceDistribution
{
    public abstract class Order
    {
        private readonly float _costMultiplier;

        private int _cost;

        public Order(int cost, float costMultiplier = 1.1f)
        {
            _cost = cost;
            _costMultiplier = costMultiplier;
        }

        public bool IsAvailable { get; private set; } = true;
        public int Cost => _cost;

        public void IncreaseCost()
        {
            _cost = (int)(_cost * _costMultiplier);
        }

        protected void SetUnavailable()
        {
            IsAvailable = false;
        }
    }
}
