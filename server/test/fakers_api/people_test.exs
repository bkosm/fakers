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
    @update_attrs %{assigned: ~D[2011-05-18]}
    @invalid_attrs %{assigned: nil}

    def person_address_fixture(attrs \\ %{}) do
      {:ok, person} =
        attrs
        |> Enum.into(@valid_person)
        |> People.create_person()

      {:ok, address} =
        attrs
        |> Enum.into(@valid_address)
        |> People.create_address()

      fixture =
        @valid_attrs
        |> Map.put(:person, person)
        |> Map.put(:address, address)

      fixture =
        attrs
        |> Enum.into(fixture)
      
      x = 
      person
      |> Ecto.build_assoc(:person_addresses)
      |> Ecto.Changeset.change()
      |> Ecto.Changeset.put_assoc(:person_addresses, address)

      IO.inspect x

      {:ok, person_address} =
        attrs
        |> Enum.into(fixture)
        |> People.create_person_address()

      person_address
    end

    test "list_person_address/0 returns all person_address" do
      person_address = person_address_fixture()
      assert People.list_person_address() == [person_address]
    end

    test "get_person_address!/1 returns the person_address with given id" do
      person_address = person_address_fixture()
      assert People.get_person_address!(person_address.id) == person_address
    end

    test "create_person_address/1 with valid data creates a person_address" do
      assert {:ok, %PersonAddress{} = person_address} = People.create_person_address(@valid_attrs)
      assert person_address.assigned == ~D[2010-04-17]
    end

    test "create_person_address/1 with invalid data returns error changeset" do
      assert {:error, %Ecto.Changeset{}} = People.create_person_address(@invalid_attrs)
    end

    test "update_person_address/2 with valid data updates the person_address" do
      person_address = person_address_fixture()

      assert {:ok, %PersonAddress{} = person_address} =
               People.update_person_address(person_address, @update_attrs)

      assert person_address.assigned == ~D[2011-05-18]
    end

    test "update_person_address/2 with invalid data returns error changeset" do
      person_address = person_address_fixture()

      assert {:error, %Ecto.Changeset{}} =
               People.update_person_address(person_address, @invalid_attrs)

      assert person_address == People.get_person_address!(person_address.id)
    end

    test "delete_person_address/1 deletes the person_address" do
      person_address = person_address_fixture()
      assert {:ok, %PersonAddress{}} = People.delete_person_address(person_address)
      assert_raise Ecto.NoResultsError, fn -> People.get_person_address!(person_address.id) end
    end

    test "change_person_address/1 returns a person_address changeset" do
      person_address = person_address_fixture()
      assert %Ecto.Changeset{} = People.change_person_address(person_address)
    end
  end
end
