using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubscriberToHiggs : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        bool _ = other.TryGetComponent<HiggsFieldBehaviour1>(out HiggsFieldBehaviour1 component);
        if (_)
        {
            component.ObjectsInField.Add(gameObject);
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {

        bool _ = other.TryGetComponent<HiggsFieldBehaviour1>(out HiggsFieldBehaviour1 component);
        if (_)
        {
            component.ObjectsInField.Remove(component.ObjectsInField.Find(x => x.gameObject == gameObject));
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }

    }
}
