using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    private float _horizontalValue;
    private Rigidbody _fizik;
    
   private void Start()
   {
       _fizik = GetComponent<Rigidbody>();
   }

   
    private void FixedUpdate()
    {
        _horizontalValue += Input.GetAxis("Horizontal") * 0.5f;
        _horizontalValue = Mathf.Clamp(_horizontalValue, -2.3f, 2.3f); // Karakterin x ekseninde hareketini sınırlamak için yazılan kod


        Vector3 vec=new Vector3(_horizontalValue,transform.position.y,transform.position.z+Time.deltaTime*2f);
        _fizik.MovePosition(vec);//Addforce ile hareket ettir.
        
       
    }
}
