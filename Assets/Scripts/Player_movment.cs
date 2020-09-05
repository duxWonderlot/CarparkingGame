using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_movment : MonoBehaviour
{
    #region Description 
    //physics based player movement
    //player moves according to the charger value after swipe/tap hold in the game
    //TODO Day 3:
    //1) player car turning at side roads
    //2) player car stops after certain momentum 
    //3) Start and Endpoints of the level
    //4) Spawning the player if at edges of the level
    //5) implementing UI for the game
    //   1)core mechanics UI 
    //   2)general game UI
    //Bugs TODO Day 4: 1)Turning Cornors should not be automatic-->bugfixed
    //           2)Turning Speeds with Power_ups values-->bugfix
    //           3)Stop inBetween during Turns-->bugfix
    //           4)Very fast Turn this should be according to the player's speed
    //           5)Car should not stop during turns-->bugfix
    //           
    #endregion
    #region Variable_Declaration
    [Header("Player_movement_variables")]
    public Rigidbody Objects_rb;
    [Range(0,100)]
    [SerializeField] float timer,Speed;
    [SerializeField] Transform Player_obj;
    public static Player_movment _instance;
    [SerializeField]int select;
    public bool isture, make_objectmove,disable_movingUI;
    [SerializeField] Animator play_afterEveryReset;
    public bool meter_hold;
    #endregion
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Start()
    {
        #region Default_variable_Intialization
        this.gameObject.AddComponent<Rigidbody>();
        Objects_rb = GetComponent<Rigidbody>();
        Player_obj = GetComponent<Transform>();
        Objects_rb.mass = 1.0f;
        Objects_rb.angularDrag = 1.0f;
        Speed = 750;
        timer = 0;
        isture = false;
        make_objectmove = false;
        disable_movingUI = true;
        play_afterEveryReset.SetBool("showUi", true);
        meter_hold = true;
        #endregion
        // select = 1;
    }
    //Since it is physics based game used fixed Update 
    private void FixedUpdate()
    {
        //fuction related to Code Mechanic
        Control_Rb_Constrains(select);
        //
        ////bugfix
        //if(this.gameObject.GetComponent<BoxCollider>().enabled == true)
        //{
        //    meter_hold = false;
        //}
        //else
        //{
        //    meter_hold = true;
        //}
        ////
        #region Test_Code
        //this is for testing purpose only
        //if (Input.GetKey(KeyCode.R))
        //{
           
        //    SceneManager.LoadSceneAsync(0);
        //}
        #endregion
        #region Code_Related to Mechanics
        if (isture)
        {
            Objects_rb.useGravity = false;
            timer += 1 * Time.deltaTime;
            disable_movingUI = false;
            if (timer >= 4.0f)
            {
                isture = false;
                //stop the vehical 
                make_objectmove = false;
                //trying to reset the UI slider of the game
                UI_Manger.UI_reference.meter_value = 0;              
                disable_movingUI = true;
                timer = 0;
            }
           
        }
        else if (!isture)
        {
            Objects_rb.useGravity = true;
             
        }
        if (make_objectmove)
        {
            Objects_rb.AddForce(-Player_obj.right * Time.deltaTime * UI_Manger.UI_reference.meter_value*3);
            isture = true;
        }
        #endregion
    }
    //trying to fix UI_bug in the game
    private void Update()
    {
        #region Control_inputs for player
        if (Input.GetMouseButton(0))
        {
            if (meter_hold)
            {
                if (disable_movingUI)
                {
                    
                    UI_Manger.UI_reference.meter_value += 5.7f * Time.deltaTime;
                    print("checking values" + UI_Manger.UI_reference.meter_value);
                }
            }
            
            play_afterEveryReset.SetBool("showUi", false);
            make_objectmove = false;
            
        }
        else if (Input.GetMouseButtonUp(0))
        {          
            make_objectmove = true;
            play_afterEveryReset.SetBool("showUi", true);

        }
        #endregion

    }
    #region Code_related to Mechanics
    private void Control_Rb_Constrains(int i)
    {
        switch(i)
        {
            case 1:
                Objects_rb.constraints = RigidbodyConstraints.FreezePositionY;
                break;
            case 2:
                Objects_rb.constraints = RigidbodyConstraints.None;
                break;
        }
    }
    #endregion
    //this is Winning State
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "end")
        {
            UI_Manger.UI_reference.Winning_Panel();
        }
    }
}
