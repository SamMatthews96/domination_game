using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour
{
    [SerializeField] private GameObject teamPrefab;
    [SerializeField] private int numberOfTeams;

    private List<TeamScript> teams = new();
    // Start is called before the first frame update
    void Start()
    {
        CreateTeams();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateTeams()
    {
        for (int i = 0; i < numberOfTeams; i++)
        {
            GameObject newTeamObject = Instantiate(teamPrefab);
            TeamScript script = newTeamObject.GetComponent<TeamScript>();
            script.teamNumber = i + 1;
            teams.Add(script);
            
        }
    }
}
