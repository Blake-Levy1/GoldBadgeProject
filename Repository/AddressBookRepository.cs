


public class AddressBookRepository 
{
  //                        DICTIONARY
  Dictionary<int, AddressBook> _AddressBookDictionary = new Dictionary<int, AddressBook>();

  //                        ADD A CONTACT
  public void AddNewContact(AddressBook contact)
  {
    _AddressBookDictionary.Add(contact.ID, contact);
  }

  //                        LIST ALL CONTACTS
  public Dictionary<int, AddressBook> ListAllContacts()
  {
    return _AddressBookDictionary;
  }

  //                        GET CONTACT(S) BY NAME
  public AddressBook GetContactByName(string name)
  {
    foreach (KeyValuePair<int, AddressBook> contact in _AddressBookDictionary)
    {
      if (contact.Value.Name == name)
      {
        return contact.Value;
      }
    }
    return null;
  }

  //                        EDIT CONTACT BY ID
  public bool EditContactById(AddressBook newContactInfo)
  {
    AddressBook origionalContact = GetContactById(newContactInfo.ID);

    if (origionalContact != null)
    {
      // origionalContact.ID = newContactInfo.ID;
      origionalContact.Name = newContactInfo.Name;
      origionalContact.Address = newContactInfo.Address;
      origionalContact.Email = newContactInfo.Email;
      origionalContact.PhoneNumber = newContactInfo.PhoneNumber;
      return true;
    }
    return false;
  }
  // public bool EditContactById(int origionalId, AddressBook newContactInfo)
  // {
  //   AddressBook origionalContact = GetContactById(origionalId);

  //   if (origionalContact != null)
  //   {
  //     origionalContact.ID = newContactInfo.ID;
  //     origionalContact.Name = newContactInfo.Name;
  //     origionalContact.Address = newContactInfo.Address;
  //     origionalContact.Email = newContactInfo.Email;
  //     origionalContact.PhoneNumber = newContactInfo.PhoneNumber;
  //     return true;
  //   }
  //   return false;
  // }

  //                        REMOVE CONTACT BY ID
  public bool RemoveContactById(int id)
  {
    AddressBook contact = GetContactById(id);

    if (contact != null)
    {
      int initialCount = _AddressBookDictionary.Count();
      _AddressBookDictionary.Remove(contact.ID);
      int postCount = _AddressBookDictionary.Count();
      if (initialCount > postCount)
      {
        return true;
      }
    }
    return false;
  }
    // foreach(KeyValuePair<int, AddressBook> contact in _AddressBookDictionary)
    // {
    //   if (id == contact.Key)
    //   {
    //     int initialCount = _AddressBookDictionary.Count();
    //     _AddressBookDictionary.Remove(id);
    //     int postCount = _AddressBookDictionary.Count();
    //     if (initialCount > postCount)
    //     {
    //       return true;
    //     }
    //   }
    // }
    //   return false;
  //                                Helper Methods
  public AddressBook GetContactById(int id)
  {
    foreach (KeyValuePair<int, AddressBook> contact in _AddressBookDictionary)
    {
      if (contact.Value.ID == id)
      {
        return contact.Value;
      }
    }
    return null;
  }
}