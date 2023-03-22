using System.Data;
public class AddressBookRepositoryTests
{
    private AddressBookRepository _repo = new AddressBookRepository();
    private AddressBook _contact = new AddressBook();
    [SetUp]
    public void RunBeforeTests()
    {
        // _contact = new AddressBook(4, "Jasper", "Address 4", "Jasper@gmail.com", "(444)-444-4444");
        // _repo.AddNewContact(_contact);
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
        _contact = new AddressBook(4, "Jasper", "Address 4", "Jasper@gmail.com", "(444)-444-4444");
        _repo.AddNewContact(_contact);

        AddressBook contact = _repo.GetContactByName("Jasper");

        Assert.IsNotNull(contact);
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
        // The EditContactById() is returning false for some reason, possibly the GetContactById() is returning null causing it to return false

        // AddressBook newContact = new AddressBook();
        AddressBook bentley = new AddressBook(3, "Bentley", "Address 5", "Bentley@gmail.com", "(555)-555-5555");

        bool isUpdated = _repo.EditContactById(bentley);

        Assert.IsTrue(isUpdated);
    }

}