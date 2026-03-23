namespace DistrictCourt;

public class Citizen
{
    // Properties
    public string Name { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
    
    // Constructor
    protected Citizen(string name, string address, int age)
    {
        Name = name;
        Address = address;
        Age = age;
    }
}