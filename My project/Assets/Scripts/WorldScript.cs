using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour
{
    [SerializeField] private GameObject teamPrefab;
    [SerializeField] private int numberOfTeams;

    [SerializeField] private GameObject selectedBase;

    private List<TeamScript> teams = new();

    public GameObject SelectedBase
    {
        set { selectedBase = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateTeams();
        CreateInitialBases();
    }
    void CreateInitialBases()
    {
        foreach (TeamScript teamScript in teams)
        {
            double arg = 2 * Math.PI / numberOfTeams * teamScript.teamNumber;
            Vector2 position = new Vector2((float)Math.Sin(arg), (float)Math.Cos(arg));
            teamScript.CreateBase(position * 3);
        }
    }
    void CreateTeams()
    {
        for (int team = 1; team <= numberOfTeams; team++)
        {
            GameObject newTeamObject = Instantiate(teamPrefab);
            TeamScript teamScript = newTeamObject.GetComponent<TeamScript>();
            teamScript.teamNumber = team;
            teamScript.TeamColor = GetTeamColor(team);
            teams.Add(teamScript);
        }
    }
    Color GetTeamColor(int teamNumber)
    {
        float hue = teamNumber / (float)numberOfTeams;
        return Color.HSVToRGB(hue,0.5f,0.5f);
    }




}
