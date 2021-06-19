public interface IDamagable
{
    void Damage(float amount);

    bool IsDestroyed();

    void Destroyed();
}