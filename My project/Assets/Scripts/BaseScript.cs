using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseScript : MonoBehaviour
{

    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private float rateOfRegen;

    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
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
            Debug.Log("go");
            if (CurrentHealth < MaxHealth)
            {
                CurrentHealth++;
                updateHealthText();
            }
            yield return new WaitForSeconds(rateOfRegen);
        }

    }
}
