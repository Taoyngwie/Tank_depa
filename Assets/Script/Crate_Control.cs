using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate_Control : MonoBehaviour
{
    public GameObject crackedCrate;
    public GameObject explosion;

    //เช็คการชนของกระสุน
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //สร้างเศษกล่องกระจาย
            Instantiate(crackedCrate, this.transform.position, this.transform.localRotation);
            GameObject vfx = Instantiate(explosion, this.transform.position, this.transform.localRotation); //สร้างเอฟเฟคระเบิด

            Destroy(vfx, 3); //ลบเอฟเฟ็คภายใน 3 วิ

            Destroy(collision.gameObject); //ทำลายกระสุนทิ้ง
            Destroy(this.gameObject); //ทำลายกล่องทิ้ง


        }
    }
}