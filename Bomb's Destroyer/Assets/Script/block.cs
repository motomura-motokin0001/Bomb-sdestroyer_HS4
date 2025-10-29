using UnityEngine;

public class block : MonoBehaviour
{
    private float destroyYThreshold = -100;
    

    // void Start()
    // {
    //     rd = GetComponent<Rigidbody>();

    // }    
    void Update()
    {
        if (transform.position.y <= destroyYThreshold)
        {
            Destroy(gameObject);
        }
    }
}
