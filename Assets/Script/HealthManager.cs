using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private int hp;
    public int hpMax;
    public Transform checkPoint;

    public void ChangeHP(int newAmount)
    {
        hp = newAmount;
        if (hp <= 0)
        {
            Die();
        }
    }

    public void AddHp(int newAmount)
    {
        ChangeHP(hp + newAmount);
    }

    public int GetHP()
    {
        return hp;
    }

    public void Die()
    {
        if (checkPoint != null)
        {
            hp = hpMax;
            transform.position = checkPoint.position;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeHP(hpMax);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
