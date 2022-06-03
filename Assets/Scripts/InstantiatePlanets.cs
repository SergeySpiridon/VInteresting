using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlanets : MonoBehaviour
{
    [SerializeField]
    private ParsingText _parsingText;
    [SerializeField]
    private List<GameObject> _planets;

    private void Start()
    {
        EventManager.OnSpawnPlanets += SpawnPlanets;
    }
    private void SpawnPlanets()
    {
        Debug.Log("@$@$@!E");
        SpawnPlanetsLost();
       
        for (int i = 0; i < _parsingText.PointsToMove.Count; i++)
        {
            GameObject planet = _planets[Random.Range(0, _planets.Count)];
            var point = _parsingText.PointsToMove[i];
            var pointToMove = new Vector2(point[0], point[1]);
            Instantiate(planet, pointToMove, Quaternion.identity);
        }
        SpawnPlanetsLost();

    }
    //    private void SpawnPlanets()
    //    {
    //        int index = 0;
    //        foreach (var planet in _planets)

    //            var point = _parsingText.PointsToMovex[index];
    //        var pointToMove = new Vector2(point[0], point[1]);
    //        Instantiate(planet, pointToMove, Quaternion.identity);
    //    }
    //    ();
    //}
    private void SpawnPlanetsLost()
    {
        EventManager.OnSpawnPlanets -= SpawnPlanets;
    }
}
