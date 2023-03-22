
public class AddressBook
{
  public int ID { get; set; }
  public string Name { get; set; }
  public string Address { get; set; }
  public string Email { get; set; }
  public string PhoneNumber { get; set; }

  public AddressBook () {}
  
  public AddressBook (string name)
  {
    Name = name;
  }

  public AddressBook (int id, string name, string address, string email, string phoneNumber)
  {
    ID = id;
    Name = name;
    Address = address;
    Email = email;
    PhoneNumber = phoneNumber;
  }
}
