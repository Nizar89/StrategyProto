using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static CameraControl _instance;

    public float _percentageFirstMovement = 15f;
    public float _speedFirstMovement = 10f;
    public float _percentageSecondMovement = 10f;
    public float _speedSecondMovement = 20f;
    public float _percentageThirdMovement = 5f;
    public float _speedThirdMovement = 30f;
    public float _speedZoom = 30f;

    private float _xMax;
    private float _yMax;
    private Vector3 _translateBasedOnMouse = new Vector3(0f,0f,0f);
    private Vector3 _translateBasedOnInput = new Vector3(0f,0f,0f);

    void Awake()
    {
        _instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        SetScreenLimit();
	}

    // Update is called once per frame
    void Update()
    {
        GetTranslateBasedOnMouse();
        HandleZoom();
        MoveCamera();
    }

    public void SetScreenLimit() // call when resolution change
    {
        _xMax = Screen.width;
        _yMax = Screen.height;
    }
	
    private void MoveCamera()
    {
        this.transform.Translate((_translateBasedOnMouse + _translateBasedOnInput) * Time.deltaTime, Space.World);
    }

    private void GetTranslateBasedOnMouse()
    {
        _translateBasedOnMouse = new Vector3(0f, 0f, 0f); //Reset value to 0 

        float percentagePosX = (Input.mousePosition.x / Screen.width) * 100f;
        //if mouse is near left part
        if (percentagePosX <= _percentageThirdMovement)
        {
            _translateBasedOnMouse = this.transform.right * -1 * _speedThirdMovement;
        }
        else if (percentagePosX <= _percentageSecondMovement)
        {
            _translateBasedOnMouse = this.transform.right * -1 * _speedSecondMovement;
        }
        else if (percentagePosX <= _percentageFirstMovement)
        {
            _translateBasedOnMouse = this.transform.right * -1 * _speedFirstMovement;
        }
        //if mouse is near right part
        if ((100 - percentagePosX) <= _percentageThirdMovement)
        {
            _translateBasedOnMouse = this.transform.right * _speedThirdMovement;
        }
        else if ((100 - percentagePosX) <= _percentageSecondMovement)
        {
            _translateBasedOnMouse = this.transform.right * _speedSecondMovement;
        }
        else if ((100 - percentagePosX) <= _percentageFirstMovement)
        {
            _translateBasedOnMouse = this.transform.right * _speedFirstMovement;
        }

        // handle y position for tomorrow
        float percentagePosY = (Input.mousePosition.y / Screen.height) * 100f;
        //if mouse is near bottom part
        if (percentagePosY < _percentageThirdMovement)
        {
            _translateBasedOnMouse += new Vector3(0f,0f,1f) * -1 * _speedThirdMovement;
        }
        else if (percentagePosY < _percentageSecondMovement)
        {
            _translateBasedOnMouse += new Vector3(0f, 0f, 1f) * -1 * _speedSecondMovement;
        }
        else if (percentagePosY < _percentageFirstMovement)
        {
            _translateBasedOnMouse += new Vector3(0f, 0f, 1f) * -1 * _speedSecondMovement;
        }
        // if mouse in near top part
        if ((100 - percentagePosY) <= _percentageThirdMovement)
        {
            _translateBasedOnMouse += new Vector3(0f, 0f, 1f) * _speedThirdMovement;
        }
        else if ((100 - percentagePosY) <= _percentageSecondMovement)
        {
            _translateBasedOnMouse += new Vector3(0f, 0f, 1f) * _speedSecondMovement;
        }
        else if ((100 - percentagePosY) <= _percentageFirstMovement)
        {
            _translateBasedOnMouse += new Vector3(0f, 0f, 1f) * _speedFirstMovement;
        }

    }

    private void HandleZoom()
    {
        Vector3 pointerVector = MouseHandler._instance._mainCam.ScreenPointToRay(Input.mousePosition).direction;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            _translateBasedOnMouse += pointerVector * -1f * _speedZoom;
        } 
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            _translateBasedOnMouse += pointerVector * 1f * _speedZoom;
        }
    }

}
