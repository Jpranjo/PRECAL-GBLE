using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearSCript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject smoke;
    [SerializeField] private float radius = 2f;
    [SerializeField] private float width = 2f;
    [SerializeField] private float height = 2f;
    [SerializeField] private int numObjects = 50;

    public void SmokeCircle(int numObjs, float r){
            for (int i = 0; i < numObjs; i++)
            { 
                StartCoroutine(SpawnCircle(r));
            }
    }
    public void SmokeRectangle(int numObjs, float w, float h){
            for (int i = 0; i < numObjs; i++)
            { 
                StartCoroutine(SpawnRect(w, h));
            }
    }

    private IEnumerator SpawnCircle(float r){
        yield return new WaitForSeconds(Random.Range(0.1f, 1f));
        
        Instantiate(smoke, Random.insideUnitCircle * r + new Vector2 (transform.position.x,transform.position.y),transform.rotation);
    }

    private IEnumerator SpawnRect(float w, float h){
        yield return new WaitForSeconds(Random.Range(0.1f, 1f));
        Instantiate(smoke,new Vector3(Random.Range(-w, w), Random.Range(-h, h) ,0) + transform.position,transform.rotation);
    }
}
