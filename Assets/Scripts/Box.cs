using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int health = 1;

    [SerializeField]
    Object DestructableRef;
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            health--;

            if(health <= 0)
            {
                ExplodeThisGameObject();
            }
        }
       
    }
    private void ExplodeThisGameObject()
    {
        
        GameObject destructable = (GameObject)Instantiate(DestructableRef);
        //map the newly loaded destructable object to x and y position of previously destroyed barrel
        destructable.transform.position = transform.position;
        //Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
