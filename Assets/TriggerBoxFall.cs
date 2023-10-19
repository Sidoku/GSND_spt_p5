using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxFall : MonoBehaviour
{

    [SerializeField] GameObject box;
    [SerializeField] GameObject otherTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            box.GetComponent<Animator>().SetBool("triggered", true);
        }
    
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            otherTrigger.SetActive(false);
        }
    }

}
