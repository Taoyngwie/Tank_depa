using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //ทำลายกระสุนเมื่อครบ 5 วินาที
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
