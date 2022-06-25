using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Control : MonoBehaviour
{
    //กำหนดความเร็วของรถ
    public float speed;
    //กำหนดความไวในการเลี้ยวรถ
    public float turnSpeed;

    //ควบคุมกระสุน
    public GameObject bullet;
    public GameObject bulletSpawn;
    public float bulletSpeed;
    public float gunTurinSpeed; //ความไวในการหมุนปากกระบอกปืน
    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ควบคุมการยิง

        // 0 = เมาส์ซ้าย
        // 1 = เมาส์ขวา
        
        //เมื่อมีการกดเมาส์ขวาค้างไว้
        if (Input.GetMouseButton(1))
        {
            //หมุนปากกระบอกปืนได้ก็ต่อเมื่อเราคลิ๊กเมาส์ขวาเอาไว้
            float horizontal = Input.GetAxis("Mouse X") * gunTurinSpeed * Time.deltaTime;
            float Vertical = Input.GetAxis("Mouse Y") * gunTurinSpeed * Time.deltaTime; 

            //หมุนปืน ไปตามที่ตั้งไว้ตอนต้นจากปืนในที่นี้ y,z
            gun.transform.Rotate(-Vertical, 0, horizontal);


            //ยิง
            if (Input.GetMouseButtonDown(0))
            {
                //------------------------------------------------------
                //Instantiate คำสั่งในการสร้างวัตถุ
                //สิ่งที่spawn   //สร้างที่ตำแหน่งไหน                //ค่าการ rotation
                GameObject b = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.localRotation);
                //ปรับให้ยิงไปข้างหน้า
                b.GetComponent<Rigidbody>().AddForce(bulletSpawn.transform.forward * bulletSpeed);
            }
        }
        else
        {
            //------------------------------------------------------

            //สร้างการเคลื่อนไหวของตัวรถ                                        //เพื่อให้การเคลื่อนที่เป็นหน่วยวินาทีต่อเฟรม
            float moveVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

            //ให้ไปดูว่ารถเคลื่อนที่ไปในแนวแกนไหน ในที่นี้เป็นแกน Z
            this.transform.Translate(0, 0, moveVertical);

            //------------------------------------------------------

            //กำหนดให้หมุนไปตามแนวแกน x                                   //เพื่อให้การเคลื่อนที่เป็นหน่วยวินาทีต่อเฟรม
            float moveHorizontal = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

            //ปรับการหมุน  ไปในทางตามแนวแกน x                                                 
            this.transform.Rotate(0, moveHorizontal, 0);
            //------

            //ทำให้ปืนหันกลับมามุมเดิม ด้วยความเร็ว 0.1f
            gun.transform.localRotation = Quaternion.Lerp(gun.transform.localRotation,Quaternion.identity,0.1f);
            //Quaternion ค่าองศาใน Unity 
        }

    }
}
