using UnityEngine;

public class TrapDoor : MonoBehaviour
{

    public bool isOpen = false;


    // if the trap is open or not
    public void ChangeStatus()
    {

        isOpen = !isOpen;

    }
}
