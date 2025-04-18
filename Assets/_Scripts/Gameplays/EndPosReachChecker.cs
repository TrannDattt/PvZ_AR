using UnityEngine;

namespace PlantsZombiesAR.Gameplays
{
    public class EndPosReachChecker : MonoBehaviour{
        public bool IsReached { get; private set; }

        public void InitChecker(){
            IsReached = false;
        }

        private void OnTriggerEnter(Collider other){
            if (other.gameObject.layer == LayerMask.NameToLayer("Zombie")){
                IsReached = true;
            }
        }
    }
}
