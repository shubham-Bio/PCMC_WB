public class ComboboxItem
{
	public int id
	{
		get;
		set;
	}

	public string name
	{
		get;
		set;
	}

	public int type
	{
		get;
		set;
	}

	public int weighbridge_id
	{
		get;
		set;
	}

	public override string ToString()
	{
		return name;
	}
}
