using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private Transform[] _arrayPlaces;
    [SerializeField] private float _speed = 1f;

    [SerializeField] private Transform AllPlacesPoint;
    
    private int _numberPlacesInArray;

    private void Start()
    {
        _arrayPlaces = new Transform[AllPlacesPoint.childCount];

        for (int i = 0; i < AllPlacesPoint.childCount; i++)
            _arrayPlaces[i] = AllPlacesPoint.GetChild(i).GetComponent<Transform>();
    }
    
    private void Update()
    {
        Transform IndexByArray = _arrayPlaces[_numberPlacesInArray];

        transform.position = Vector3.MoveTowards(transform.position, IndexByArray.position, _speed * Time.deltaTime);

        if (transform.position == IndexByArray.position) NextPlace();
    }

    private Vector3 NextPlace()
    {
        _numberPlacesInArray++;

        if (_numberPlacesInArray == _arrayPlaces.Length)
            _numberPlacesInArray = 0;

        Vector3 thisPointVector = _arrayPlaces[_numberPlacesInArray].transform.position;
        transform.forward = thisPointVector - transform.position;

        return thisPointVector;
    }
}