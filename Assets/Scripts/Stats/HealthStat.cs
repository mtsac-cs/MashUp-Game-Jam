public class HealthStat : StatModel, IDamagable
{
    void Start()
    {
        
    }

    public void Damage(float amount)
    {
        DecreaseValue(amount);
    }

    public void Destroyed()
    {

    }

    public bool IsDestroyed()
    {
        return CurrentValue <= 0;
    }
}