using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Barricade
{
    public class BarricadeHealth : MonoBehaviour
    {
        float health;
        float healthPercentage;
        [SerializeField] float maxHealth = 10;
        Transform[] woodenBarricade;
        int quantityOfChildren;
        void Start()
        {
            quantityOfChildren = transform.childCount;
            health = 0.0f;
            healthPercentage = health / maxHealth;

            woodenBarricade = new Transform[quantityOfChildren];

            for (int i = 0; i < quantityOfChildren; i++)
            {
                woodenBarricade[i] = transform.GetChild(i);
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && Input.GetButton("Interact"))
            {
                healthPercentage = health / maxHealth;

                for (int i = 0; i < transform.childCount; i++)
                {
                    if (healthPercentage >= ((1.0f + i) / quantityOfChildren))
                    {
                        woodenBarricade[i].gameObject.SetActive(true);
                    }
                }
            }
        }
        public float GetHealth() 
        {
            return health;
        }
        public void RepairBarricade(float value)
        {
            health += value;
            health = Mathf.Clamp(health, 0.0f, maxHealth);
        }
    }
}
