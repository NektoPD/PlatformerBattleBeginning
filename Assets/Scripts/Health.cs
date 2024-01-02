using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public event UnityAction HealthEmptied;

    private int _maxAmount = 100;
    private int _minAmount = 0;
    private int _currentAmount;

    private void Start()
    {
        _currentAmount = _maxAmount;
    }

    public void Increace(int amount)
    {
        if (_currentAmount + amount < _maxAmount)
        {
            _currentAmount += amount;
        }
        else
        {
            _currentAmount = _maxAmount;
        }
    }

    public void Decreace(int amount)
    {
        if(_currentAmount > _minAmount)
        {
            _currentAmount -= amount;
        }
        else if(_currentAmount <= _minAmount) 
        {
            HealthEmptied.Invoke();
        }
    }
}
