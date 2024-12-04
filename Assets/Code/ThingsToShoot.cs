using UnityEngine;

namespace Tetris.ThingsToShoot
{
    public class Projectile : MonoBehaviour
    {
        
        private int _pierce;
        private float _lifeTime;

        private Transform _refTransform;
        

        private Vector3 _velocity;

        

        public bool Tick(float dt)
        {
            


            _lifeTime -= dt;

            if (_lifeTime < 0)
            {

                gameObject.SetActive(false);
                return false;
            }

            return true;
        }
    }
}
