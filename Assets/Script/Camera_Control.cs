using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    //สร้างตัวแปรสำหรับใช้ในการจัดการกล้อง
    public GameObject frontView;
    public GameObject rearView;
    
    void Start()
    {
        //ทำให้กล้องหลักไปอยู่ในตำแหน่ง Frontview กับ Rearview 
        //this. คือobjectที่ชี้ไปที่ Camera_Control 

        //ทำให้ตำแหน่งกล้องย้ายไปท่ี่ rearview
        this.transform.position = rearView.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        //ใช้ในการปรับตัวซูมกล้อง
        //เลข 1 คือคลิ๊กขวา เลข 0 คือคลิ๊กซ้าย
        if (Input.GetMouseButton(1))
        {
            //ในกรณีกดเมาส์ขวา
            // ให้ซูมไปที่ กล้องหน้า(ตัว frontview)
                                     //Vector3.Lerp เป็นช่วงของระยะจุดสองจุดในกราฟโดยที่จะค่อยๆขยับไปหาอีกจุดตามจำนวนความเร็วที่เราได้กำหนดไว้
            this.transform.position = Vector3.Lerp(this.transform.position, frontView.transform.position, 0.05f);
                                                    //จากจุดนี้                //ไปหาจุดนี้                       //ด้วยความเร็วเท่านี้
        }
        else
        {
            //กรณีปล่อยเมาส์ หรือ เมาส์ปกติไม่ได้กดอะไร
            // ให้ซูมกลับไปคืนที่ กล้องหลัง(ตัว rearview)
                                     //Vector3.Lerp เป็นช่วงของระยะจุดสองจุดในกราฟโดยที่จะค่อยๆขยับไปหาอีกจุดตามจำนวนความเร็วที่เราได้กำหนดไว้
            this.transform.position = Vector3.Lerp(this.transform.position, rearView.transform.position, 0.05f);
            //จากจุดนี้                //ไปหาจุดนี้                       //ด้วยความเร็วเท่านี้

            //ปรับให้กล้องหลัง(rearview)เล็งไปที่กล้องตัวหน้า
            this.transform.LookAt(frontView.transform);
        }


        //วิธีการปรับให้กล้องหลักไปกับรถก็คื อต้องกลับไปหน้าทำเกมแล้วลาก frontview , rearview ใน Hierarchy ไปใส่รวมในชุดรถ
    }
}
