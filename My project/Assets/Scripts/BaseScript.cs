using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseScript : MonoBehaviour
{
    [SerializeField] private GameObject world;
    [SerializeField] private float rateOfRegen;
    [SerializeField] private int maxHealth;

    private WorldScript worldScript;
    private int currentHealth;
    private int teamNumber;

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
    public int TeamNumber
    {
        get { return teamNumber; }
        set { teamNumber = value; }
    }

    void Start()
    {
        worldScript = world.GetComponent<WorldScript>();
        CurrentHealth = MaxHealth;
        UpdateHealthText();
        StartCoroutine(HealthIncrease());
    }
    void OnMouseDown()
    {
        TrySelectPlayerBase();
    }

    void UpdateHealthText()
    {
        GameObject canvas = gameObject.transform.Find("Canvas").gameObject;
        GameObject textObject = canvas.transform.Find("Health").gameObject;
        TextMeshProUGUI textMeshPro = textObject.GetComponent<TextMeshProUGUI>();
        textMeshPro.text = CurrentHealth.ToString();
    }
    IEnumerator HealthIncrease()
    {
        while (true){
            if (CurrentHealth < MaxHealth)
                ChangeHealth(1);
            yield return new WaitForSeconds(rateOfRegen);
        }

    }
    
    public void ChangeHealth(int delta)
    {
        CurrentHealth += delta;
        UpdateHealthText();
    }

    private void TrySelectPlayerBase()
    {
        if (TeamNumber == 1)
            worldScript.SelectedBase = gameObject;
        
          
    }
}

