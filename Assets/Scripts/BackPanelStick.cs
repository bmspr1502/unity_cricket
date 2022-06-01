using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackPanelStick : MonoBehaviour
{
    private const string BackPanelTag = "BackPanel";

    private void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag(BackPanelTag)){
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
