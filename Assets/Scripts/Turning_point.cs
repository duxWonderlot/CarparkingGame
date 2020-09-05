using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning_point : MonoBehaviour
{
    #region description
    //This helps the car for turning from point A to B manually in the game
    //Core Mechanics , charger , movement of the car using physics, turning at sides
    //TODO Day1:
    //         1)trying to make smooth and Acurrate turns for any sides of the levels-->fixed
    //         2)Bug: Snapping Should not happen for turning -->fixed
    //         3)Trying to make rotation fesiable--->fixed


    #endregion
    #region Variable_Declaration 
    [Header("Turning_point variables")]
    [SerializeField] bool isturning;
    [SerializeField] float InRange_value;
    [SerializeField]
    float distance;
    [SerializeField] float turning_speed;
    [SerializeField]
    float timer;
    private Vector3 valuefor_rotation;
    [SerializeField]
    float test_var;
    [SerializeField] Transform self;
    private BoxCollider col;
    private Quaternion rotate;
    [SerializeField]
    float Eular_value;
    [SerializeField]
    private bool Stop_rotation,Stop_Anti_rotation;
    //this is for testing purpose
    [Header("Customize Rotations for the Level")]
    [SerializeField] bool right1, left1, newright1, newleft2;
    [SerializeField] bool Make_it_Manual;
    private float variable_turning_speeds;
    #endregion
    private void Start()
    {
        #region Code_mechanics_Variable Initialization
        //turning_speed = 1;
        self = GetComponent<Transform>();
        col =this.gameObject.AddComponent<BoxCollider>();
        col.isTrigger = true;
        isturning = false;

        col.center = new Vector3(-0.68f, 0.09f, 0);
        col.size = new Vector3(1.12f, 1.11f, 0.3f);
        col.enabled = true;
        test_var = 90;
        Stop_rotation = true;
        Make_it_Manual = false;
        variable_turning_speeds = 0;
        #endregion

    }
    private void Update()
    {
      
        #region Code_mechanics_for_turning
       //only for debuging     
       rotate = Quaternion.Euler(self.transform.localEulerAngles.x, self.transform.localEulerAngles.y + Eular_value, self.transform.localEulerAngles.z);
        #region Debugging_Code
        ////this is for debugging
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    Player_movment._instance.gameObject.transform.parent = null;
        //}
        //
        #endregion
        if (self.transform.localEulerAngles.y > 0 || self.transform.localEulerAngles.y < 0)
        {
            Stop_rotation = true;
            Stop_Anti_rotation = true;
        }
        //right
        if (right1)
        {              
                if (self.transform.localEulerAngles.y >= this.transform.rotation.y + 90)
                {                    
                    
                  if (Stop_rotation)
                  {
                                      
                    Eular_value = 0;

                        if (Eular_value == 0)
                        {
                            //this.gameObject.GetComponent<BoxCollider>().enabled = false;
                            Stop_rotation = false;
                            isturning = true;
                        }
                  }
                  if (isturning == true)
                  {
                    //Player_movment._instance.gameObject.transform.parent = null;
                    Player_movment._instance.gameObject.GetComponent<Rigidbody>().useGravity = true;
                    Player_movment._instance.Objects_rb.constraints = RigidbodyConstraints.None;
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    
                    isturning = false;
                        
                  }
                }
                this.transform.rotation = rotate;
        }
            //newright
       else if (newright1)
       {
                
              if (self.transform.localEulerAngles.y >= this.transform.rotation.y + 180)
              {
                    
                  if (Stop_rotation)
                  {
                                     
                    Eular_value = 0;

                        if (Eular_value == 0)
                        {
                            //this.gameObject.GetComponent<BoxCollider>().enabled = false;
                            Stop_rotation = false;
                            isturning = true;
                        }
                   }

                  if (isturning == true)
                    {

                    //Player_movment._instance.gameObject.transform.parent = null;
                    Player_movment._instance.gameObject.GetComponent<Rigidbody>().useGravity = true;
                    Player_movment._instance.Objects_rb.constraints = RigidbodyConstraints.None;
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    
                    isturning = false;
                  }

              }
                this.transform.rotation = rotate;
       }
            //left
       else if (left1)
        {
                 
            if (self.transform.localEulerAngles.y <= this.transform.rotation.y + 270)
            {
 
                  if (Stop_Anti_rotation)
                  {
                                      
                    Eular_value = 0;

                        if (Eular_value == 0)
                        {
                            //this.gameObject.GetComponent<BoxCollider>().enabled = false;
                            Stop_Anti_rotation = false;
                            isturning = true;
                        }
                  }

                if (isturning == true)
                {
                    //Player_movment._instance.gameObject.transform.parent = null;
                    Player_movment._instance.gameObject.GetComponent<Rigidbody>().useGravity = true;
                    Player_movment._instance.Objects_rb.constraints = RigidbodyConstraints.None;
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    
                    isturning = false;
                }


            }
                this.transform.rotation = rotate;
        }
            //newleft
        else if (newleft2)
            {
               
                if (self.transform.localEulerAngles.y <= this.transform.rotation.y + 180)
                {
 
                    if (Stop_Anti_rotation)
                    {
                                       
                    Eular_value = 0;

                        if (Eular_value == 0)
                        {
                            //this.gameObject.GetComponent<BoxCollider>().enabled = false;
                            Stop_Anti_rotation = false;
                            isturning = true;
                        }
                    }

                   if (isturning == true)
                   {

                    //Player_movment._instance.gameObject.transform.parent = null;
                    Player_movment._instance.gameObject.GetComponent<Rigidbody>().useGravity = true;
                    Player_movment._instance.Objects_rb.constraints = RigidbodyConstraints.None;
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    
                    isturning = false;
                   }

                }
                this.transform.rotation = rotate;
            }
            print("testing the value for Turning_Speed" + UI_Manger.UI_reference.meter_value);
        //}
        #region old_code
        //if (isturning)
        //{

        //    if (left1)
        //    {

        //        if (test_var >= 90)
        //        {
        //            //test_var = 90;
        //            isturning = false;                   
        //            Player_movment._instance.gameObject.transform.parent = null;
        //            Player_movment._instance.gameObject.GetComponent<Rigidbody>().useGravity = true;
        //            Player_movment._instance.Objects_rb.constraints = RigidbodyConstraints.None;
        //        }
        //        if(test_var >= 80)
        //        {
        //            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        //        }
        //        this.transform.rotation = rotate;
        //    }
        //    else if (!left1 && right1)
        //    {
        //        rotate = Quaternion.Euler(self.transform.localEulerAngles.x, self.transform.localEulerAngles.y + test_var, self.transform.localEulerAngles.z);
        //        test_var -= 5.0f * Time.deltaTime;
        //        if (test_var <= -90)
        //        {
        //            test_var = -90;
        //            isturning = false;

        //            Player_movment._instance.gameObject.transform.parent = null;
        //            Player_movment._instance.gameObject.GetComponent<Rigidbody>().useGravity = true;
        //            Player_movment._instance.Objects_rb.constraints = RigidbodyConstraints.None;
        //        }
        //        if (test_var <= -80)
        //        {
        //            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        //        }
        //        this.transform.rotation = rotate;
        //    }
        //    else if (newleft)
        //    {
        //        rotate = Quaternion.Euler(self.transform.localEulerAngles.x, self.transform.localEulerAngles.y + test_var, self.transform.localEulerAngles.z);
        //        test_var -= 5.0f * Time.deltaTime;
        //        if (test_var <= -180)
        //        {
        //            test_var = -180;
        //            isturning = false;

        //            Player_movment._instance.gameObject.transform.parent = null;
        //            Player_movment._instance.gameObject.GetComponent<Rigidbody>().useGravity = true;
        //            Player_movment._instance.Objects_rb.constraints = RigidbodyConstraints.None;
        //        }
        //        //if (test_var <= 80)
        //        //{
        //        //    this.gameObject.GetComponent<BoxCollider>().enabled = false;
        //        //}
        //        this.transform.rotation = rotate;
        //    }

        //}

        //else if(!isturning)
        //{
        //    if (left)
        //    {
        //        test_var -= 5.0f * Time.deltaTime;
        //        if (test_var <= 90)
        //        {
        //            test_var = 0;
        //        }
        //    }else if (!left && right)
        //    {
        //        test_var += 5.0f * Time.deltaTime;
        //        if (test_var >= -90)
        //        {
        //            test_var = 0;
        //        }
        //    }
        //}
        #endregion
        #endregion
    }
    private void OnTriggerStay(Collider other)
    {
        variable_turning_speeds = UI_Manger.UI_reference.meter_value;
        #region Core_mechanics: Inputs_During Turning
        if (other.gameObject.tag == "Player")
        {
            //UI_Manger.UI_reference.meter_value / 2
            //only one will be true at a time and tuning system is manual according to player speeds
            if (Make_it_Manual)
            {
                if (right1 == true)
                {
                    if (Input.GetMouseButton(0))
                    {

                        UI_Manger.UI_reference.meter_value = Eular_value;
                        Eular_value += 0.68f * Time.deltaTime;

                    }
                    else
                    {
                        UI_Manger.UI_reference.meter_value = Eular_value;
                        Eular_value -= 0.18f / 2 * Time.deltaTime;
                        if (Eular_value <= 0)
                        {
                            Player_movment._instance.meter_hold = true;
                            Eular_value = 0.0f;
                        }
                    }

                }
                else if (newright1 == true)
                {
                    if (Input.GetMouseButton(0))
                    {

                        UI_Manger.UI_reference.meter_value = Eular_value;
                        Eular_value += 0.68f * Time.deltaTime;

                    }
                    else
                    {
                        UI_Manger.UI_reference.meter_value = Eular_value;
                        Eular_value -= 0.18f / 2 * Time.deltaTime;
                        if (Eular_value <= 0)
                        {
                            Player_movment._instance.meter_hold = true;
                            Eular_value = 0.0f;

                        }
                    }

                }
                else if (left1 == true)
                {
                    if (Input.GetMouseButton(0))
                    {

                        UI_Manger.UI_reference.meter_value = Eular_value;
                        Eular_value -= 0.68f * Time.deltaTime;

                    }
                    else
                    {
                        UI_Manger.UI_reference.meter_value = Eular_value;
                        Eular_value += 0.18f / 2 * Time.deltaTime;
                        if (Eular_value >= 0)
                        {
                            Player_movment._instance.meter_hold = true;
                            Eular_value = 0.0f;

                        }
                    }
                }
                else if (newleft2 == true)
                {
                    if (Input.GetMouseButton(0))
                    {
                        UI_Manger.UI_reference.meter_value = Eular_value;
                        Eular_value -= 0.68f * Time.deltaTime;

                    }
                    else
                    {
                        UI_Manger.UI_reference.meter_value = Eular_value;
                        Eular_value += 0.18f / 2 * Time.deltaTime;
                        if (Eular_value >= 0)
                        {
                            Player_movment._instance.meter_hold = true;
                            Eular_value = 0.0f;

                        }
                    }
                    if (right1 == true)
                    {
                        Eular_value -= UI_Manger.UI_reference.meter_value / 2 * Time.deltaTime;
                    }
                    else if (newright1 == true)
                    {
                        Eular_value += UI_Manger.UI_reference.meter_value / 2 * Time.deltaTime;
                    }
                    else if (left1 == true)
                    {
                        Eular_value -= UI_Manger.UI_reference.meter_value / 2 * Time.deltaTime;
                    }
                    else if (newleft2 == true)
                    {
                        Eular_value -= UI_Manger.UI_reference.meter_value / 2 * Time.deltaTime;
                    }

                }
                Player_movment._instance.gameObject.transform.parent = this.gameObject.transform.GetChild(0).transform;
                //Player_movment._instance.gameObject.transform.position = this.gameObject.transform.GetChild(0).transform.position;
                Player_movment._instance.gameObject.transform.position = Vector3.Lerp(Player_movment._instance.gameObject.transform.position, this.gameObject.transform.GetChild(0).transform.position, 4.5f * Time.deltaTime);
                Player_movment._instance.gameObject.GetComponent<Rigidbody>().useGravity = false;
                //Player_movment._instance.transform.rotation = this.gameObject.transform.GetChild(0).rotation;
                Player_movment._instance.Objects_rb.constraints = RigidbodyConstraints.FreezeAll;
                Debug.Log("in_range" + distance);
                // UI_Manger.UI_reference.meter_value = 0;

            }
            if(!Make_it_Manual)
            {
                if (right1 == true)
                {

                    UI_Manger.UI_reference.meter_value = Eular_value;
                    Eular_value += 0.69f * Time.deltaTime;
                         
                  

                }
                else if (newright1 == true)
                {
                    
                        UI_Manger.UI_reference.meter_value = Eular_value;
                        Eular_value += 0.69f * Time.deltaTime;

                     

                }
                else if (left1 == true)
                {
                   

                        UI_Manger.UI_reference.meter_value = Eular_value;
                        Eular_value -= 2.98f * Time.deltaTime;

                   
                }
                else if (newleft2 == true)
                {
                     
                        UI_Manger.UI_reference.meter_value = Eular_value;
                        Eular_value -= 2.98f * Time.deltaTime;

                   

                }
                Player_movment._instance.gameObject.transform.parent = this.gameObject.transform.GetChild(0).transform;
                //Player_movment._instance.gameObject.transform.position = this.gameObject.transform.GetChild(0).transform.position;
                Player_movment._instance.gameObject.transform.position = Vector3.Lerp(Player_movment._instance.gameObject.transform.position, this.gameObject.transform.GetChild(0).transform.position, 1.4f * Time.deltaTime);
                Player_movment._instance.gameObject.GetComponent<Rigidbody>().useGravity = false;
                //Player_movment._instance.transform.rotation = this.gameObject.transform.GetChild(0).rotation;
                Player_movment._instance.Objects_rb.constraints = RigidbodyConstraints.FreezeAll;
                Debug.Log("in_range" + distance);
                // UI_Manger.UI_reference.meter_value = 0;
 
            }
            #endregion
            print("checking_out the values" + Eular_value);
        }
    }
    //Resetting mater value to zero during start of the turning 
    #region Core_mechanics: Inputs_Before Turning
    private void OnTriggerEnter(Collider other)
    {      
        StartCoroutine(take_themovement(variable_turning_speeds));
    }
        #endregion
     IEnumerator take_themovement(float i)
     {
        i = i /1.2f;
        Make_it_Manual = false;
        yield return new WaitForSeconds(i);
        Make_it_Manual = true;
    }
    }

     


