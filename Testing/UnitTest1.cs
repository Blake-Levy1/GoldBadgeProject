using System.Data;
public class AddressBookRepositoryTests
{
    private AddressBookRepository _repo = new AddressBookRepository();
    private AddressBook _contact = new AddressBook();
    
    
    [OneTimeSetUp]
    public void RunOnceBeforeTests()
    {

        AddressBook keaton = new AddressBook(3, "Keaton", "address 3", "Keaton@gmail.com", "(333)-333-3333");
        AddressBook jasper = new AddressBook(4, "Jasper", "Address 4", "Jasper@gmail.com", "(444)-444-4444");

        _repo.AddNewContact(keaton);
        _repo.AddNewContact(jasper);
    }

    [Test]
    public void ListAllContacts_ShouldGetNotNull()
    {
        Dictionary<int, AddressBook> listOfContacts = _repo.ListAllContacts();
        Assert.IsNotNull(listOfContacts);
    }

    [Test]
    public void AddContact_ShouldGetNotNull()
    {
        // ARRANGE
        AddressBook contact = new AddressBook();
        contact.Name = "Bentley";
        AddressBookRepository repository = new AddressBookRepository();

        // ACT 
        repository.AddNewContact(contact);
        AddressBook newContact = repository.GetContactByName("Bentley");

        // ASSERT
        Assert.IsNotNull(newContact);
    }

    [Test]
    public void GetContactByName_ShouldGetNotNull()
    {

        AddressBook jasper = _repo.GetContactByName("Jasper");

        Assert.IsNotNull(jasper);
    }

    [Test]
    public void GetContctById_ShouldGetNotNull()
    {
        // AddressBookRepository repository = new AddressBookRepository();

        AddressBook contact = _repo.GetContactById(4);

        Assert.IsNotNull(contact);

    }

    [Test]
    public void RemoveContact_ShouldGetNull()
    {
        AddressBook jasper = _repo.GetContactById(4);
        Assert.IsNotNull(jasper);
        bool wasDeleted = _repo.RemoveContactById(4);
        Assert.IsTrue(wasDeleted);
        AddressBook notJasper = _repo.GetContactById(4);
        Assert.IsNull(notJasper);
    }

    [Test]
    public void UpdateContact_ShouldReturnTrue() 
    {
        // AddressBook keaton = new AddressBook(3, "Keaton", "address 3", "Keaton@gmail.com", "(333)-333-3333");
        // _repo.AddNewContact(keaton);

        // AddressBook newContact = new AddressBook();
        AddressBook bentley = new AddressBook(3, "Bentley", "Address 5", "Bentley@gmail.com", "(555)-555-5555");
        // _repo.AddNewContact(bentley);

        bool isUpdated = _repo.EditContactById(bentley);
        System.Console.WriteLine(_repo.GetContactById(3).Name);

        Assert.IsTrue(isUpdated);
    }

    // [Test]
    // public void UpdateContact_ShouldReturnTrue() 
    // {
    //     // The EditContactById() is returning false for some reason, possibly the GetContactById() is returning null causing it to return false

    //     // AddressBook newContact = new AddressBook();
    //     AddressBook bentley = new AddressBook(5, "Bentley", "Address 5", "Bentley@gmail.com", "(555)-555-5555");
    //     _repo.AddNewContact(bentley);

    //     bool isUpdated = _repo.EditContactById(bentley);

    //     Assert.IsTrue(isUpdated);
    // }


}