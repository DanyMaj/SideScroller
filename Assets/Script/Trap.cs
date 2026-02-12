using UnityEngine;

public class Trap : Interactable
{
    public int dammage = 3;
    public override void Interaction()
    {
        var healthManager = player.GetComponent<HealthManager>();
        healthManager.AddHp(-dammage);
        healthManager.GetHP();
        print("teste");
    }
}
