using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    private float _horizontalValue;
    
   private void Start()
   {
       
   }

   
    private void FixedUpdate()
    {
        _horizontalValue += Input.GetAxis("Horizontal") * 0.5f;
        _horizontalValue = Mathf.Clamp(_horizontalValue, -2.3f, 2.3f); // Karakterin x ekseninde hareketini sınırlamak için yazılan kod


        Vector3 vec=new Vector3(_horizontalValue,transform.position.y,transform.position.z+Time.deltaTime);
        transform.position = vec;
        
        transform.Translate(Vector3.right*Time.deltaTime);//Objenin yönü yanlış tarafa baktığı için forward yerine right kullandım.
    }
}
