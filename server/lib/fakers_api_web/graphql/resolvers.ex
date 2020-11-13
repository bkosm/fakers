defmodule FakersApiWeb.GraphQL.Resolvers do
  alias FakersApi.People, as: Context

  def get_people(_args, _resolution), do: {:ok, Context.list_people()}

  def get_people_by_last_name(%{last_name: last_name}, %{last_name: last_name}), do: {:ok, Context.list_people_by_last_name(last_name)}

  def get_person_by_id(%{id: id},_resolution) do
    case Context.get_person(id) do
      nil -> {:error, "person not found, id=#{id}"}
      person -> {:ok, person}
    end
  end

  def get_person_by_pesel(%{pesel: pesel}, _resolution) do
    case Context.get_person_by_pesel(pesel) do
      nil -> {:error, "person not found, pesel=#{pesel}"}
      person -> {:ok, person}
    end
  end

  def get_address(%{id: id}, _resolution) do
    case Context.get_address(id) do
      nil -> {:error, "address not found, id=#{id}"}
      address -> {:ok, address}
    end
  end

  def get_contact(%{id: id}, _resolution) do
    case Context.get_contact(id) do
      nil -> {:error, "contact not found, id=#{id}"}
      contact -> {:ok, contact}
    end
  end

end
