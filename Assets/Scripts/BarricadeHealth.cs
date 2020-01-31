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
        [SerializeField] Transform[] woodenBarricade;
        int quantityOfChildren;
        void Start()
        {
            quantityOfChildren = transform.childCount;
            health = 0.0f;
            healthPercentage = health / maxHealth;


            for (int i = 0; i < quantityOfChildren; i++)
            {
                woodenBarricade[i] = transform.GetChild(i);
            }
        }
        void Update()
        {
            healthPercentage = health / maxHealth;
            Debug.Log(healthPercentage);
            for (int i = 0; i < transform.childCount; i++)
            {
                if (healthPercentage >= (maxHealth / (quantityOfChildren - i)) / healthPercentage)
                {
                    woodenBarricade[i].gameObject.SetActive(true);
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
        }
    }
}
