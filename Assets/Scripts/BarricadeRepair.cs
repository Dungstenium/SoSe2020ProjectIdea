using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Barricade
{
    public class BarricadeRepair : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI repairText;
        bool isRepaired = false;
        private void OnTriggerStay(Collider other)
        {
            BarricadeHealth barricadeHealth = GetComponent<BarricadeHealth>();

            if (other.CompareTag("Player") && Input.GetButton("Interact"))
            {
                barricadeHealth.RepairBarricade(Time.deltaTime);
                repairText.text = "Reparing";

                if (barricadeHealth.GetHealth() == 10.0f)
                {
                    repairText.text = "Repared";
                    isRepaired = true;
                }
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!isRepaired)
            {
                repairText.text = "Press [F] to repair";

                repairText.gameObject.SetActive(true);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            repairText.gameObject.SetActive(false);
        }
    }
}
