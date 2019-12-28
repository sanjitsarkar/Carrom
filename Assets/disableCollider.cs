using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableCollider : MonoBehaviour
{
    public AudioSource[] breakshots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    private void OnCollisionEnter2D(Collision2D other)
    {
              if(other.gameObject.tag=="striker")
        {
            Debug.Log("Striked");
   
       breakshots[0].Play();
            // Destroy(this.gameObject);
        }
    }
}
