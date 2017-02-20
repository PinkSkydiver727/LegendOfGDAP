using UnityEngine;
using System.Collections;

public class isEquipSlot : Mixin {

	public enum eSlotType
	{
		RightHand,
		LeftHand,
        Head,
		eBoot,
		eChest
	};

	public eSlotType slotType;
	public GameObject obj;			//slotted obj
}
