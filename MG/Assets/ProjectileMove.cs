using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed;
    public float fireRate;
    public int  numeroColpi = 1;
    public float tempoTraColpiConsecutivi = 0;
    public GameObject hitPrefab;
    public float maxSpread = 0;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 dir = transform.forward + new Vector3(Random.Range(-maxSpread, maxSpread), 0, Random.Range(-maxSpread, maxSpread));
        this.GetComponent<Rigidbody>().AddForce(dir * speed);

    }

    // Update is called once per frame
    void Update()
    {
        //if (speed != 0)
            //transform.position += transform.forward * (speed * Time.deltaTime) ; 
       // else Debug.Log("no speed");
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        speed = 0;
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        if(hitPrefab != null)
        {
            var hitVFX = Instantiate(hitPrefab, pos, rot);

        }
        
        Destroy(gameObject);
    }
}
