using UnityEngine;

namespace DefaultNamespace
{
    public class DestructibleObject : MonoBehaviour
    {
        // [SerializeField] - говорит о том, что переменную можно редачить в юнити
        // текущее здоровье
        [SerializeField] private float hpCurrent = 100;


        // написанный нами кастомный метод (это не юнити метод!)
        // void: ничего не возвращает 
        // float damage: принимает некое дробное число
        public void ReceiveDamage(float damage)
        {
            // Вычитаем из текущего ХП урон
            // Можно писать и так: hpCurrent = hpCurrent - 1f;
            hpCurrent -= damage;

            // Если хп уменьшилось меньше нуля, то
            if (hpCurrent < 0f)
            {
                // Уничтожить себя
                Destroy(gameObject);
            }
        }
    }
}