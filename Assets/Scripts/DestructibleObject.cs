using UnityEngine;

namespace DefaultNamespace
{
    public class DestructibleObject : MonoBehaviour
    {
        [SerializeField] private float hpInitial = 100;
        [SerializeField] private float hpCurrent = 100;


        public void ReceiveDamage()
        {
            hpCurrent -= 1f;
            // Можно писать и так: hpCurrent = hpCurrent - 1f;

            if (hpCurrent < 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}