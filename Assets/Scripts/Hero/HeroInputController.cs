using UnityEngine;

public class HeroInputController : MonoBehaviour
{
    private float horizontalValue;

    public float HorizontalValue
    {
        get { return horizontalValue; }
    }



    void Update()
    {
        HandleHeroHorizontalInput();
    }



    private void HandleHeroHorizontalInput()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    horizontalValue = Input.GetAxis("Mouse X");
        //}
       
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved) {
                horizontalValue = touch.deltaPosition.x;
            
            }
        }
        else {
            horizontalValue = 0;
        }
    }
}

