using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [Header("Spawn and End points")]
    [SerializeField] Transform goal,spawn;
    [SerializeField] Transform[] goal_points,Spawn_points;
    [SerializeField] GameObject points_1,_Tutorial;
    [SerializeField] int select;
    private void Start()
    {
        Change_levels(select);

        select =PlayerPrefs.GetInt("save_lvl");
        Time.timeScale = 0;
        _Tutorial.SetActive(false);
    }


    public void Change_levels(int i)
    {
        Time.timeScale = 1;
        _Tutorial.SetActive(true);
        select = i;
        if(i == 1)
        {
            points_1.SetActive(false);
            goal.transform.position = goal_points[1].transform.position;
            goal.transform.rotation = goal_points[1].transform.rotation;
            spawn.transform.position = Spawn_points[1].transform.position;
            spawn.transform.rotation = Spawn_points[1].transform.rotation;
        }
        else if(i == 2)
        {
            points_1.SetActive(true);
            goal.transform.position = goal_points[0].transform.position;
            goal.transform.rotation = goal_points[0].transform.rotation;
            spawn.transform.position = Spawn_points[0].transform.position;
            spawn.transform.rotation = Spawn_points[0].transform.rotation;
        }

        PlayerPrefs.SetInt("save_lvl", select);
    }

}
