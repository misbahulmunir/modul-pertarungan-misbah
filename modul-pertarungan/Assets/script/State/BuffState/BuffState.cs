using  UnityEngine;

namespace ModulPertarungan
{
	public abstract class BuffState
	{
	    private GameObject _buffObject;
	    private DamageReceiverAction _dmgAction;
	    public GameObject BuffObject
	    {
	        get { return _buffObject; }
	        set { _buffObject = value; }
	    }

	    public DamageReceiverAction DmgAction
	    {
	        get { return _dmgAction; }
	        set { _dmgAction = value; }
	    }

	    public abstract void Action();

	    public BuffState(GameObject buffgGameObject,DamageReceiverAction dmReceiverAction)
	    {
	        this.BuffObject = buffgGameObject;
	        this.DmgAction = dmReceiverAction;
	    }
       
	}
}
