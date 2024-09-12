using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using static LevelData;
/// <summary>
/// When This level Loads, the Level Controllers task is to manage data parsed on load, and prepare the variables from saves and position of the player and state of the game.
/// In Addition to this, the Level Controller also handles checkpoints, and is to function as a temporary singleton for the level's scope.
/// </summary>
public class LevelController : MonoBehaviour
{
    public static LevelController Singleton;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject levelStartPoint;
    private int isLevelReady = 0;
    private int readyWhen = 1;
    LevelData levelData;
    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Debug.LogError("LevelController.Singleton Already exist, Singleton may not have multiple instances");
            Debug.Break();
        }
        levelData = new(SceneManager.GetActiveScene().name);
        //levelData = ScriptableObject.CreateInstance("LevelData(" + SceneManager.GetActiveScene().name + ")") as LevelData;

        PlacePlayerOnLoad(levelData);

    }
    /// <summary>
    /// Not Yet Implemented. LevelData is a future class and payload to handle saves, and replays.
    /// </summary>
    /// <param name="LevelData"></param>
    public void UnloadLevel(LevelData levelData) //NYI
    {
        //handle unloads


        Destroy(Singleton); //In the end this won't be needed, it's just here to keep the intention clear that unloads are handled before the level unloads, but must not cause new level loads to conflict. But as long as DontDestroyOnLoad is not called this shouldn't be a problem in the first place.
    }


    private void PlacePlayerOnLoad(LevelData levelData)
    {
        if(levelData.startPointToUse == levelData.levelStartingPoint)
        {
            player.transform.position = levelStartPoint.transform.position;
            player.transform.rotation = levelStartPoint.transform.rotation;

        }
        else
        {   switch (levelData.startPointToUse)
            {
                case 1:
                    {
                        player.transform.position = GameObject.Find(Enum.GetName(typeof(checkpointEnum), 1)).transform.position;
                        player.transform.rotation = GameObject.Find(Enum.GetName(typeof(checkpointEnum), 1)).transform.rotation;
                        //player.transform.position = levelData.checkpoints[(int)levelData.checkpointEnum.checkpoint1].position;
                        //player.transform.rotation = levelData.checkpoints[(int)levelData.checkpointEnum.checkpoint1].rotation;
                        break;
                    }
                default:
                    {
                        player.transform.position = levelStartPoint.transform.position;
                        player.transform.rotation = levelStartPoint.transform.rotation;
                        break;
                    }

            }


        }
        isLevelReady++;
    }
    public bool IsLevelReady()
    {
        return isLevelReady == readyWhen;
    }

}
public class LevelData
{
    public enum checkpointEnum { fallbackvalue, checkpoint1}; // Must reflect the GameObject Name
    public int startPointToUse = 0;
    public int levelStartingPoint = 0;
    private ScriptableObject scriptableObject; // not sure this is ever needed.

    public LevelData(string sceneName)
    {
        //Load Save Files using sceneName here
        Debug.Log(sceneName);
        if (sceneName == "Level1Prototype")
        {
            string path = Application.persistentDataPath + "/" + sceneName+".txt";
            //Read the text from directly from the test.txt file
            StreamReader reader = new StreamReader(path);
            string loadedstring = reader.ReadToEnd();
            reader.Close();
            Debug.Log(loadedstring);
            //Enum.TryParse(reader.ReadLine(), false, out checkpointEnum result);
            try
            {
                startPointToUse = (int)Enum.Parse(typeof(checkpointEnum), loadedstring);

            }
            catch
            {


            }


        }
    }







}