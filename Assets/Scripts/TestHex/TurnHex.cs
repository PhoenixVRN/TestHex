using UnityEngine;

public class TurnHex : MonoBehaviour
{
    
    void Start()
    {
        transform.Rotate(Vector3.up, TurnAngle());
    }

    private int TurnAngle()
    {
        int f = Random.Range(0, 6);

        switch (f)
        {
            case 1 :
                return 60;
            case 2 :
                return 120;
            case 3 :
                return 180;
            case 4 :
                return 240;
            case 5 :
                return 300;
        }

        return 0;
    }
}
