using UnityEngine;
using System.Collections;

public class Meraki {
	private string client;
	private ArrayList tuples;

	public Meraki(string client, ArrayList tuples) {
		this.client = client;
		this.tuples = tuples;
	}
	
	public string clientName
	{
		get { return client; }
		set { client = clientName; }
	}
	
	public ArrayList merakiTuples
	{
		get { return tuples; }
		set { tuples = merakiTuples; }
	}
}
