using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   private Vector3 velocity;

   public float smoothTimeZ;

   public float smoothTimeX;

   public float offsetZ = -20f;

   public GameObject player;

   private Vector3 originPos;

   private void Start()
   {
       this.originPos = transform.position;
   }

   private void FixedUpdate()
   {
       float posX = Mathf.SmoothDamp(transform.position.x,this.player.transform.position.x,ref this.velocity.x,this.smoothTimeX);

       float posZ = Mathf.SmoothDamp(transform.position.z, this.player.transform.position.z + this.offsetZ, ref this.velocity.z, this.smoothTimeZ);

       transform.position = new Vector3(posX, transform.position.y, posZ);
   }
}
