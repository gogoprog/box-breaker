using UnityEngine;

public class HitSystem : EgoSystem 
{
    public override void Start()
    {
        EgoEvents<HitEvent>.AddHandler(Handle);
    }

    public override void Update()
    {

    }

    public void Handle(HitEvent e)
    {
       var life = e.target.GetComponent<Life>();
       life.life -= e.damage;

       if(life.life <= 0)
       {
           var explosion = Factory.createExplosion();
           explosion.transform.position = e.target.transform.position;

           Ego.DestroyGameObject(e.target);
       }
    }
}
