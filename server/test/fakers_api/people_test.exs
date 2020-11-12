defmodule FakersApi.PeopleTest do
  use FakersApi.DataCase

  alias FakersApi.People

  describe "people" do
    alias FakersApi.People.Person

    @valid_attrs %{
      birth_date: ~D[2010-04-17],
      first_name: "some first_name",
      last_name: "some last_name",
      pesel: "11111111111",
      second_name: "some second_name",
      sex: "f"
    }
    @update_attrs %{
      birth_date: ~D[2011-05-18],
      first_name: "some updated first_name",
      last_name: "some updated last_name",
      pesel: "11111111112",
      second_name: "some updated second_name",
      sex: "m"
    }
    @invalid_attrs %{
      birth_date: nil,
      first_name: nil,
      last_name: nil,
      pesel: nil,
      second_name: nil,
      sex: nil
    }

    def person_fixture(attrs \\ %{}) do
      {:ok, person} =
        attrs
        |> Enum.into(@valid_attrs)
        |> People.create_person()

      person
    end

    test "list_people/0 returns all people" do
      person = person_fixture()
      assert People.list_people() == [person]
    end

    test "get_person!/1 returns the person with given id" do
      person = person_fixture()
      assert People.get_person!(person.id) == person
    end

    test "create_person/1 with valid data creates a person" do
      assert {:ok, %Person{} = person} = People.create_person(@valid_attrs)
      assert person.birth_date == ~D[2010-04-17]
      assert person.first_name == "some first_name"
      assert person.last_name == "some last_name"
      assert person.pesel == "11111111111"
      assert person.second_name == "some second_name"
      assert person.sex == "f"
    end

    test "create_person/1 with invalid data returns error changeset" do
      assert {:error, %Ecto.Changeset{}} = People.create_person(@invalid_attrs)
    end

    test "update_person/2 with valid data updates the person" do
      person = person_fixture()
      assert {:ok, %Person{} = person} = People.update_person(person, @update_attrs)
      assert person.birth_date == ~D[2011-05-18]
      assert person.first_name == "some updated first_name"
      assert person.last_name == "some updated last_name"
      assert person.pesel == "11111111112"
      assert person.second_name == "some updated second_name"
      assert person.sex == "m"
    end

    test "update_person/2 with invalid data returns error changeset" do
      person = person_fixture()
      assert {:error, %Ecto.Changeset{}} = People.update_person(person, @invalid_attrs)
      assert person == People.get_person!(person.id)
    end

    test "delete_person/1 deletes the person" do
      person = person_fixture()
      assert {:ok, %Person{}} = People.delete_person(person)
      assert_raise Ecto.NoResultsError, fn -> People.get_person!(person.id) end
    end

    test "change_person/1 returns a person changeset" do
      person = person_fixture()
      assert %Ecto.Changeset{} = People.change_person(person)
    end
  end

  describe "addresses" do
    alias FakersApi.People.Address

    @valid_attrs %{
      city: "some city",
      location: "some location",
      street: "some street",
      voivodeship: "some voivodeship"
    }
    @update_attrs %{
      city: "some updated city",
      location: "some updated location",
      street: "some updated street",
      voivodeship: "some updated voivodeship"
    }
    @invalid_attrs %{city: nil, location: nil, street: nil, voivodeship: nil}

    def address_fixture(attrs \\ %{}) do
      {:ok, address} =
        attrs
        |> Enum.into(@valid_attrs)
        |> People.create_address()

      address
    end

    test "list_addresses/0 returns all addresses" do
      address = address_fixture()
      assert People.list_addresses() == [address]
    end

    test "get_address!/1 returns the address with given id" do
      address = address_fixture()
      assert People.get_address!(address.id) == address
    end

    test "create_address/1 with valid data creates a address" do
      assert {:ok, %Address{} = address} = People.create_address(@valid_attrs)
      assert address.city == "some city"
      assert address.location == "some location"
      assert address.street == "some street"
      assert address.voivodeship == "some voivodeship"
    end

    test "create_address/1 with invalid data returns error changeset" do
      assert {:error, %Ecto.Changeset{}} = People.create_address(@invalid_attrs)
    end

    test "update_address/2 with valid data updates the address" do
      address = address_fixture()
      assert {:ok, %Address{} = address} = People.update_address(address, @update_attrs)
      assert address.city == "some updated city"
      assert address.location == "some updated location"
      assert address.street == "some updated street"
      assert address.voivodeship == "some updated voivodeship"
    end

    test "update_address/2 with invalid data returns error changeset" do
      address = address_fixture()
      assert {:error, %Ecto.Changeset{}} = People.update_address(address, @invalid_attrs)
      assert address == People.get_address!(address.id)
    end

    test "delete_address/1 deletes the address" do
      address = address_fixture()
      assert {:ok, %Address{}} = People.delete_address(address)
      assert_raise Ecto.NoResultsError, fn -> People.get_address!(address.id) end
    end

    test "change_address/1 returns a address changeset" do
      address = address_fixture()
      assert %Ecto.Changeset{} = People.change_address(address)
    end
  end

  describe "contacts" do
    alias FakersApi.People.Contact

    @valid_attrs %{email: "some email", phone_number: "1111111111"}
    @update_attrs %{email: "some updated email", phone_number: "2222222222"}
    @invalid_attrs %{email: nil, phone_number: nil}

    def contact_fixture(attrs \\ %{}) do
      {:ok, contact} =
        attrs
        |> Enum.into(@valid_attrs)
        |> People.create_contact()

      contact
    end

    test "list_contacts/0 returns all contacts" do
      contact = contact_fixture()
      assert People.list_contacts() == [contact]
    end

    test "get_contact!/1 returns the contact with given id" do
      contact = contact_fixture()
      assert People.get_contact!(contact.id) == contact
    end

    test "create_contact/1 with valid data creates a contact" do
      assert {:ok, %Contact{} = contact} = People.create_contact(@valid_attrs)
      assert contact.email == "some email"
      assert contact.phone_number == "1111111111"
    end

    test "create_contact/1 with invalid data returns error changeset" do
      assert {:error, %Ecto.Changeset{}} = People.create_contact(@invalid_attrs)
    end

    test "create_contact/1 with no phone succeeds" do
      assert {:ok, %Contact{} = contact} =
               People.create_contact(%{email: "some mail", phone_number: nil})

      assert contact.phone_number == nil
    end

    test "update_contact/2 with valid data updates the contact" do
      contact = contact_fixture()
      assert {:ok, %Contact{} = contact} = People.update_contact(contact, @update_attrs)
      assert contact.email == "some updated email"
      assert contact.phone_number == "2222222222"
    end

    test "update_contact/2 with invalid data returns error changeset" do
      contact = contact_fixture()
      assert {:error, %Ecto.Changeset{}} = People.update_contact(contact, @invalid_attrs)
      assert contact == People.get_contact!(contact.id)
    end

    test "delete_contact/1 deletes the contact" do
      contact = contact_fixture()
      assert {:ok, %Contact{}} = People.delete_contact(contact)
      assert_raise Ecto.NoResultsError, fn -> People.get_contact!(contact.id) end
    end

    test "change_contact/1 returns a contact changeset" do
      contact = contact_fixture()
      assert %Ecto.Changeset{} = People.change_contact(contact)
    end
  end

  describe "person_address" do
    alias FakersApi.People.PersonAddress

    @valid_person %{
      birth_date: ~D[2010-04-17],
      first_name: "some first_name",
      last_name: "some last_name",
      pesel: "11111111111",
      second_name: "some second_name",
      sex: "f"
    }
    @valid_address %{
      city: "some city",
      location: "some location",
      street: "some street",
      voivodeship: "some voivodeship"
    }

    @valid_attrs %{assigned: ~D[2010-04-17]}

    def person_address_fixture(attrs \\ %{}) do
      {:ok, person} = People.create_person(@valid_person)
      {:ok, address} = People.create_address(@valid_address)

      {:ok, person_address} =
        attrs
        |> Enum.into(@valid_attrs)
        |> People.create_person_address(person, address)

      {person, address, person_address}
    end

    test "list_person_address/0 returns all person_address" do
      {_, _, person_address} = person_address_fixture()
      assert People.list_person_address() == [person_address]
    end

    test "get_person_address!/1 returns the person_address with given id" do
      {person, address, person_address} = person_address_fixture()
      assert People.get_person_address!(person.id, address.id) == person_address
    end

    test "create_person_address/3 with invalid data conforms to unique key and returns error changeset" do
      {person, address, _} = person_address_fixture()

      assert {:error, %Ecto.Changeset{}} =
               People.create_person_address(@valid_attrs, person, address)
    end

    test "delete_person_address/1 deletes the person_address" do
      {person, address, person_address} = person_address_fixture()

      assert {:ok, %PersonAddress{}} = People.delete_person_address(person_address)

      assert_raise Ecto.NoResultsError, fn -> People.get_person_address!(person.id, address.id) end
    end

    test "change_person_address/1 returns a person_address changeset" do
      {_, _, person_address} = person_address_fixture()
      assert %Ecto.Changeset{} = People.change_person_address(person_address)
    end
  end

  describe "person_contact" do
    alias FakersApi.People.PersonContact

    @valid_contact %{email: "some email", phone_number: "1111111111"}

    @valid_person %{
      birth_date: ~D[2010-04-17],
      first_name: "some first_name",
      last_name: "some last_name",
      pesel: "11111111111",
      second_name: "some second_name",
      sex: "f"
    }

    @valid_attrs %{assigned: ~D[2010-04-17]}
    @update_attrs %{assigned: ~D[2011-05-18]}

    def person_contact_fixture(attrs \\ %{}) do
      {:ok, person} = People.create_person(@valid_person)
      {:ok, contact} = People.create_contact(@valid_contact)

      {:ok, person_contact} =
        attrs
        |> Enum.into(@valid_attrs)
        |> People.create_person_contact(person, contact)

      {person, contact, person_contact}
    end

    test "list_person_contact/0 returns all person_contact" do
      {_, _, person_contact} = person_contact_fixture()
      assert People.list_person_contact() == [person_contact]
    end

    test "get_person_contact!/1 returns the person_contact with given id" do
      {person, contact, person_contact} = person_contact_fixture()
      assert People.get_person_contact!(person.id, contact.id) == person_contact
    end

    test "create_person_contact/3 with invalid data conforms to unique key and returns error changeset" do
      {person, contact, _} = person_contact_fixture()

      assert {:error, %Ecto.Changeset{}} = People.create_person_contact(@valid_attrs, person, contact)
    end

    test "delete_person_contact/1 deletes the person_contact" do
      {person, contact, person_contact} = person_contact_fixture()
      assert {:ok, %PersonContact{}} = People.delete_person_contact(person_contact)
      assert_raise Ecto.NoResultsError, fn -> People.get_person_contact!(person.id, contact.id) end
    end

    test "change_person_contact/1 returns a person_contact changeset" do
      {_, _, person_contact} = person_contact_fixture()
      assert %Ecto.Changeset{} = People.change_person_contact(person_contact)
    end
  end

  describe "deceased_person" do
    alias FakersApi.People.DeceasedPerson

    @valid_person %{
      birth_date: ~D[2010-04-17],
      first_name: "some first_name",
      last_name: "some last_name",
      pesel: "11111111111",
      second_name: "some second_name",
      sex: "f"
    }

    @valid_attrs %{date_of_death: ~D[2010-04-17]}
    @update_attrs %{date_of_death: ~D[2011-05-18]}

    def deceased_person_fixture(attrs \\ %{}) do
      {:ok, person} = People.create_person(@valid_person)

      {:ok, deceased_person} =
        attrs
        |> Enum.into(@valid_attrs)
        |> People.create_deceased_person(person)

      {person, deceased_person}
    end

    test "list_deceased_person/0 returns all deceased_person" do
      {_, deceased_person} = deceased_person_fixture()
      assert People.list_deceased_person() == [deceased_person]
    end

    test "get_deceased_person!/1 returns the deceased_person with given id" do
      {person, deceased_person} = deceased_person_fixture()
      assert People.get_deceased_person!(person.id) == deceased_person
    end

    test "create_deceased_person/2 with valid data creates a deceased_person" do
      {:ok, person} = People.create_person(@valid_person)
      assert {:ok, %DeceasedPerson{} = deceased_person} = People.create_deceased_person(@valid_attrs, person)
      assert deceased_person.date_of_death == ~D[2010-04-17]
    end

    test "create_deceased_person/1 with invalid data conforms to unique key and returns error changeset" do
      {person, _} = deceased_person_fixture()

      assert {:error, %Ecto.Changeset{}} = People.create_deceased_person(@valid_attrs, person)
    end

    test "update_deceased_person/2 with valid data updates the deceased_person" do
      {_, deceased_person} = deceased_person_fixture()
      assert {:ok, %DeceasedPerson{} = deceased_person} = People.update_deceased_person(deceased_person, @update_attrs)
      assert deceased_person.date_of_death == ~D[2011-05-18]
    end

    test "delete_deceased_person/1 deletes the deceased_person" do
      {person, deceased_person} = deceased_person_fixture()
      assert {:ok, %DeceasedPerson{}} = People.delete_deceased_person(deceased_person)
      assert_raise Ecto.NoResultsError, fn -> People.get_deceased_person!(person.id) end
    end

    test "change_deceased_person/1 returns a deceased_person changeset" do
      {_, deceased_person} = deceased_person_fixture()
      assert %Ecto.Changeset{} = People.change_deceased_person(deceased_person)
    end
  end
end
