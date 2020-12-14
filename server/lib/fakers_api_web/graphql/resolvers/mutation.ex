defmodule FakersApiWeb.GraphQL.Resolvers.Mutation do
  alias FakersApi.People, as: Context

  def create_person(arguments, _) do
    case Context.create_person(arguments) do
      {:ok, person} ->
        {:ok, person}

      _error ->
        {:error,
         "Couldn't create a person from given data. Unique fields might already exist in the database."}
    end
  end

  def update_person(arguments, _) do
    {person_id, arguments} = Map.pop(arguments, :id)

    case Context.get_person(person_id) do
      nil ->
        {:error, "No person found with given id."}

      person ->
        case Context.update_person(person, arguments) do
          {:ok, person} ->
            {:ok, person}

          _error ->
            {:error,
             "Couldn't update person using given data. Perhaps a field should not be null?"}
        end
    end
  end

  def create_address(arguments, _) do
    case Context.create_address(arguments) do
      {:ok, address} ->
        {:ok, address}

      _error ->
        {:error,
         "Couldn't create an address from given data. Unique fields might already exist in the database."}
    end
  end

  def update_address(arguments, _) do
    {address_id, arguments} = Map.pop(arguments, :id)

    case Context.get_address(address_id) do
      nil ->
        {:error, "No person found with given id."}

      address ->
        case Context.update_address(address, arguments) do
          {:ok, address} ->
            {:ok, address}

          _error ->
            {:error,
             "Couldn't update address using given data. Perhaps a field should not be null?"}
        end
    end
  end

  def create_contact(arguments, _) do
    case Context.create_contact(arguments) do
      {:ok, contact} ->
        {:ok, contact}

      _error ->
        {:error,
         "Couldn't create a contact from given data. Unique fields might already exist in the database."}
    end
  end

  def update_contact(arguments, _) do
    {contact_id, arguments} = Map.pop(arguments, :id)

    case Context.get_contact(contact_id) do
      nil ->
        {:error, "No person found with given id."}

      contact ->
        case Context.update_contact(contact, arguments) do
          {:ok, contact} ->
            {:ok, contact}

          _error ->
            {:error,
             "Couldn't modify a contact from given data. Perhaps a field should not be null?"}
        end
    end
  end

  def create_deceased_person(arguments, _) do
    {person_id, arguments} = Map.pop(arguments, :person_id)

    case Context.get_person(person_id) do
      nil ->
        {:error, "No person found with given id."}

      person ->
        case Context.create_deceased_person(arguments, person) do
          {:ok, person} ->
            {:ok, person}

          _error ->
            {:error, "Couldn't register person as deceased."}
        end
    end
  end

  def remove_deceased_person(%{person_id: person_id}, _) do
    case Context.get_deceased_person(person_id) do
      nil ->
        {:error, "No deceased person with given id found."}

      person ->
        case Context.delete_deceased_person(person) do
          {:ok, person} ->
            {:ok, person}

          _error ->
            {:error, "Couldn't revive person with given id."}
        end
    end
  end

  def create_person_address(arguments, _) do
    {person_id, arguments} = Map.pop(arguments, :person_id)
    {address_id, arguments} = Map.pop(arguments, :address_id)

    person = Context.get_person(person_id)
    address = Context.get_address(address_id)

    if is_nil(person) or is_nil(address) do
      {:error, "Person or address do not exist."}
    else
      case Context.create_person_address(arguments, person, address) do
        {:ok, person_address} ->
          {:ok, person_address}

        _error ->
          {:error, "Could not create person and address association. Possible duplicate."}
      end
    end
  end

  def update_person_address(arguments, _) do
    {person_id, arguments} = Map.pop(arguments, :person_id)
    {address_id, arguments} = Map.pop(arguments, :address_id)

    case Context.get_person_address(person_id, address_id) do
      nil ->
        {:error, "Given person address association does not exist."}

      person_address ->
        case Context.update_person_address(arguments, person_address) do
          {:ok, person_address} ->
            {:ok, person_address}

          _error ->
            {:error, "Could not update person address association from given arguments."}
        end
    end
  end

  def remove_person_address(arguments, _) do
    {person_id, arguments} = Map.pop(arguments, :person_id)
    {address_id, _arguments} = Map.pop(arguments, :address_id)

    case Context.get_person_address(person_id, address_id) do
      nil ->
        {:error, "Given person address association does not exist."}

      person_address ->
        case Context.delete_person_address(person_address) do
          {:ok, person_address} ->
            {:ok, person_address}

          _error ->
            {:error, "Could not remove person address association from given arguments."}
        end
    end
  end

  def create_person_contact(arguments, _) do
    {person_id, arguments} = Map.pop(arguments, :person_id)
    {contact_id, arguments} = Map.pop(arguments, :contact_id)

    person = Context.get_person(person_id)
    contact = Context.get_contact(contact_id)

    if is_nil(person) or is_nil(contact) do
      {:error, "Person or contact do not exist."}
    else
      case Context.create_person_contact(arguments, person, contact) do
        {:ok, person_contact} ->
          {:ok, person_contact}

        _error ->
          {:error, "Could not create person and contact association. Possible duplicate."}
      end
    end
  end

  def update_person_contact(arguments, _) do
    {person_id, arguments} = Map.pop(arguments, :person_id)
    {contact_id, arguments} = Map.pop(arguments, :contact_id)

    case Context.get_person_contact(person_id, contact_id) do
      nil ->
        {:error, "Given person contact association does not exist."}

      person_contact ->
        case Context.update_person_contact(arguments, person_contact) do
          {:ok, person_contact} ->
            {:ok, person_contact}

          _error ->
            {:error, "Could not update person contact association from given arguments."}
        end
    end
  end

  def remove_person_contact(arguments, _) do
    {person_id, arguments} = Map.pop(arguments, :person_id)
    {contact_id, _arguments} = Map.pop(arguments, :contact_id)

    case Context.get_person_contact(person_id, contact_id) do
      nil ->
        {:error, "Given person contact association does not exist."}

      person_contact ->
        case Context.delete_person_contact(person_contact) do
          {:ok, person_contact} ->
            {:ok, person_contact}

          _error ->
            {:error, "Could not remove person contact association from given arguments."}
        end
    end
  end
end
