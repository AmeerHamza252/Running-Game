using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform followObject;
    public Vector3 offset;
    public float smoothness = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition=followObject.position+offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness*Time.deltaTime);
        //transform.LookAt(followObject);
    }
}
