using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Barricade
{
    public class BarricadeRepair : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI repairText;
        BarricadeHealth barricadeHealth;
        private void Start()
        {
            //this.health = GetComponent<BarricadeHealth>().health;  
            barricadeHealth = GetComponent<BarricadeHealth>();
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && Input.GetButton("Interact"))
            {
                barricadeHealth.RepairBarricade(Time.deltaTime);
                //health += Time.deltaTime;
                //Mathf.Clamp(health, 0, 10);
                //Debug.Log(health);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            repairText.gameObject.SetActive(true);
        }
        private void OnTriggerExit(Collider other)
        {
            repairText.gameObject.SetActive(false);
        }
    }
}
