using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    private string soundToPlay = "";

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collider2D)
    {
        if(collider2D.gameObject.tag == "Player")
        {
            AudioManager.PlayAudio(soundToPlay);
            Destroy(gameObject);
        }
    }
}
