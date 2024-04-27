using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Transform cam;
    [SerializeField]float W_Speed,R_Speed;
    float Speed,x,y;
    bool Sprinting;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Camera").transform;
        rb = transform.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void SetInput(){
        Sprinting = Input.GetKey(KeyCode.LeftShift);
        y = Input.GetAxis("Vertical");
        x = Input.GetAxis("Horizontal");
    }
    void Update()
    {
        Movement();
        SetInput();
        Look();
    }
    void Movement(){
        switch(Sprinting){
            case(true):
                Speed = R_Speed;
                break;
            case(false):
                Speed = W_Speed;
                break;
        }
        Vector3 fwd = new Vector3(transform.forward.x * Speed * y, rb.velocity.y , transform.forward.z * Speed * y);
        Vector3 rt = new Vector3(transform.right.x * Speed * x, Vector3.zero.y , transform.right.z * Speed * x);
        rb.velocity = fwd + rt;
    }
    float xRot,yRot;
    public float sens;
    void Look(){
        float MouseX = Input.GetAxisRaw("Mouse X");
        float MouseY = Input.GetAxisRaw("Mouse Y");
        xRot -= (MouseY * sens * Time.fixedDeltaTime);
        yRot += (MouseX * sens * Time.fixedDeltaTime);
        cam.rotation = Quaternion.Euler(xRot,yRot,0);
        rb.transform.rotation = Quaternion.Euler(0,yRot,0);
    }
}
