using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{

    public bool freezePlayer = true;
    private bool ignoreGravity = false;




    // Start is called before the first frame update
    void Start()
    {
        while (freezePlayer && !LevelController.Singleton.IsLevelReady()) 
        {
           if(Time.timeSinceLevelLoad % 15f == 0)
            {
                Debug.Log("Waiting for Level to be Ready");
            }
        }
        if(freezePlayer && LevelController.Singleton.IsLevelReady())
        {
            freezePlayer = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
