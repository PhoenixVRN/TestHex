using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Item : MonoBehaviour
{
    public string name;
    public Transform item;
    
     private AudioSource _audioPointItems;
     private AudioSource _audioPointSignal;
    
    [Header("Время для изменения размера иконок")]
    [SerializeField] private float _timeSizeIcon;

    private SphereCollider collider;
    private void Start()
    {
        _audioPointItems = GameObject.Find("ItemSound").GetComponent<AudioSource>();
        _audioPointSignal = GameObject.Find("SignalObject").GetComponent<AudioSource>();
        collider = gameObject.GetComponent<SphereCollider>();
        StartCoroutine(RespaunItem());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Auto")
        {
            _audioPointSignal.Play();
            item.localScale = new Vector3(2f, 2f, 2f);
            item.SetParent(other.GetComponent<TruckManager>().cargoitem.transform);
            item.localPosition = new Vector3(0, 0f, 0);
            other.GetComponent<TruckManager>().itemCargo = this;
            transform.DOLocalRotate(new Vector3(0, 360, 0), 5, RotateMode.FastBeyond360).SetRelative(true).SetLoops(-1)
                .SetEase(Ease.Linear);
        }
    }

    private IEnumerator RespaunItem()
    {
        yield return new WaitForSeconds(0.5f);
        item.LeanScale(new Vector3(15f, 15, 15), _timeSizeIcon).setEaseInBack();
    yield return new WaitForSeconds(1f);
    _audioPointItems.Play();
    item.LeanScale(new Vector3(5f, 5, 5), _timeSizeIcon).setEaseInBack();
    }
}
