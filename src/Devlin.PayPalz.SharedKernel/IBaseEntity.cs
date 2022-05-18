namespace Devlin.PayPalz.SharedKernel
{
    public interface IBaseEntity
    {
        int Id { get; set; }

        List<IBaseDomainEvent> Events { get; set; }
    }
}