using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionQuad : MonoBehaviour
{
    public static SelectionQuad _instance;

    public Texture2D _textureQuad;
    [HideInInspector]
    public Rect _quad = new Rect(0, 0, 0, 0);
    public Color _colorQuad = new Color(1, 1, 1, 0.5f);
    [HideInInspector]
    public float _startClickTime = 0f;

    private Vector3 _startClick = -Vector3.one;
    

	// Use this for initialization
	void Awake ()
    {
        _instance = this;
	}
	
	// Update is called once per frame
	void Update ()
    {
        SetQuad();
    }

    void SetQuad ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startClick = Input.mousePosition;
            _startClickTime = Time.time;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (_quad.width < 0)
            {
                _quad.x += _quad.width;
                _quad.width = -_quad.width;
            }
            if (_quad.height < 0)
            {
                _quad.y += _quad.height;
                _quad.height = -_quad.height;
            }

            _startClick = -Vector3.one;
        }

        if (Input.GetMouseButton(0))
        {
            _quad = new Rect(_startClick.x, InvertMouseY(_startClick.y), Input.mousePosition.x - _startClick.x, InvertMouseY(Input.mousePosition.y) - InvertMouseY(_startClick.y));
        }
    }

    void OnGUI()
    {
        if (_startClick != -Vector3.one)
        {
            GUI.color = _colorQuad;
            GUI.DrawTexture(_quad, _textureQuad);
        }
    }

    public float InvertMouseY (float y)
    {
        return Screen.height - y;
    }
}
