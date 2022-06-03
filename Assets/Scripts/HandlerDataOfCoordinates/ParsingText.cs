using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class ParsingText : MonoBehaviour
{
    private JsonForm _jsonLink = new JsonForm();
    public List<float[]> PointsToMove { get; private set; }
    private string _path;

    private void Awake()
    {
        _path = Application.streamingAssetsPath + "/" + "Data.json";
        AsyncGetData();

    }
    //Десериализация данных из файла
    private void DeserializeText(string path)
    {
        var jsonParse = File.ReadAllText(path);
        _jsonLink = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonForm>(jsonParse);
        var handleText = new HandleText(_jsonLink);
        Debug.Log(handleText.GetClosureParametr());
        PointsToMove = handleText.HandlePoints();
        //Вызываем событие
        EventManager.SpawnPlanets();
        foreach(var point in PointsToMove)
        {
            foreach (var item in point)
            {
                Debug.Log(item);
            }
          
        }
}
    //Асинхронное обращение к методу
    private async Task AsyncGetData()
    {
        Debug.Log("Start");
        await Task.Run(() => DeserializeText(_path));
        Debug.Log("End");
    }
}
