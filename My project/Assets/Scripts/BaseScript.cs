using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseScript : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;
    [SerializeField] private float rateOfRegen;

    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        updateHealthText();
        StartCoroutine(HealthIncrease());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateHealthText()
    {
        GameObject canvas = gameObject.transform.Find("Canvas").gameObject;
        GameObject textObject = canvas.transform.Find("Health").gameObject;
        TextMeshProUGUI textMeshPro = textObject.GetComponent<TextMeshProUGUI>();
        textMeshPro.text = currentHealth.ToString();
    }

    IEnumerator HealthIncrease()
    {
        while (true){
            if (currentHealth < maxHealth)
            {
                currentHealth++;
                updateHealthText();
            }
            yield return new WaitForSeconds(rateOfRegen);
        }

    }
}
