using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiggsBosonBehaviour : MonoBehaviour
{
    private float bosonlifetime = 10f;
    [SerializeField] private GameObject higgsFieldPrefab;


    private void Update()
    {
        bosonlifetime -= Time.deltaTime;

        if( bosonlifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer != 7)      
        {
            GameObject go = Instantiate(higgsFieldPrefab, collision.transform.position, collision.transform.rotation);
            go.GetComponent<HiggsFieldBehaviour1>().SetDirection(gameObject.transform.forward * -1);

            LevelController.Singleton.CurrentHiggsField = go;
            Destroy(gameObject);

        }

    }
}
