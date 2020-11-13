defmodule FakersApiWeb.GraphQL.Resolvers do
  alias FakersApi.People, as: Repo

  def get_people(_parent, _args, _resolution), do: {:ok, Repo.list_people()}

  def get_person(_parent, %{id: id}, _resolution) do
    case Repo.get_person(id) do
      nil -> {:error, "person not found, id=#{id}"}
      person -> {:ok, person}
    end
  end

  def get_address(_parent, %{id: id}, _resolution) do
    case Repo.get_address(id) do
      nil -> {:error, "address not found, id=#{id}"}
      address -> {:ok, address}
    end
  end

  def get_contact(_parent, %{id: id}, _resolution) do
    case Repo.get_contact(id) do
      nil -> {:error, "contact not found, id=#{id}"}
      contact -> {:ok, contact}
    end
  end

end
