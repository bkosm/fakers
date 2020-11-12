defmodule FakersApi.People do
  @moduledoc """
  The People context.
  """

  import Ecto.Query, warn: false
  alias FakersApi.Repo

  alias FakersApi.People.Person

  @doc """
  Returns the list of people.

  ## Examples

      iex> list_people()
      [%Person{}, ...]

  """
  def list_people do
    Repo.all(Person)
  end

  @doc """
  Gets a single person.

  Raises `Ecto.NoResultsError` if the Person does not exist.

  ## Examples

      iex> get_person!(123)
      %Person{}

      iex> get_person!(456)
      ** (Ecto.NoResultsError)

  """
  def get_person!(id), do: Repo.get!(Person, id)

  @doc """
  Creates a person.

  ## Examples

      iex> create_person(%{field: value})
      {:ok, %Person{}}

      iex> create_person(%{field: bad_value})
      {:error, %Ecto.Changeset{}}

  """
  def create_person(attrs \\ %{}) do
    %Person{}
    |> Person.changeset(attrs)
    |> Repo.insert()
  end

  @doc """
  Updates a person.

  ## Examples

      iex> update_person(person, %{field: new_value})
      {:ok, %Person{}}

      iex> update_person(person, %{field: bad_value})
      {:error, %Ecto.Changeset{}}

  """
  def update_person(%Person{} = person, attrs) do
    person
    |> Person.changeset(attrs)
    |> Repo.update()
  end

  @doc """
  Deletes a person.

  ## Examples

      iex> delete_person(person)
      {:ok, %Person{}}

      iex> delete_person(person)
      {:error, %Ecto.Changeset{}}

  """
  def delete_person(%Person{} = person) do
    Repo.delete(person)
  end

  @doc """
  Returns an `%Ecto.Changeset{}` for tracking person changes.

  ## Examples

      iex> change_person(person)
      %Ecto.Changeset{data: %Person{}}

  """
  def change_person(%Person{} = person, attrs \\ %{}) do
    Person.changeset(person, attrs)
  end

  alias FakersApi.People.Address

  @doc """
  Returns the list of addresses.

  ## Examples

      iex> list_addresses()
      [%Address{}, ...]

  """
  def list_addresses do
    Repo.all(Address)
  end

  @doc """
  Gets a single address.

  Raises `Ecto.NoResultsError` if the Address does not exist.

  ## Examples

      iex> get_address!(123)
      %Address{}

      iex> get_address!(456)
      ** (Ecto.NoResultsError)

  """
  def get_address!(id), do: Repo.get!(Address, id)

  @doc """
  Creates a address.

  ## Examples

      iex> create_address(%{field: value})
      {:ok, %Address{}}

      iex> create_address(%{field: bad_value})
      {:error, %Ecto.Changeset{}}

  """
  def create_address(attrs \\ %{}) do
    %Address{}
    |> Address.changeset(attrs)
    |> Repo.insert()
  end

  @doc """
  Updates a address.

  ## Examples

      iex> update_address(address, %{field: new_value})
      {:ok, %Address{}}

      iex> update_address(address, %{field: bad_value})
      {:error, %Ecto.Changeset{}}

  """
  def update_address(%Address{} = address, attrs) do
    address
    |> Address.changeset(attrs)
    |> Repo.update()
  end

  @doc """
  Deletes a address.

  ## Examples

      iex> delete_address(address)
      {:ok, %Address{}}

      iex> delete_address(address)
      {:error, %Ecto.Changeset{}}

  """
  def delete_address(%Address{} = address) do
    Repo.delete(address)
  end

  @doc """
  Returns an `%Ecto.Changeset{}` for tracking address changes.

  ## Examples

      iex> change_address(address)
      %Ecto.Changeset{data: %Address{}}

  """
  def change_address(%Address{} = address, attrs \\ %{}) do
    Address.changeset(address, attrs)
  end

  alias FakersApi.People.Contact

  @doc """
  Returns the list of contacts.

  ## Examples

      iex> list_contacts()
      [%Contact{}, ...]

  """
  def list_contacts do
    Repo.all(Contact)
  end

  @doc """
  Gets a single contact.

  Raises `Ecto.NoResultsError` if the Contact does not exist.

  ## Examples

      iex> get_contact!(123)
      %Contact{}

      iex> get_contact!(456)
      ** (Ecto.NoResultsError)

  """
  def get_contact!(id), do: Repo.get!(Contact, id)

  @doc """
  Creates a contact.

  ## Examples

      iex> create_contact(%{field: value})
      {:ok, %Contact{}}

      iex> create_contact(%{field: bad_value})
      {:error, %Ecto.Changeset{}}

  """
  def create_contact(attrs \\ %{}) do
    %Contact{}
    |> Contact.changeset(attrs)
    |> Repo.insert()
  end

  @doc """
  Updates a contact.

  ## Examples

      iex> update_contact(contact, %{field: new_value})
      {:ok, %Contact{}}

      iex> update_contact(contact, %{field: bad_value})
      {:error, %Ecto.Changeset{}}

  """
  def update_contact(%Contact{} = contact, attrs) do
    contact
    |> Contact.changeset(attrs)
    |> Repo.update()
  end

  @doc """
  Deletes a contact.

  ## Examples

      iex> delete_contact(contact)
      {:ok, %Contact{}}

      iex> delete_contact(contact)
      {:error, %Ecto.Changeset{}}

  """
  def delete_contact(%Contact{} = contact) do
    Repo.delete(contact)
  end

  @doc """
  Returns an `%Ecto.Changeset{}` for tracking contact changes.

  ## Examples

      iex> change_contact(contact)
      %Ecto.Changeset{data: %Contact{}}

  """
  def change_contact(%Contact{} = contact, attrs \\ %{}) do
    Contact.changeset(contact, attrs)
  end

  alias FakersApi.People.PersonAddress

  @doc """
  Returns the list of person_address.

  ## Examples

      iex> list_person_address()
      [%PersonAddress{}, ...]

  """
  def list_person_address do
    Repo.all(PersonAddress)
  end

  @doc """
  Gets a single person_address.

  Raises `Ecto.NoResultsError` if the Person address does not exist.

  ## Examples

      iex> get_person_address!(123, 3)
      %PersonAddress{}

      iex> get_person_address!(456, 123)
      ** (Ecto.NoResultsError)

  """
  def get_person_address!(person_id, address_id) do
     Repo.get_by!(PersonAddress, person_id: person_id, address_id: address_id)
  end

  @doc """
  Creates a person_address.

  ## Examples

      iex> create_person_address(%{field: value})
      {:ok, %PersonAddress{}}

      iex> create_person_address(%{field: bad_value})
      {:error, %Ecto.Changeset{}}

  """
  def create_person_address(attrs, %Person{} = person, %Address{} = address) do
    person_address = Ecto.build_assoc(person, :person_addresses)

    Ecto.build_assoc(address, :person_addresses, person_address)
    |> PersonAddress.changeset(attrs)
    |> Repo.insert()
  end

  @doc """
  Deletes a person_address.

  ## Examples

      iex> delete_person_address(person_address)
      {:ok, %PersonAddress{}}

      iex> delete_person_address(person_address)
      {:error, %Ecto.Changeset{}}

  """
  def delete_person_address(%PersonAddress{} = person_address) do
    Repo.delete(person_address)
  end

  @doc """
  Returns an `%Ecto.Changeset{}` for tracking person_address changes.

  ## Examples

      iex> change_person_address(person_address)
      %Ecto.Changeset{data: %PersonAddress{}}

  """
  def change_person_address(%PersonAddress{} = person_address, attrs \\ %{}) do
    PersonAddress.changeset(person_address, attrs)
  end

  alias FakersApi.People.PersonContact

  @doc """
  Returns the list of person_contact.

  ## Examples

      iex> list_person_contact()
      [%PersonContact{}, ...]

  """
  def list_person_contact do
    Repo.all(PersonContact)
  end

  @doc """
  Gets a single person_contact.

  Raises `Ecto.NoResultsError` if the Person contact does not exist.

  ## Examples

      iex> get_person_contact!(123, 2)
      %PersonContact{}

      iex> get_person_contact!(456, 3)
      ** (Ecto.NoResultsError)

  """
  def get_person_contact!(person_id, contact_id) do
     Repo.get_by!(PersonContact, person_id: person_id, contact_id: contact_id)
  end
  
  @doc """
  Creates a person_contact.

  """
  def create_person_contact(attrs, %Person{} = person, %Contact{} = contact) do
    person_contact = Ecto.build_assoc(person, :person_contacts)

    Ecto.build_assoc(contact, :person_contacts, person_contact)
    |> PersonContact.changeset(attrs)
    |> Repo.insert()
  end

  @doc """
  Deletes a person_contact.

  ## Examples

      iex> delete_person_contact(person_contact)
      {:ok, %PersonContact{}}

      iex> delete_person_contact(person_contact)
      {:error, %Ecto.Changeset{}}

  """
  def delete_person_contact(%PersonContact{} = person_contact) do
    Repo.delete(person_contact)
  end

  @doc """
  Returns an `%Ecto.Changeset{}` for tracking person_contact changes.

  ## Examples

      iex> change_person_contact(person_contact)
      %Ecto.Changeset{data: %PersonContact{}}

  """
  def change_person_contact(%PersonContact{} = person_contact, attrs \\ %{}) do
    PersonContact.changeset(person_contact, attrs)
  end

  alias FakersApi.People.DeceasedPerson

  @doc """
  Returns the list of deceased_person.

  ## Examples

      iex> list_deceased_person()
      [%DeceasedPerson{}, ...]

  """
  def list_deceased_person do
    Repo.all(DeceasedPerson)
  end

  @doc """
  Gets a single deceased_person.

  Raises `Ecto.NoResultsError` if the Deceased person does not exist.

  ## Examples

      iex> get_deceased_person!(123)
      %DeceasedPerson{}

      iex> get_deceased_person!(456)
      ** (Ecto.NoResultsError)

  """
  def get_deceased_person!(id), do: Repo.get_by!(DeceasedPerson, person_id: id)

  @doc """
  Creates a deceased_person.

  ## Examples

      iex> create_deceased_person(%{field: value})
      {:ok, %DeceasedPerson{}}

      iex> create_deceased_person(%{field: bad_value})
      {:error, %Ecto.Changeset{}}

  """
  def create_deceased_person(attrs, %Person{} = person) do
    Ecto.build_assoc(person, :deceased_person)
    |> DeceasedPerson.changeset(attrs)
    |> Repo.insert()
  end

  @doc """
  Updates a deceased_person.

  ## Examples

      iex> update_deceased_person(deceased_person, %{field: new_value})
      {:ok, %DeceasedPerson{}}

      iex> update_deceased_person(deceased_person, %{field: bad_value})
      {:error, %Ecto.Changeset{}}

  """
  def update_deceased_person(%DeceasedPerson{} = deceased_person, attrs) do
    deceased_person
    |> DeceasedPerson.changeset(attrs)
    |> Repo.update()
  end

  @doc """
  Deletes a deceased_person.

  ## Examples

      iex> delete_deceased_person(deceased_person)
      {:ok, %DeceasedPerson{}}

      iex> delete_deceased_person(deceased_person)
      {:error, %Ecto.Changeset{}}

  """
  def delete_deceased_person(%DeceasedPerson{} = deceased_person) do
    Repo.delete(deceased_person)
  end

  @doc """
  Returns an `%Ecto.Changeset{}` for tracking deceased_person changes.

  ## Examples

      iex> change_deceased_person(deceased_person)
      %Ecto.Changeset{data: %DeceasedPerson{}}

  """
  def change_deceased_person(%DeceasedPerson{} = deceased_person, attrs \\ %{}) do
    DeceasedPerson.changeset(deceased_person, attrs)
  end
end
