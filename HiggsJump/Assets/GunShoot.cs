using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private GameObject higgsSpawnPoint;
    [SerializeField] private GameObject higgsParticle;
    private float gunPower = 0f;
    private float maxGunPower = 100f;

    private void Awake()
    {
        higgsSpawnPoint = GameObject.Find("HiggsSpawnPoint");
    }


    private void Update()
    {
        if (Input.GetMouseButton(0)) //Left Mouse Button while down
        {
            gunPower += (100 / 3) * Time.deltaTime;

        }
        if( gunPower >= maxGunPower )
        {
            //Debug.Log("gunPower is max");
            gunPower = maxGunPower;
        }
        if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log("FIRE!" + gunPower);
            FireHiggsGun(gunPower);
            gunPower = 0f;
        }
    }


    private void FireHiggsGun(float power)
    {
        if(LevelController.Singleton.CurrentHiggsField != null)
        {
            LevelController.Singleton.CurrentHiggsField.GetComponent<HiggsFieldBehaviour1>().Remove();
        }
        
        GameObject virtualBullet = Instantiate(higgsParticle,higgsSpawnPoint.transform.position, higgsSpawnPoint.transform.rotation);
        virtualBullet.GetComponent<Rigidbody>().AddForce(virtualBullet.transform.forward * power);
        
    }

}
