using System.Collections;
using PlantsZombiesAR.Zombies;
using UnityEngine;

namespace PlantsZombiesAR.Projectiles
{
    public class Explosion : ProjectileController{
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public ParticleSystem Particle { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Zombie"))
            {
                var zombie = other.gameObject.GetComponentInParent<ZombieController>();
                zombie.ChangeHealth(Damage);

                DestroyProjectile();
            }
        }

        public override void DestroyProjectile()
        {
            StartCoroutine(Explode());

            IEnumerator Explode(){
                Particle.Play();

                yield return new WaitForSeconds(ExistTime);
                base.DestroyProjectile();
            }

        }
    }
}
