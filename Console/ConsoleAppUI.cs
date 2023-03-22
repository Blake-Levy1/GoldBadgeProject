
public class ConsoleAppUI
{
  private AddressBook _addressBook = new AddressBook();
  private AddressBookRepository _addressRepo = new AddressBookRepository();

public void Run()
{
  SeedContactList();
  Menu();
}

  private void Menu()
  {
    bool keepRunning = true;
    while (keepRunning)
    {
      System.Console.WriteLine("Select a menu option:\n" +
      "1. View all contacts\n" +
      "2. Create new contact\n" +
      "3. Find contact(s) by name\n" +
      "4. Modify contact\n" +
      "5. Remove contact\n" +
      "6. Exit");

      string inputAsString = Console.ReadLine();
      int inputAsInt = int.Parse(inputAsString);

      switch (inputAsInt)
      {
        case 1:
          // View all contacts
          ViewAllContacts();
          break;
        case 2:
          // Create new contact
          CreateNewContact();
          break;
        case 3:
          // Find contact(s) by name
          FindContactsByName();
          break;
        case 4:
          // Modify contact
          ModifyContact();
          break;
        case 5:
          // Remove contact
          RemoveContact();
          break;
        case 6:
          // Exit
          keepRunning = false;
          System.Console.WriteLine("Goodbye");
          break;
      }
      System.Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
      Console.Clear();
    }
  }

  //            view all contacts
  public void ViewAllContacts()
  {
    Dictionary<int, AddressBook> _listOfContacts = _addressRepo.ListAllContacts();

    foreach (KeyValuePair<int, AddressBook> contact in _listOfContacts)
    {
      System.Console.WriteLine($"ID: {contact.Value.ID}\n" +
      $"Name: {contact.Value.Name}\n" +
      $"Address: {contact.Value.Address}\n" +
      $"Email: {contact.Value.Email}\n" +
      $"Phone Number: {contact.Value.PhoneNumber}\n");
    }
  }

  //            Create new Contact
  public void CreateNewContact()  // Need to figure out how to stop porgram when ID is already taken
  {
    Dictionary<int, AddressBook> _listOfContacts = _addressRepo.ListAllContacts();

    AddressBook newContact = new AddressBook();

    newContact.ID = GetUniqueId();

    System.Console.WriteLine("Enter the name of the new contact");
    newContact.Name = Console.ReadLine();

    System.Console.WriteLine("Enter the Address of the new contact");
    newContact.Address = Console.ReadLine();

    System.Console.WriteLine("Enter the email of the new contact");
    newContact.Email = Console.ReadLine();

    System.Console.WriteLine("Enter the phone number of the new contact");
    newContact.PhoneNumber = Console.ReadLine();

    _addressRepo.AddNewContact(newContact);
  }

  //            Find contact(s) by name
  public void FindContactsByName()
  {
    List<AddressBook> contactsToFind = new List<AddressBook>();
    bool addMore = true;
    while (addMore)
    {
      System.Console.WriteLine("Enter the name of the contact you would like to find");
      string name = Console.ReadLine();
      AddressBook contact = _addressRepo.GetContactByName(name);
      contactsToFind.Add(contact);
      System.Console.WriteLine("Do you want to find another contact? (y/n)");
      string yesOrNo = Console.ReadLine().ToLower();
      if (yesOrNo == "n")
      {
        addMore = false;
      }
    }
    foreach (AddressBook contact in contactsToFind)
    {
      System.Console.WriteLine($"ID: {contact.ID}\n" +
      $"Name: {contact.Name}\n" +
      $"Address: {contact.Address}\n" +
      $"Email: {contact.Email}\n" +
      $"Phone Number: {contact.PhoneNumber}\n");
    }
  }

  //            Modify contact            
  public void ModifyContact()
  {
    ViewAllContacts();

    AddressBook newContactInfo = new AddressBook();

    System.Console.WriteLine("Enter the ID of the contact you would like to modify");
    string idAsString = Console.ReadLine();
    int idAsInt = int.Parse(idAsString);
    AddressBook oldContactInfo = _addressRepo.GetContactById(idAsInt);

    System.Console.WriteLine($"Type the number of the property you would like to change:\n" +
    $"1. Name: {oldContactInfo.Name}\n" +
    $"2. Address: {oldContactInfo.Address}\n" +
    $"3. Email: {oldContactInfo.Email}\n" +
    $"4. PhoneNumber: {oldContactInfo.PhoneNumber}\n" +
    "5. Cancel Changes");

    string inputToChange = Console.ReadLine();

    if (inputToChange != "5")
    {
      System.Console.WriteLine("What is the updated information for this property?");
      string updatedInfo = Console.ReadLine();

      switch (inputToChange)
      {
        case "1":
          oldContactInfo.Name = updatedInfo;
          break;
        case "2":
          oldContactInfo.Address = updatedInfo;
          break;
        case "3":
          oldContactInfo.Email = updatedInfo;
          break;
        case "4":
          oldContactInfo.PhoneNumber = updatedInfo;
          break;
      }
      _addressRepo.EditContactById(oldContactInfo);
    }
  }

  //            Remove contact               
  public void RemoveContact()
  {
    ViewAllContacts();

    System.Console.WriteLine("Enter the ID of the contact you would like to remove");
    string idAsString = Console.ReadLine();
    int idAsInt = int.Parse(idAsString);
    _addressRepo.RemoveContactById(idAsInt);
    System.Console.WriteLine("Contact has been deleted\n Press any key to continue...");
    Console.ReadKey();
    Console.Clear();
  }

  public int GetUniqueId()
  {
    bool isUnique = false;
    while (!isUnique)
    {
      bool foundUnique = true;
      System.Console.WriteLine("Enter an ID for the new contact");
      string idAsString = Console.ReadLine();
      int idAsInt = int.Parse(idAsString);
      foreach (KeyValuePair<int, AddressBook> contact in _addressRepo.ListAllContacts())
      {
        if (idAsInt == contact.Key)
        {
          foundUnique = false;
          System.Console.WriteLine("ID is already taken by an existing contact, please restart");
          System.Console.WriteLine("Press any key to continue...");
          Console.ReadKey();
          Console.Clear();
        }
      }
      if (foundUnique)
      {
        System.Console.WriteLine("This is a valid new ID");
        isUnique = true;
        return idAsInt;
      }
    }
    return 0;
  }

  private void SeedContactList()
  {
    AddressBook blake = new AddressBook(1, "Blake", "address 1", "Blake@gmail.com", "(111)-111-1111");
    AddressBook mallory = new AddressBook(2, "Mallory", "address 2", "Mallory@gmail.com", "(222)-222-2222");
    AddressBook keaton = new AddressBook(3, "Keaton", "address 3", "Keaton@gmail.com", "(333)-333-3333");

    _addressRepo.AddNewContact(blake);
    _addressRepo.AddNewContact(mallory);
    _addressRepo.AddNewContact(keaton);
  }
}