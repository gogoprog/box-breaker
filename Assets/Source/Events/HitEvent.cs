
public class HitEvent : EgoEvent
{
    public float damage;
    public EgoComponent target;

    public HitEvent(float damage, EgoComponent target)
    {
        this.damage = damage;
        this.target = target;
    }
}