using UnityEngine;

public class TouchHex : MonoBehaviour
{
    private bool _onActivUp; // нажат ли наш хекс.
    private MeshRenderer _renderer;
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    private void OnMouseDown()
    {
        // проверяем рядом ли хекс который надо поменять местами.
        if (GameManager.isActivHex && Vector3.Distance(GameManager.activHex.transform.position, transform.position) >
                                   0.2
                                   && Vector3.Distance(GameManager.activHex.transform.position, transform.position) <
                                   1.2)
        {
            (transform.position, GameManager.activHex.transform.position) =
                (GameManager.activHex.transform.position, transform.position); // меняем местами значение трансформа у хексов. 
 
            transform.position += new Vector3(0, -0.1f, 0);
            GameManager.isActivHex = false;
            GameManager.activHex.GetComponent<TouchHex>()._onActivUp = false;
            GameManager.activHex = null;
            _onActivUp = false;
            return;
        }
        // логика если нажатый второй хекс дальше соседнего.
        if (GameManager.isActivHex && !_onActivUp)
        {
            GameManager.activHex.transform.position += new Vector3(0, -0.1f, 0);
            GameManager.activHex.GetComponent<TouchHex>()._onActivUp = false;
            GameManager.activHex = gameObject;
            _onActivUp = true;
            transform.position += new Vector3(0, 0.1f, 0);
            return;
        }
       
        
        // обработка начального нажатичя на хекс.
        if (_onActivUp)
        {
            transform.Rotate(Vector3.up, 60);
            transform.position += new Vector3(0, -0.1f, 0);
            _onActivUp = false;
            GameManager.isActivHex = false;
            GameManager.activHex = null;
        }
        else
        {
            GameManager.activHex = gameObject;
            GameManager.isActivHex = true;
            transform.position += new Vector3(0, 0.1f, 0);
            _onActivUp = true; 
        }
    }
}
