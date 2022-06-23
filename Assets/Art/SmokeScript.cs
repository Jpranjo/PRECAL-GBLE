using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject self;
    void Start()
    {
        StartCoroutine(Despawn());
    }

    private IEnumerator Despawn(){
        yield return new WaitForSeconds(1f);
        Destroy(self);
    }
}
