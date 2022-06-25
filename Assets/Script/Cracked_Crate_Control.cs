using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cracked_Crate_Control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //สร้าง Sphere รัสมี 2 หน่วยรอบกล่องแล้วเช็คดูว่าภายในนั้นมี Collider อะไรบ้าง
        Collider[] cols = Physics.OverlapSphere(this.transform.position,2);

        //ทำลูปใน Collider เพื่อหา Collider c ที่อยู่ภายใน cols
        foreach (Collider c in cols)
        {
            Rigidbody rb = c.GetComponent<Rigidbody>();

            if (rb)
            {   
                //กำหนดการละเบิด
                               //สร้างการสุ่มแรงระเบิด               //สร้างการทิศทางการกระจาย // ForceMode.Impulse หมายถึงระเบิดครั้งเดียวแล้วหายไป
                rb.AddExplosionForce(Random.Range(5,10),this.transform.position, Random.Range(5, 10), 1,ForceMode.Impulse);
            }
            
            //ทำลายเศษกล่องที่อยู่ในแมพภายใน 5 วินาที 
            Destroy(this.gameObject,5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
