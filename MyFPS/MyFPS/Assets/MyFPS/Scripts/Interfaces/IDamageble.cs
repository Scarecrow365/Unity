namespace MyFPS
{
    public interface IDamageble 
    {
        void GetDamage(float damage);
        float MaxHealth { get; }
        float CurrentHealth { get; }
    }
}

