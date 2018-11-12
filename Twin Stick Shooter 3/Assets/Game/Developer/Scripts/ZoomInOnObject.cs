using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOnObject : MonoBehaviour {

    private Ray o_ray;
    private RaycastHit o_hit;

    [SerializeField]
    Transform _camera;
    [SerializeField]
    Transform _droneCamera;
    [SerializeField]
    Transform _viewPoint;
    [SerializeField]
    Transform _target1;
    [SerializeField]
    Transform _target2;
    [SerializeField]
    Transform _target3;
    [SerializeField]
    Transform _target4;
    [SerializeField]
    Transform _target5;
    [SerializeField]
    GameObject _skin;
    [SerializeField]
    GameObject _rig;
    [SerializeField]
    float _distanceToTarget;

    Opsive.ThirdPersonController.ItemHandler _itemHandler;

    private bool _isZoomed = false;
    private Quaternion _defaultRotation;
    //private Vector3 _zoomPosition = new Vector3(18.041f, 1.599f, -34.54117f);
    private Vector3 _zoomPosition = new Vector3(0, 0, 0);
    private Quaternion _zoomRotation = Quaternion.Euler(9.883f, 89.61401f, 0f);

    private float _lerpSpeed = 10f;

    private void Start() {
        try
        {
            _defaultRotation = _camera.rotation;

            _itemHandler = GetComponent<Opsive.ThirdPersonController.ItemHandler>();
        }
        catch
        {

        }
    }

    private void Update() {

        //==========================================================
        //Calculate distance target
        try
        {
            float dist1 = Vector3.Distance(_target1.position, transform.position);
            float dist2 = Vector3.Distance(_target2.position, transform.position);
            float dist3 = Vector3.Distance(_target3.position, transform.position);
            float dist4 = Vector3.Distance(_target4.position, transform.position);
            float dist5 = Vector3.Distance(_target5.position, transform.position);

            //Debug.Log(dist1);
            //Debug.Log(dist2);
            //Debug.Log(dist3);

            //Look voor nearest target
            if (dist1 <= dist2 && dist1 <= dist3 && dist1 <= dist4 && dist1 <= dist5)
            {
                _zoomPosition = _target1.position;
                _zoomRotation = _target1.rotation;
            }

            if (dist2 <= dist1 && dist2 <= dist3 && dist2 <= dist4 && dist2 <= dist5)
            {
                _zoomPosition = _target2.position;
                _zoomRotation = _target2.rotation;
            }

            if (dist3 <= dist2 && dist3 <= dist1 && dist3 <= dist4 && dist3 <= dist5)
            {
                _zoomPosition = _target3.position;
                _zoomRotation = _target3.rotation;
            }

            if (dist4 <= dist2 && dist4 <= dist3 && dist4 <= dist1 && dist4 <= dist5)
            {
                _zoomPosition = _target4.position;
                _zoomRotation = _target4.rotation;
            }

            if (dist5 <= dist2 && dist5 <= dist3 && dist5 <= dist4 && dist5 <= dist1)
            {
                _zoomPosition = _target5.position;
                _zoomRotation = _target5.rotation;
            }

            //==========================================================
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (dist1 <= _distanceToTarget || dist2 <= _distanceToTarget || dist3 <= _distanceToTarget) //Checkt of er iets binnen de range is
                {
                    _isZoomed = !_isZoomed;
                }
            }
            if (dist1 >= _distanceToTarget && dist2 >= _distanceToTarget && dist3 >= _distanceToTarget) //Checkt of er nog iets in range is zo niet dan zoomt hij weer uit
            {
                _isZoomed = false;
            }
        }
        catch{}



        try
        {
            if (_isZoomed)
            {
                // raycast
                o_ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(o_ray, out o_hit, Mathf.Infinity))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        o_hit.collider.GetComponent<ConsoleInput>().Interact();
                    }
                }

                _droneCamera.gameObject.SetActive(false);
                _skin.SetActive(false);
                _rig.SetActive(false);
                _itemHandler.enabled = false;
                _camera.GetComponent<Opsive.ThirdPersonController.CameraController>().enabled = false;
                _camera.position = Vector3.Lerp(_camera.position, _zoomPosition, _lerpSpeed * Time.deltaTime);
                _camera.rotation = Quaternion.Lerp(_camera.rotation, _zoomRotation, _lerpSpeed * Time.deltaTime);
            } else
            {
                //_droneCamera.gameObject.SetActive(true);
                _skin.SetActive(true);
                _rig.SetActive(true);
                _itemHandler.enabled = true;
                _camera.GetComponent<Opsive.ThirdPersonController.CameraController>().enabled = true;
                _camera.rotation = _defaultRotation;
            }
        }catch{ print("Something is wrong here"); }
        
    }
}
