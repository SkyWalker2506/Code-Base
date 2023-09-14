using UnityEngine;

namespace InputSystem
{
    public class ScreenTouchInput : IInput
    {
        public Vector3 Input { get; private set; }
        private Vector3 lastTouchPosition;
        private Vector3[] touchPositionArray;
        private int touchIndex;
        
        public ScreenTouchInput(ITouchInputData touchInputData)
        {
            touchPositionArray = new Vector3[touchInputData.TouchMemoryCount];
        }
        
        public void UpdateInput()
        {
                if (UnityEngine.Input.GetMouseButtonDown(0))
                {
                    lastTouchPosition = UnityEngine.Input.mousePosition;
                    for (int i = 0; i < touchPositionArray.Length; i++)
                    {
                        touchPositionArray[i] = lastTouchPosition;
                    }

                    touchIndex = 0;
                }
                
                if (UnityEngine.Input.GetMouseButton(0))
                {
                    touchIndex++;
                    lastTouchPosition = GetAverageTouchPos();
                    touchPositionArray[touchIndex%touchPositionArray.Length] = UnityEngine.Input.mousePosition;
                    Vector3 average = GetAverageTouchPos();
                    Vector3 inputVector = average-lastTouchPosition;
                    var viewportPoint = Camera.main.ScreenToViewportPoint(inputVector*100);
                    Input = new Vector3(viewportPoint.x,0,viewportPoint.y).normalized;                        
                }

                if (UnityEngine.Input.GetMouseButtonUp(0))
                {
                    Input = Vector3.zero;
                }
        }

        Vector3 GetAverageTouchPos()
        {
            if (touchPositionArray.Length == 0)
            {
                return Vector3.zero;
            }

            Vector3 sum = Vector3.zero;
            foreach (var touchPosition in touchPositionArray)
            {
                sum += touchPosition;
            }

            return sum / touchPositionArray.Length;
        }
    }
}