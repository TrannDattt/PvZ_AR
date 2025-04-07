using PlantsZombiesAR.Zombies;
using UnityEngine;

namespace PlantsZombiesAR.Projectiles
{
    public class Bullet : ProjectileController
    {
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Zombie"))
            {
                var zombie = other.gameObject.GetComponentInParent<ZombieController>();
                zombie.ChangeHealth(Damage);

                DestroyProjectile();
            }
        }
    }
}
