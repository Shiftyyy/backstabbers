using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    private bool cursorLocked = true;
    GameObject Player;

	// Use this for initialization
	void Start () {
        Player = this.transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            toggleCursorLock();
        }
        if (cursorLocked)
        {
            moveCamera();
        }
	}

    private void moveCamera()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        Player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Player.transform.up);
    }

    private void toggleCursorLock()
    {
        if(cursorLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            cursorLocked = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            cursorLocked = true;
        }
    }
}
