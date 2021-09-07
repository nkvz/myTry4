using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPOI : MonoBehaviour
{
    private static ActionPOI S;

    [Header("Set in Inspector")]
    public Camera camera;
    public GameObject PanelFail;
    public GameObject PanelWin;
    public float velocityMult = 1f;
    public Text scoreText;
    public float score;

    public TraectoryLinePOI Traectory;
    

    [Header("Set Dynamically")]
    public GameObject POI;
    public bool aimingMode;
    public bool inGround;

    private Rigidbody POIrb;


    public void Start()
    {
        S = this;
        PanelFail.SetActive(false);
        PanelWin.SetActive(false);

    }

    public void ResumeGame()
    {
        PanelWin.SetActive(false);
    }


    public void OnMouseDown()
    {
        if (!inGround) return;


            aimingMode = true;
            POIrb = POI.GetComponent<Rigidbody>();
            POIrb.isKinematic = true;
    }

    public void Update()
    {
        score = POI.transform.position.x;
        scoreText.text = score.ToString("Scrore: " + Mathf.Round(score));

        if(score >= 200)
        {
            PanelWin.SetActive(true);
        }

        if (!aimingMode) return;

        float enter;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        new Plane(Vector3.forward, transform.position).Raycast(ray, out enter);
        Vector3 mouseInWorld = ray.GetPoint(enter);

        Vector3 speed = (mouseInWorld - transform.position) * velocityMult;
        //float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        float maxMagnitude = 14f;
        if(speed.magnitude > maxMagnitude)
        {
            speed.Normalize();
            speed *= maxMagnitude;
        }

        Traectory.ShowTraectory(transform.position, -speed);

        if (Input.GetMouseButtonUp(0))
        {
            aimingMode = false;
            POIrb.isKinematic = false;
            POIrb.AddForce(-speed, ForceMode.VelocityChange);
            FollowCam.POI = POI;
        }   
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FailTrigger")
        {
            PanelFail.SetActive(true);
            //Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            inGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            inGround = false;
        }
    }

}
