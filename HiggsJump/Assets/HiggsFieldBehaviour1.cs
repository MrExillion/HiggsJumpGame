using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HiggsFieldBehaviour1 : MonoBehaviour
{
    [SerializeField] private float lifetime = 120f;
    [SerializeField] private Quaternion ArtificialGravityDirection;
    [SerializeField] private float gravitationalFieldForce = 0.05f;

    public List<GameObject> ObjectsInField = new List<GameObject>();

    private void Update()
    {
        lifetime -= Time.deltaTime;

        if( lifetime <= 0)
        {

            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        foreach(GameObject go in ObjectsInField)
        {
            go.GetComponent<Rigidbody>().AddRelativeForce(ArtificialGravityDirection.eulerAngles * gravitationalFieldForce);
        }

        

    }
    public void SetDirection(Vector3 direction)
    {
        ArtificialGravityDirection = Quaternion.Euler(direction);
    }

    public void OnEnable()
    {
        //LevelController.Singleton.CurrentHiggsField = gameObject;
    }


    public void Remove()
    {
        LevelController.Singleton.CurrentHiggsField = null;
        DestroyImmediate(gameObject);
    }

}
