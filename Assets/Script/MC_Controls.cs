using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MC_Controls : MonoBehaviour
{
    //put public vars here
    public Vector3 v3;//variables as properties 
    public Vector3 someSize;
    public float mc_Scale = 0.1f;


    public float mc_speed = 5.0f;
    public float mc_rotation = 0.0f;//rotation speed 
    public int someVariable = 10;
    public Transform gb;//to link to a specifi game object
    //put private vars here
    //private GameObject thisObj;


    // Start is called before the first frame update; during the first frame of the object's existence in the gamescene
    void Start()
    {
        //Rigidbody rb = GetComponent<>();//this requires unity's physics
        v3 = new Vector3(mc_speed, 0.0f, 0.5f);
        Vector3 someSize = new Vector3(0.1f,0.5f,0.0f) * mc_Scale;//%percentage
        //
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localScale.x += mc_Scale;
        //the hard-scripted method of key inputs//is pure binary
        //HardKeyInputs();
        InputManagerAxis();
        //Debug.Log("deltatime " + Time.deltaTime);
        void MoveSide(float speed)//move horizontally
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime * mc_speed);
        }
        void MoveForward(float speed)//move horizontally
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime * mc_speed);
        }
        void MoveUp(float speed)//move horizontally
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime * mc_speed);//by local transform
        }

        void ResizeObject()//local scale
        {
            if(Input.GetKeyUp(KeyCode.T))
            {
                transform.localScale += someSize; 
                //transform.position = new Vector3(5.0f,5.0f,5.0f);//teleport to location
            }
            else if(Input.GetKeyUp(KeyCode.Y))
            {
                transform.localScale -= someSize;
            }

        }

        void RotateMC(float rotateDir, float rotateBy)//rotate by a certain degree value
        {
            //eulerangles
            //quaternions
            //transform.Rotate(new Vector3(0.2f, 0.8f, 0.5f) * Time.deltaTime * rotateBy * rotateDir);
            transform.Rotate(Vector3.up * rotateBy * rotateDir * Time.deltaTime);//can go CW, CCW
            //Vector3.up = (0.0, 1.0, 0.0)
            Debug.Log("rotating: " + rotateDir);
            //transform.localEulerAngles = Vector3.zero;
        }//timeDelta frame speed varied by CPU speed; hence this is not 100% same

        void HardKeyInputs() 
        {
            if (Input.GetKeyUp(KeyCode.A))//bool
            {
                Debug.Log("A KeyUp detected");//when the key is released by a few frames
                MoveSide(mc_speed);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("S KeyDown detected");
                MoveForward(mc_speed);
            }
            else if (Input.GetKey(KeyCode.D))//any interaction per frame
            {
                Debug.Log("D Key detected");
                MoveUp(mc_speed);
            }

            if (Input.GetMouseButtonUp(0))//0 = mouse left btn,1 mouse right,2 = mouse middle btn
            {
                Debug.Log("Mouse 0 is detected");
            }

        }

        void InputManagerAxis()//functions as actions
        {//refer to the inputaxis
            float currentKeyInput = Input.GetAxisRaw("Horizontal");//real number; -1,0,+1
            
            //Input.GetAxis("OuterSpace");//floating/smoothing value ranges between -1.0, 0.0, +1.0
            float currentKeyForward = Input.GetAxisRaw("Forward");
            Vector2 v2 = new Vector2(currentKeyInput, currentKeyForward);
            //vector2/3 is a variable thjat holds two/three floating values; 
            float newRotateValue = Input.GetAxisRaw("Rotation");//-1,0,+1 for dir

            RotateMC(newRotateValue, mc_rotation);
            MoveSide(currentKeyInput);
            MoveForward(currentKeyForward);
            ResizeObject();

            /*if (currentKeyInput > 0.0f)//floating type
            {//debug stuff only applies to Unity' console, not build exe file; so comment the out later
                Debug.Log("Horizontal is Positive: " + currentKeyInput);
            }
            else if (currentKeyInput < 0.0f)//floating type
            {
                Debug.Log("Horizontal is Negative: " + currentKeyInput);
            }
            else
            {
                Debug.Log("Horizontal Not Checked: " + currentKeyInput);
            }*/
        }
    }

    //these are some example hidden pre-built fuinctions in monobehaviour
    /*void LateUpdate()//call every frame but always after Update stuff is done
    { }
    private void FixedUpdate()
    { }

    void OnEnable()//run stuff when this oject is enabled
    { }
    void Awake()// Awake is called before the first frame update of the application's start
    { }*/
}
