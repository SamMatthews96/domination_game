using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamScript : MonoBehaviour
{
    public int teamNumber;
    public float resources;
    [SerializeField] private GameObject basePrefab;
    // Start is called before the first frame update
    void Start()
    {
        NewBase(new Vector2(teamNumber, teamNumber));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NewBase(Vector2 position)
    {
        GameObject newBase = Instantiate(basePrefab,position,Quaternion.identity);
        BaseScript baseScript = newBase.GetComponent<BaseScript>();
        baseScript.CurrentHealth = 0;
    }
}
