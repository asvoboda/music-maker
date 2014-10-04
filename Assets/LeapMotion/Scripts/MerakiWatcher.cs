using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;

public class MerakiWatcher : MonoBehaviour {

	private Hashtable merakisForTheDay = new Hashtable();
	public MerakiScript merakiOriginal;
	private long epoch = 0;
	private string cs = "URI=file:C:\\Users\\Andrew\\Downloads\\cmx_data_anon\\cmx12345.db";

	// Use this for initialization
	void Start () {
		getLatest ();
	}
	
	// Update is called once per frame
	void Update () {
		getLatest ();
	}

	void getLatest() {
		
		using(SqliteConnection con = new SqliteConnection(cs))
		{
			con.Open();
			
			string stm = "select * from cmx where seenEpoch = (select min(seenEpoch) from cmx where seenEpoch > " + epoch + ");";
			
			using (SqliteCommand cmd = new SqliteCommand(stm, con))
			{
				Object prefab = Resources.Load("Sphere");
				GameObject obj;
				
				using (SqliteDataReader rdr = cmd.ExecuteReader())
				{
					while (rdr.Read()) 
					{
						string name = rdr.GetString(7);
						if (!merakisForTheDay.Contains(name)) {
							obj = Instantiate(prefab) as GameObject;
							merakisForTheDay.Add(name, obj);
							obj.GetComponent<MerakiScript>();
							//obj.tag = name;
						}
						
						float x = rdr.GetFloat(5);
						float z = rdr.GetFloat(6);
						//Debug.Log(x + ", " + z);
						
						Vector3 vec = new Vector3(x - 65, 2, z - 48);

						obj = merakisForTheDay[name] as GameObject;

						obj.transform.position = vec;
						
						epoch = rdr.GetInt64(2);
					}
				}
			}
			con.Close();   
		}
	}

}
