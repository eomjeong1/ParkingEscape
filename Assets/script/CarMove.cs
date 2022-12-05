using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    bool UpStop;
    bool DownStop;
    bool LeftStop;
    bool RightStop;
    RaycastHit hitLayerMask;



    private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);


        int layerMask = 1 << LayerMask.NameToLayer("Stage");
        if (Physics.Raycast(ray, out hitLayerMask, Mathf.Infinity, layerMask))
        {
            if (LeftStop == true)
            {
              
                    
                        Debug.Log($"transform : {transform.position.x}      hitLayerMask : {hitLayerMask.point.x}    result : {transform.position.x - hitLayerMask.point.x}");
                        float y = this.transform.position.y;
                        float z = this.transform.position.z;

                        this.transform.position = new Vector3(transform.position.x, y, z);
                    
              

            }
            else if (RightStop == true)
            {
                


                    Debug.Log($"transform : {transform.position.x}      hitLayerMask : {hitLayerMask.point.x}    result : {transform.position.x - hitLayerMask.point.x}");
                    float y = this.transform.position.y;
                    float z = this.transform.position.z;

                    this.transform.position = new Vector3(transform.position.x, y, z);
                
            }
            if (UpStop == true)
            {
                if (this.transform.position.y <= hitLayerMask.point.y)
                {


                    Debug.Log($"transform : {transform.position.y}      hitLayerMask : {hitLayerMask.point.y}    result : {transform.position.y - hitLayerMask.point.y}");
                    float x = this.transform.position.x;
                    float z = this.transform.position.z;

                    this.transform.position = new Vector3(x, transform.position.y, z);
                }
                else
                {
                    float x = this.transform.position.x;
                    float z = this.transform.position.z;
                    this.transform.position = new Vector3(x, hitLayerMask.point.y, z);
                }

            }
            else if (DownStop == true)
            {
                if (this.transform.position.y >= hitLayerMask.point.y)
                {

                    Debug.Log($"transform : {transform.position.y}      hitLayerMask : {hitLayerMask.point.y}    result : {transform.position.y - hitLayerMask.point.y}");
                    float x = this.transform.position.x;
                    float z = this.transform.position.z;

                    this.transform.position = new Vector3(x, transform.position.y, z);
                }
                else
                {
                    float x = this.transform.position.x;
                    float z = this.transform.position.z;
                    this.transform.position = new Vector3(x, hitLayerMask.point.y, z);
                }


            }
            else
            { //Debug.Log("OnMouseDrag");
                float x = this.transform.position.x;
                float z = this.transform.position.z;
                this.transform.position = new Vector3(x, hitLayerMask.point.y, z);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Cars" || collision.transform.tag == "Walls")
        {
            Debug.Log("충돌");
            // 플레이어 위치값, 콜리전 위치값 출력
            // 그 위치값들의 x를 출력해서 차이를 내서 x값이 높은 쪽이 오른쪽
            Debug.Log("game : " + gameObject.transform.position);
            Debug.Log("collision : " + collision.transform.position);
            if (gameObject.transform.position.y <= collision.transform.position.y)
            {
                Debug.Log("위쪽 충돌");
                UpStop = true;
            }
            if (gameObject.transform.position.y >= collision.transform.position.y)
            {
                Debug.Log("아래쪽 충돌");
                DownStop = true;
            }
            if (gameObject.transform.position.x >= collision.transform.position.x)
            {
                Debug.Log("왼쪽 충돌");
                LeftStop = true;
            }
            if (gameObject.transform.position.x <= collision.transform.position.x)
            {
                Debug.Log("오른쪽 충돌");
                RightStop = true;
            }

        }
    }
    private void OnCollisionExit(Collision collision)
    {

        if (collision.transform.tag == "Cars" || collision.transform.tag == "Walls")
        {
            if (gameObject.transform.position.y <= collision.transform.position.y)
            {
                Debug.Log("위쪽 충돌 끝");
                UpStop = false;
            }
            if (gameObject.transform.position.y >= collision.transform.position.y)
            {
                Debug.Log("아래쪽 충돌 끝");
                DownStop = false;
            }
            if (gameObject.transform.position.x > collision.transform.position.x)
            {
                Debug.Log("왼쪽 충돌 끝");
                LeftStop = false;
            }
            if (gameObject.transform.position.x < collision.transform.position.x)
            {
                Debug.Log("오른쪽 충돌 끝");
                RightStop = false;
            }
        }

    }

}
