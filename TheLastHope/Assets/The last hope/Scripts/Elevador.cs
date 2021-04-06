using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador : MonoBehaviour
{
    public Vector3[] points;
    public int point_number = 0;
    private Vector3 current_target;
    public float tolerance;
    public float speed;
    public float delay_time;
    private float delay_start;
    private bool automatic = true;

    void Start() {
        if (points.Length > 0) {
            current_target = points[0];
        }
        tolerance = speed * Time.deltaTime;
    }

    void FixedUpdate () {
        if (transform.position != current_target) {
            MovePlataform();
        }else{
            UpdateTarget();
        }
    }

    void MovePlataform(){
        Vector3 heading = current_target - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        if (heading.magnitude < tolerance) {
            transform.position = current_target;
            delay_start = Time.time;
        }
    }

    void UpdateTarget(){
        if(automatic){
            if(Time.time - delay_start > delay_time){
                NextPlatform();
            }
        }
    }

    void NextPlatform(){
        point_number++;
        if(point_number >= points.Length){
            point_number = 0;
        }
        current_target = points[point_number];
    }
}
