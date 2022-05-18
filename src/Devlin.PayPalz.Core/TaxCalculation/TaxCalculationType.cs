using Ardalis.SmartEnum;

namespace Devlin.PayPalz.Core.TaxCalculation
{
    public class TaxCalculationType : SmartEnum<TaxCalculationType>
    {
        public static readonly TaxCalculationType Progressive = new(nameof(Progressive), 0);
        public static readonly TaxCalculationType FlatRate = new(nameof(FlatRate), 1);
        public static readonly TaxCalculationType FlatValue = new (nameof(FlatValue), 2);

        public TaxCalculationType(string name, int value) : base(name, value)
        {
        }
    }
}
