using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamScript : MonoBehaviour
{
    [SerializeField] private GameObject basePrefab;

    public int teamNumber;
    public float resources;
    private List<BaseScript> bases = new();
    private Color teamColor;

    public Color TeamColor
    {
        set { teamColor = value; }
    }




    public void CreateBase(Vector2 position)
    {
        GameObject newBase = Instantiate(basePrefab,position,Quaternion.identity);
        BaseScript baseScript = newBase.GetComponent<BaseScript>();
        baseScript.TeamNumber = teamNumber;
        SetBaseColor(baseScript);
        bases.Add(baseScript);
    }

    void SetBaseColor(BaseScript baseScript)
    {
        SpriteRenderer renderer = baseScript.gameObject.GetComponent<SpriteRenderer>();
        renderer.color = teamColor;
    }
}
