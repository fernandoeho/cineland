namespace Cineland.SharedKernel;

public abstract class Entity
{
    protected Entity(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; protected set; }
}
