using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eh : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    private Vector3 mousePos;

    private Vector2 m_dir;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - transform.position;
        if(Input.GetMouseButton(0)){
             rb.velocity = new Vector2(direction.x, direction.y).normalized * 5;
        }

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Line")){
            Vector2 _wallNormal = other.contacts[0].normal;
            m_dir = Vector2.Reflect(rb.velocity,_wallNormal);

            rb.velocity = m_dir * 5;
        }
    }
}
