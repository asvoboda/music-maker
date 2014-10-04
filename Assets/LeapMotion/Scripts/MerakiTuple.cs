using UnityEngine;
using System.Collections;

public class MerakiTuple {

	private Vector3 vector;
	private long epoch;

	public MerakiTuple(Vector3 vector, long epoch) 
	{
		this.vector = vector;
		this.epoch = epoch;
	}

	public long Epoch
	{
		get { return epoch; }
	}
}
