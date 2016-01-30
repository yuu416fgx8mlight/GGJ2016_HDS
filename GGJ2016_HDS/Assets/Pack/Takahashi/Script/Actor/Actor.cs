using UnityEngine;
using System.Collections;

[System.Serializable]
public class Actor{

    private int m_id;
    private string m_uniqueid;
    private string m_name;

    public Actor()
    {
        m_id = 0;
        m_uniqueid = "";
        m_name = "";
    }
    public void SetActor(int id,string uniqueid,string name)
    {
        m_id = id;
        m_uniqueid = uniqueid;
        m_name = name;
    }

    public int ID
    {
        get { return m_id; }
        set { m_id = value; }
    }
    public string UniqueID
    {
        get { return m_uniqueid; }
        set { m_uniqueid = value; }
    }
    public string Name
    {
        get { return m_name; }
        set { m_name = value; }
    }


}
